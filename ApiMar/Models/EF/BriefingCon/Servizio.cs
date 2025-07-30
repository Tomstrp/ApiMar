using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMar.Models.EF.BriefingCon;

[Table("servizi", Schema = "briefingcon")]
public partial class Servizio
{
	[Column("id")]
	public int Id { get; set; }

	[Column("data")]
	public DateOnly Data { get; set; }

	[Column("username")]
	public string Username { get; set; } = null!;

	[Column("turno")]
	public char Turno { get; set; }

	[Column("notturno")]
	public bool? Notturno { get; set; }

	[Column("sede")]
	public string Sede { get; set; } = null!;

	//public virtual ICollection<OrganicoDisponibile>? OrganiciDisponibili { get; set; } = new List<OrganicoDisponibile>();

	public List<OrganicoDisponibile> OrganiciDisponibili { get; set; } = new List<OrganicoDisponibile>();
}
