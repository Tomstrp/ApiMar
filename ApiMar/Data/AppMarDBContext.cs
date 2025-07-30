using ApiMar.Models;
using ApiMar.Models.EF.BriefingCon;
using ApiMar.Models.EF.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApiMar.Data;

public partial class AppMarDBContext : DbContext
{
	public AppMarDBContext()
	{
	}

	public AppMarDBContext(DbContextOptions<AppMarDBContext> options)
		: base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


	public virtual DbSet<Nucleo> Nuclei { get; set; }

	public virtual DbSet<Organico> Organici { get; set; }

	public virtual DbSet<OrganicoDisponibile> OrganiciDisponibili { get; set; }

	public virtual DbSet<OrganicoTipologia> OrganiciTipologie { get; set; }

	public virtual DbSet<Qualifica> Qualifiche { get; set; }

	//public virtual DbSet<ruolo> ruolos { get; set; }

	public virtual DbSet<Sede> Sedi { get; set; }

	public virtual DbSet<SedeTipologia> SediTipologie { get; set; }

	public virtual DbSet<Servizio> Servizi { get; set; }

	public virtual DbSet<Specializzazione> Specializzazioni { get; set; }

	public virtual DbSet<utenteruolo> utenteruolos { get; set; }

	//public DbSet<SediTipologia> SediTipologia { get; set; }

	//public virtual DbSet<nucleus> nuclei { get; set; }

	//public virtual DbSet<organico> organicos { get; set; }

	//public virtual DbSet<organicodisponibile> organicodisponibiles { get; set; }

	//public virtual DbSet<organicotipologium> organicotipologia { get; set; }

	//public virtual DbSet<qualifiche> qualifiches { get; set; }

	//public virtual DbSet<ruolo> ruolos { get; set; }

	//public virtual DbSet<sedi> sedis { get; set; }

	//public virtual DbSet<seditipologium> seditipologia { get; set; }

	//public virtual DbSet<specializzazioni> specializzazionis { get; set; }

	//public virtual DbSet<utenteruolo> utenteruolos { get; set; }

}
