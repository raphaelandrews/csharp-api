using AutoMapper;
using ControleFacil.Api.Contract.PlayerNorms;
using ControleFacil.Api.Domain.Models;

namespace ControleFacil.Api.AutoMapper
{
    public class PlayerNormsProfile : Profile
    {
        public PlayerNormsProfile()
        {
            CreateMap<PlayerNorms, PlayerNormsRequestContract>().ReverseMap();
            CreateMap<PlayerNorms, PlayerNormsResponseContract>().ReverseMap();
        }
    }
}