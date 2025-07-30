using System.Data;

namespace ApiMar.Models.DTO.SO
{
	public class ChiamataDTO
	{
		public string? Tipo { get; set; }
		public DateTime DataOra { get; set; }
		public double X { get; set; }
		public double Y { get; set; }
		public string? Richiedente { get; set; }
		public string? Descrizione { get; set; }
		public string? Comune { get; set; }
		public decimal Priorita { get; set; }
		public string? Operatore { get; set; }

		public ChiamataDTO(DataRow r)
		{
			Tipo = (string?)r["TIPO"];
			DataOra = Convert.ToDateTime($"{r["DATA_CHIAMATA"]?.ToString()?.Substring(0, 10)} {r["ORA_CHIAMATA"]}");
			X = (double)r["X"];
			Y = (double)r["Y"];
			Richiedente = (string?)r["RICHIEDENTE"];
			Descrizione = (string?)r["DESCRIZIONE"];
			Comune = (string?)r["COMUNE"];
			Priorita = (decimal)r["PRIORITA"];
			Operatore = (string?)r["OPERATORE_CHIAMATA"];
		}
	}

}
