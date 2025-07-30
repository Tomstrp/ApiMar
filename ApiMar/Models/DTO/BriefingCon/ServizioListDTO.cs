namespace ApiMar.Models.DTO.BriefingCon;

public partial class ServizioListDTO
{
    public int Id { get; set; }
	public DateOnly Data { get; set; }
	public string Username { get; set; } = null!;
	public char Turno { get; set; }
	public bool? Notturno { get; set; }
	public string Sede { get; set; } = null!;
}
