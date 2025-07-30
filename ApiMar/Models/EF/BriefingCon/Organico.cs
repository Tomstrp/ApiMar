using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMar.Models.EF.BriefingCon;

[Table("organici", Schema = "briefingcon")]
public partial class Organico
{
	[Column("id")]
	public int Id { get; set; }

	[Column("anno")]
	public int Anno { get; set; }

	[Column("tipologiaid")]
	public int TipologiaId { get; set; }

	[Column("qtarisorseumaneorganico")]
	public int? QtaRisorseUmaneOrganico { get; set; }

	[Column("qtarisorsemezziorganico")]
	public int? QtaRisorseMezziOrganico { get; set; }

	[Column("qtarisorseumanereali")]
	public int? QtaRisorseUmaneReali { get; set; }

	[Column("qtarisorsemezzireali")]
	public int? QtaRisorseMezziReali { get; set; }

	public virtual OrganicoTipologia Tipologia { get; set; } = null!;
}
