using AutoMapper;
using ControleFacil.Api.Contract.User;
using ControleFacil.Api.Domain.Models;

namespace ControleFacil.Api.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserRequestContract>().ReverseMap();
            CreateMap<User, UserResponseContract>().ReverseMap();
        }
    }
}