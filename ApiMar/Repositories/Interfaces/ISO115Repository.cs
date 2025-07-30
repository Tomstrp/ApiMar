using ApiMar.Models.DTO.SO;

namespace ApiMar.Repositories.Interfaces
{
	public interface ISO115Repository
	{
		Task<List<InterventoDTO>> InterventiChiusi(IConfiguration configuration, DateTime dataInizio, DateTime dataFine/*, string operatore = ""*/);
	}
}
