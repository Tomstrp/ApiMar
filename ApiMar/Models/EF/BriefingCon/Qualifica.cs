using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMar.Models.EF.BriefingCon;

[Table("qualifiche", Schema = "briefingcon")]
public partial class Qualifica
{
	[Column("id")]
	public int Id { get; set; }

	[Column("nome")]
	public string Nome { get; set; } = null!;

	[Column("categoria")]
	public string? Categoria { get; set; }

	public virtual ICollection<OrganicoTipologia> OrganicoTipologie { get; set; } = new List<OrganicoTipologia>();
}
