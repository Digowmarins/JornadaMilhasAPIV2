using AutoMapper;
using JORNADAMILHASAPI.Data.Dtos;
using JORNADAMILHASAPI.Models;

namespace JORNADAMILHASAPI.Profiles
{
    public class DestinoProfile : Profile
    {
        public DestinoProfile()
        {
            CreateMap<CreateDestinoDto, Destino>();
            CreateMap<UpdateDestinoDto, Destino>();
            CreateMap<Destino, ReadDestinoDto>();
        }
    }
}
