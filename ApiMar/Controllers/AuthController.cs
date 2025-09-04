using ApiMar.Repositories.Interfaces;
using ApiMar.Models.DTO.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ApiMar.Models.DTO;

namespace ApiMar.Controllers
{

	[ApiController]
	[EnableCors("CorsPolicy")]
	[Route("[controller]/[action]")]
	public class AuthController : ControllerBase
	{
		private readonly IConfiguration _configuration;
		private readonly ILogger<AuthController> _logger;
		private readonly IAuthRepository _authRepository;

		public AuthController(IConfiguration configuration, ILogger<AuthController> logger, IAuthRepository authRepository)
		{
			_configuration = configuration;
			_logger = logger;
			_authRepository = authRepository;
		}

		[HttpPost()]
		public async Task<IActionResult> Login([FromBody] LoginDTO LoginData)
		{
			try
			{
				UserWaucDTO? u = await _authRepository.Login(_configuration, LoginData.Username, LoginData.Password);
				var token = _authRepository.JwtTokenGenerate(_configuration, u);
				return Ok(new { token });
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Errore in AuthController - Login: {ex.Message}");
				BadRequest();
			}
			return Unauthorized(new { message = "Credenziali non valide" });
		}

		[HttpGet]
		public IActionResult CheckToken([FromQuery] string token)
		{
			try
			{
				UserWaucDTO user = _authRepository.JwtTokenCheck(_configuration, token);
				return Ok(user);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Errore in AuthController - CheckToken: {ex.Message}");
				BadRequest();
			}
			return BadRequest();
		}

		[Authorize]
		[HttpGet]
		public IActionResult TestEndpointProtetto()
		{
			return Ok(new { message = $"Ciao, hai accesso a un endpoint protetto!" });
		}


	}
}
