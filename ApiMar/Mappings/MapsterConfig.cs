using ApiMar.Models.DTO;
using ApiMar.Models.DTO.BriefingCon;
using ApiMar.Models.EF.BriefingCon;
using Mapster;

namespace ApiMar.Mappings
{
	public class MapsterConfig : IRegister
	{
		public void Register(TypeAdapterConfig config)
		{
			config.NewConfig<Nucleo, EntitaDTO>();
			config.NewConfig<Qualifica, EntitaDTO>();
			config.NewConfig<Specializzazione, EntitaDTO>();
			config.NewConfig<Servizio, ServizioDTO>()
				.TwoWays();
			config.NewConfig<Servizio, ServizioListDTO>();
			config.NewConfig<Organico, OrganicoDTO>()
				.Map(dest => dest.Nucleo, src => src.Tipologia.Nucleo.Adapt<EntitaDTO>())
				.Map(dest => dest.Specializzazione, src => src.Tipologia.Specializzazione.Adapt<EntitaDTO>())
				.Map(dest => dest.Qualifica, src => src.Tipologia.Qualifica.Adapt<EntitaDTO>());
			config.NewConfig<OrganicoDisponibile, OrganicoDisponibileDTO>()
				.TwoWays();
		}
	}
}
