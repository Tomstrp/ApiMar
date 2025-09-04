using ApiMar.Controllers;
using ApiMar.Repositories.Interfaces;
using ApiMar.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ApiMar.Controllers
{
	[ApiController]
	[EnableCors("CorsPolicy")]
	[Route("[controller]/[action]")]
	public class BriefingConController : ControllerBase
	{
		private readonly IBriefingConRepository _briefingConRepository;
		private readonly ILogger<AuthController> _logger;

		public BriefingConController(ILogger<AuthController> logger, IBriefingConRepository briefingConRepository)
		{
			_logger = logger;
			_briefingConRepository = briefingConRepository;
		}

		[HttpGet]
		public async Task<IActionResult> Servizi(int pageIndex = 1, int pageSize = 20, int id = 0, DateOnly? data = null, string turno = "", bool? notturno = null, string username = "")
		{
			try
			{
				var result = await _briefingConRepository.Servizi(pageIndex, pageSize, id, data, turno, notturno, username);
				return Ok(result);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Errore in BriefingConController - Organici: {ex.Message}");
				BadRequest();
			}
			return BadRequest();
		}

		[HttpGet]
		public async Task<IActionResult> Servizio(int id)
		{
			try
			{
				var result = await _briefingConRepository.Servizio(id);
				return Ok(result);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Errore in BriefingConController - Servizio: {ex.Message}");
				BadRequest();
			}
			return BadRequest();
		}

		[HttpPost]
		public async Task<IActionResult> Servizio(ServizioPostDTO servizio)
		{
			try
			{
				var result = await _briefingConRepository.ServizioInserimento(servizio);
				//return CreatedAtAction(nameof(GetOrdineById), new { id = ordine.Id }, ordineReadDto);
				return Ok(result);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Errore in BriefingConController - Servizio: {ex.Message}");
				BadRequest();
			}
			return BadRequest();
		}

		[HttpGet]
		public async Task<IActionResult> UltimiOrganici()
		{
			try
			{
				var result = await _briefingConRepository.UltimiOrganici();
				return Ok(result);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"Errore in BriefingConController - UltimiOrganici: {ex.Message}");
				BadRequest();
			}
			return BadRequest();
		}

	}
}
