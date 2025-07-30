using ApiMar.Models.DTO.BriefingCon;

namespace ApiMar.Models;

public class ServizioPostDTO
{
	public string Username { get; set; } = null!;
	public DateOnly Data { get; set; }
	public char Turno { get; set; }
	public bool? Notturno { get; set; }
	public string Sede { get; set; } = null!;
	public ICollection<OrganicoDisponibileDTO>? OrganiciDisponibili { get; set; } = null;
}