namespace ApiMar.Models.DTO.BriefingCon;

public partial class ServizioDTO
{
    public int Id { get; set; }
	public DateOnly Data { get; set; }
	public string Username { get; set; } = null!;
	public char Turno { get; set; }
	public bool? Notturno { get; set; }
	public string Sede { get; set; } = null!;
	public List<OrganicoDisponibileDTO>? OrganiciDisponibili { get; set; } = null;
	//public List<OrganicoDTO> Organici { get; set; } = new List<OrganicoDTO>();
}
