using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMar.Models.EF.BriefingCon;


[Table("organicidisponibili", Schema = "briefingcon")]
public partial class OrganicoDisponibile
{
	[Column("id")]
	public int Id { get; set; }

	[Column("tipologiaid")]
	public int TipologiaId { get; set; }

	[Column("servizioid")]
	public int ServizioId { get; set; }

	[Column("qtarisorseumanedisponibili")]
	public int QtaRisorseUmaneDisponibili { get; set; }

	[Column("qtarisorsemezzidisponibili")]
	public int QtaRisorseMezziDisponibili { get; set; }

	public virtual Servizio Servizio { get; set; } = null!;

	public virtual OrganicoTipologia Tipologia { get; set; } = null!;
}
