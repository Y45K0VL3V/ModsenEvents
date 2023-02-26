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
                  .RequireDestinationMemberSource(true);
        }
    }
}
