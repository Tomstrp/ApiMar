using ApiMar.Models;
using ApiMar.Models.DTO.BriefingCon;

namespace ApiMar.Repositories.Interfaces
{
	public interface IBriefingConRepository
	{
		Task<List<ServizioDTO>> Servizi(int page, int elementInPage);
		Task<ServizioDTO?> Servizio(int id);
		Task<int> ServizioInserimento(ServizioPostDTO servizio);
		Task<List<OrganicoDTO>> UltimiOrganici();
	}
}
