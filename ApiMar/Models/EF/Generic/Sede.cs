using ApiMar.Models.EF.BriefingCon;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMar.Models.EF.Generic;

[Table("sedi", Schema = "generic")]
public partial class Sede
{
	public int id { get; set; }

	public string nome { get; set; } = null!;

	public int? tipologiaid { get; set; }

	public string? provinciasigla { get; set; }

	public string? cap { get; set; }

	public string? citta { get; set; }

	public string? indirizzo { get; set; }

	public string? civico { get; set; }

	public int? parentid { get; set; }

	public virtual ICollection<Sede> Inverseparent { get; set; } = new List<Sede>();

	public virtual ICollection<OrganicoTipologia> OrganicoTipologie { get; set; } = new List<OrganicoTipologia>();

	public virtual Sede? parent { get; set; }

	//public virtual seditipologie? tipologia { get; set; }
}
