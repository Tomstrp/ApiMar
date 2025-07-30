using ApiMar.Models.DTO.Auth;
using ApiMar.Repositories.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.DirectoryServices.Protocols;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace ApiMar.Repositories
{
	public class AuthLdapRepository : IAuthRepository
	{

		public async Task<UserWaucDTO?> Login(IConfiguration configuration, string username, [DataType(DataType.Password)] string password)
		{
			try
			{
				var credential = new NetworkCredential(username, password);
				var ldapConn = new LdapConnection(configuration["LdapServer"])
				{
					AuthType = AuthType.Negotiate
				};
				ldapConn.Bind(credential);

				HttpClient client = new HttpClient();
				var request = new HttpRequestMessage
				{
					Method = HttpMethod.Get,
					RequestUri = new Uri($"{configuration["WaucUrl"]}/api/Personale?accountName={username.Split("@")[0]}")
				};
				var response = await client.SendAsync(request);
				var responseBody = await response.Content.ReadAsStringAsync();
				var user = JsonSerializer.Deserialize<UserWaucDTO[]>(responseBody);

				return user?[0];
			}
			catch (LdapException ex)
			{
				throw new Exception("Autenticazione fallita");
			}
		}

		public string JwtTokenGenerate(IConfiguration configuration, UserWaucDTO user)
		{
			var jwtSettings = configuration.GetSection("Jwt");
			var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);

			var tokenHandler = new JwtSecurityTokenHandler();
			var claims = new[]
			{
				new Claim(ClaimTypes.UserData, JsonSerializer.Serialize(user))
			};

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["ExpireMinutes"])),
				Issuer = jwtSettings["Issuer"],
				Audience = jwtSettings["Audience"],
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}

		public UserWaucDTO JwtTokenCheck(IConfiguration configuration, string token)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var jwtSettings = configuration.GetSection("Jwt");
			var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);

			var validationParams = new TokenValidationParameters
			{
				ValidateIssuer = true,
				ValidIssuer = jwtSettings["Issuer"],

				ValidateAudience = true,
				ValidAudience = jwtSettings["Audience"],

				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(key),

				ValidateLifetime = true,
				ClockSkew = TimeSpan.FromMinutes(1) // tolleranza oraria
			};

			try
			{
				var principal = tokenHandler.ValidateToken(token, validationParams, out SecurityToken validatedToken);

				// Controlla che sia un JWT firmato correttamente
				if (validatedToken is JwtSecurityToken jwt &&
					jwt.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
				{
					var claim = principal.FindFirstValue(ClaimTypes.UserData);
					return JsonSerializer.Deserialize<UserWaucDTO>(claim);
				}
			}
			catch
			{
				throw new Exception("Token non valido");
			}
			throw new Exception("Errore nella verifica del token");
		}


	}
}
