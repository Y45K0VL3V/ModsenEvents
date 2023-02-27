using Application.DTO;
using Domain.Entities;
using Mapster;

namespace Application.Mappers.Mapster
{
    public class Register : IRegister
    {
        void IRegister.Register(TypeAdapterConfig config)
        {
            config.NewConfig<ModsenEvent, ModsenEventDTO>()
                .Map(eDTO => eDTO.DateTimeUTC, e => e.DateUtc.ToDateTime(e.TimeUtc))
                .RequireDestinationMemberSource(true);

            config.NewConfig<ModsenEventDTO, ModsenEvent>()
                .Map(e => e.DateUtc, eDTO => DateOnly.FromDateTime(eDTO.DateTimeUTC))
                .Map(e => e.TimeUtc, eDTO => TimeOnly.FromDateTime(eDTO.DateTimeUTC))
                .RequireDestinationMemberSource(true);
        }
    }
}
