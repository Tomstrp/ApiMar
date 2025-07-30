using ApiMar.Repositories.Interfaces;
using ApiMar.Models.DTO.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

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

		[HttpGet]
		public async Task<IActionResult> Login([FromQuery] string username, [FromQuery] string password)
		{
			try
			{
				UserWaucDTO? u = await _authRepository.Login(_configuration, username, password);
				var token = _authRepository.JwtTokenGenerate(_configuration, u);
				return Ok(token);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Errore in AuthController - Login: {ex.Message}");
				BadRequest();
			}
			return BadRequest();
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
