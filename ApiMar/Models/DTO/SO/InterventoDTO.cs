using System.Data;

namespace ApiMar.Models.DTO.SO
{
	public class InterventoDTO
	{
		public int? ID { get; set; }
		public DateTime? Data { get; set; }
		public string? SiglaProvincia { get; set; }
		public double X { get; set; }
		public double Y { get; set; }
		public string? Richiedente { get; set; }
		public string? Note { get; set; }
		public string? MatricolaOperatoreChiamata { get; set; }
		public string? MatricolaOperatoreIntervento { get; set; }
		public short CodiceTipologia { get; set; }


		public InterventoDTO(DataRow r)
		{
			ID = (int?)r["INTERVENTO"];
			Data = (DateTime?)r["DATA_INTERVENTO"];
			SiglaProvincia = (string?)r["SIGLA_PROVINCIA"];
			X = r["X"] != DBNull.Value ? (double)r["X"] : 0;
			Y = r["Y"] != DBNull.Value ? (double)r["Y"] : 0;
			Richiedente = (string?)r["RICHIEDENTE"];
			Note = r["NOTE_INTERVENTO"] != DBNull.Value ? (string?)r["NOTE_INTERVENTO"] : null;
			MatricolaOperatoreChiamata = (string?)r["MATRICOLA_OPERATORE_CHIAMATA"];
			MatricolaOperatoreIntervento = (string?)r["MATRICOLA_OPERATORE_INTERVENTO"];
			CodiceTipologia = (short)r["COD_TIPOLOGIA"];
		}

	}

}
