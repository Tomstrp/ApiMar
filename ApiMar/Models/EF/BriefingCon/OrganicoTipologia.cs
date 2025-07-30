using ApiMar.Models.EF.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMar.Models.EF.BriefingCon;

[Table("organicitipologie", Schema = "briefingcon")]
public partial class OrganicoTipologia
{
	[Column("id")]
	public int Id { get; set; }

	[Column("nome")]
	public string Nome { get; set; } = null!;

	[Column("sedeid")]
	public int SedeId { get; set; }

	[Column("qualificaid")]
	public int? QualificaId { get; set; }

	[Column("nucleoid")]
	public int? NucleoId { get; set; }

	[Column("specializzazioneid")]
	public int? SpecializzazioneId { get; set; }

	public virtual Nucleo? Nucleo { get; set; }

	public virtual ICollection<OrganicoDisponibile> OrganicoDisponibile { get; set; } = new List<OrganicoDisponibile>();

	public virtual ICollection<Organico> Organici { get; set; } = new List<Organico>();

	public virtual Qualifica? Qualifica { get; set; }

	public virtual Sede Sede { get; set; } = null!;

	public virtual Specializzazione? Specializzazione { get; set; }
}
