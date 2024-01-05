using AutoMapper;
using JORNADAMILHASAPI.Data.Dtos;
using JORNADAMILHASAPI.Models;

namespace JORNADAMILHASAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();
            CreateMap<User, ReadUserDto>();
        }
    }
}
