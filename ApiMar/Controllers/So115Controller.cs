using ApiMar.Repositories.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ApiMar.Controllers
{
	[ApiController]
	[EnableCors("CorsPolicy")]
	[Route("[controller]/[action]")]
	public class So115Controller : ControllerBase
	{
		private readonly IConfiguration _configuration;
		private readonly ILogger<So115Controller> _logger;
		private readonly ISO115Repository _soRepository;

		public So115Controller(IConfiguration configuration, ILogger<So115Controller> logger, ISO115Repository soRepository)
		{
			_configuration = configuration;
			_logger = logger;
			_soRepository = soRepository;
		}

		[HttpGet]
		public async Task<IActionResult> InterventiChiusi(DateTime Da, DateTime A/*,  string operatoreChiamata = ""*/)
		{
			try
			{
				var interventi = await _soRepository.InterventiChiusi(_configuration, Da, A/*, operatoreChiamata*/);
				return Ok(interventi);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Errore in BriefingConController - Organici: {ex.Message}");
				BadRequest();
			}
			return BadRequest();
		}

	}
}
