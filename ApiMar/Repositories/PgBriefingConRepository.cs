using ApiMar.Data;
using ApiMar.Models;
using ApiMar.Models.EF.BriefingCon;
using ApiMar.Models.DTO;
using ApiMar.Models.DTO.BriefingCon;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Mapster;

namespace ApiMar.Repositories.Interfaces
{
	public class PgBriefingConRepository : IBriefingConRepository
	{
		private readonly AppMarDBContext _context;

		public PgBriefingConRepository(AppMarDBContext context)
		{
			_context = context;
		}

		public async Task<List<ServizioDTO>> Servizi(int page, int elementInPage)
		{
			var result = await _context.Servizi
					.OrderByDescending(x => x.Data)
					.Skip((page - 1) * elementInPage)
					.Take(elementInPage)
					.ProjectToType<ServizioDTO>()
					.ToListAsync();
			return result;
		}

		public async Task<ServizioDTO?> Servizio(int id)
		{
			if (!_context.Servizi.Any(x => x.Id == id))
				throw new Exception("Il servizio non esiste");

			var result = await _context.Servizi
				.Include(x => x.OrganiciDisponibili)
				.Where(x => x.Id == id)
				.ProjectToType<ServizioDTO>()
				.FirstAsync();

			return result;
		}

		public async Task<int> ServizioInserimento(ServizioPostDTO servizio)
		{
			if (_context.Servizi.Any(x => x.Data == servizio.Data && x.Notturno == servizio.Notturno))
				throw new Exception("Servizio già esistente");

			var s = servizio.Adapt<Servizio>();

			await _context.Servizi.AddAsync(s);
			await _context.SaveChangesAsync();

			return s.Id;
		}

		public async Task<List<OrganicoDTO>> UltimiOrganici()
		{
			var organiciDTO = await _context.Organici
				.Include(x => x.Tipologia)
				.GroupBy(x => x.TipologiaId)
				.Select(g => g
					.OrderByDescending(x => x.Anno)
					.Select(x => new OrganicoDTO()
					{
						TipologiaId = x.TipologiaId,
						Nucleo = x.Tipologia.Nucleo != null ? new EntitaDTO() { Id = x.Tipologia.Nucleo.Id, Nome = x.Tipologia.Nucleo.Nome } : null,
						Specializzazione = x.Tipologia.Specializzazione != null ? new EntitaDTO() { Id = x.Tipologia.Specializzazione.Id, Nome = x.Tipologia.Specializzazione.Nome } : null,
						Qualifica = x.Tipologia.Qualifica != null ? new EntitaDTO() { Id = x.Tipologia.Qualifica.Id, Nome = x.Tipologia.Qualifica.Nome } : null,
						QtaRisorseUmaneOrganico = x.QtaRisorseUmaneOrganico,
						QtaRisorseMezziOrganico = x.QtaRisorseMezziOrganico,
						QtaRisorseUmaneReali = x.QtaRisorseMezziReali,
						QtaRisorseMezziReali = x.QtaRisorseMezziReali
					})
					.First())
				.ToListAsync();

			return organiciDTO;
		}
	}
}
