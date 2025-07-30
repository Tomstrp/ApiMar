using ApiMar.Models.DTO.SO;
using ApiMar.Repositories.Interfaces;
using ApiMar.Services;
using System.Data;

namespace ApiMar.Repositories
{
	public class OracleSO115Repository : ISO115Repository
	{


		public async Task<List<InterventoDTO>> InterventiChiusi(IConfiguration configuration, DateTime dataInizio, DateTime dataFine/*, string operatoreChiamata = ""*/)
		{
			string[] connectionStrings = [
				configuration.GetConnectionString(name: "OracleSoStampeAN"),
				configuration.GetConnectionString(name: "OracleSoStampeMC")
			];
			var sqlService = new OracleService(connectionStrings);
			var q = @"
SELECT INTERVENTO, DATA_INTERVENTO, SIGLA_PROVINCIA, X, Y, RICHIEDENTE, NOTE_INTERVENTO, MATRICOLA_OPERATORE_CHIAMATA, MATRICOLA_OPERATORE_INTERVENTO, COD_TIPOLOGIA
FROM V_INTERVENTI_CHIUSI_SOSTAMPE 
WHERE DATA_INTERVENTO BETWEEN :da AND :a";  // AND MATRICOLA_OPERATORE_CHIAMATA LIKE '%'||:operatoreChiamata||'%'

			var dict = new Dictionary<string, object>()
			{
				{":da", dataInizio },
				{":a", dataFine }
				//,
				//{":operatoreChiamata", operatoreChiamata }
			};
			var ds = await sqlService.FillDataset(q, dict);
			List<DataRow> rows = new();
			foreach (DataTable dt in ds.Tables)
				rows.AddRange(dt.AsEnumerable());

			return rows.AsEnumerable().Select(x => new InterventoDTO(x)).ToList();
		}

	}
}
