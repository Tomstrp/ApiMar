namespace ApiMar.Models.DTO.Auth
{
	public class UserWaucDTO
	{
		public string? codiceFiscale { get; set; }
		public string? cognome { get; set; }
		public string? nome { get; set; }
		public string? accountDipvvf { get; set; }
		public string? emailVigilfuoco { get; set; }
		public Qualifica? qualifica { get; set; }
		public Sede? sede { get; set; } = new Sede();
		public List<Specializzazioni>? specializzazioni { get; set; }
		public string? turno { get; set; }
		public string? saltoTurno { get; set; }
		public TipoPersonale? tipoPersonale { get; set; }
	}

	public class Gruppo
	{
		public string? codice { get; set; }
		public string? descrizione { get; set; }
		public object? ambito { get; set; }
	}

	public class Qualifica
	{
		public string? nome { get; set; }
		public Gruppo? gruppo { get; set; }
		public string? codSettore { get; set; }
		public string? codice { get; set; }
		public string? descrizione { get; set; }
	}

	public class Sede
	{
		public string? id { get; set; }
		public string? codice { get; set; }
		public string? codDistaccamento { get; set; }
		public string? descrizione { get; set; }
		public string? descrizionePadre { get; set; }
	}

	public class Specializzazioni
	{
		public string? codice { get; set; }
		public string? descrizione { get; set; }
		public string? dataInizioValidita { get; set; }
		public string? dataFineValidita { get; set; }
	}

	public class TipoPersonale
	{
		public string? codice { get; set; }
		public string? descrizione { get; set; }
	}



}
