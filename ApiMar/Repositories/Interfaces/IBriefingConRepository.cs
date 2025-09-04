using ApiMar.Models;
using ApiMar.Models.DTO;
using ApiMar.Models.DTO.BriefingCon;

namespace ApiMar.Repositories.Interfaces
{
	public interface IBriefingConRepository
	{
		Task<ResultListDTO<ServizioListDTO>> Servizi(int pageIndex, int pageSize, int id, DateOnly? data, string turno, bool? notturno, string username);
		Task<ServizioDTO?> Servizio(int id);
		Task<int> ServizioInserimento(ServizioPostDTO servizio);
		Task<List<OrganicoDTO>> UltimiOrganici();
	}
}
