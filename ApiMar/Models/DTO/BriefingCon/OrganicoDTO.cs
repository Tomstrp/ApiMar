namespace ApiMar.Models.DTO.BriefingCon;

public class OrganicoDTO
{
	public int TipologiaId { get; set; }
	public EntitaDTO? Nucleo { get; set; }
	public EntitaDTO? Qualifica { get; set; }
	public EntitaDTO? Specializzazione { get; set; }

	public int? QtaRisorseUmaneOrganico { get; set; }
	public int? QtaRisorseMezziOrganico { get; set; }
	public int? QtaRisorseUmaneReali { get; set; }
	public int? QtaRisorseMezziReali { get; set; }
}