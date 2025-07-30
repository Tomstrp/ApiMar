using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMar.Models.EF.BriefingCon;


[Table("nuclei", Schema = "briefingcon")]
public partial class Nucleo
{
	[Column("id")]
	public int Id { get; set; }

	[Column("nome")]
	public string Nome { get; set; } = null!;

	public virtual ICollection<OrganicoTipologia> OrganicoTipologie { get; set; } = new List<OrganicoTipologia>();
}
