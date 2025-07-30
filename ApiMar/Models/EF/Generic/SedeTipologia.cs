using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMar.Models.EF.Generic;

[Table("seditipologie", Schema = "generic")]
public class SedeTipologia
{
	[Column("id")]
	public int Id { get; set; }

	[Column("nome")]
	public string Nome { get; set; } = null!;
}
