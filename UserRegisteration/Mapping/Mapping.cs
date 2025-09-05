using AutoMapper;
using UserRegisteration.DTOs;
using UserRegisteration.Entities;

namespace UserRegisteration.Mapping
{
    public class Mapping : Profile

    {
        public Mapping() { 
        CreateMap<Contact, ContactDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<User , RegisterUserDto>().ReverseMap();
            

        }
    }
}
