using AutoMapper;
using ControleFacil.Api.Contract.PlayerPodiums;
using ControleFacil.Api.Domain.Models;

namespace ControleFacil.Api.AutoMapper
{
    public class PlayerPodiumsProfile : Profile
    {
        public PlayerPodiumsProfile()
        {
            CreateMap<PlayerPodiums, PlayerPodiumsRequestContract>().ReverseMap();
            CreateMap<PlayerPodiums, PlayerPodiumsResponseContract>().ReverseMap();
        }
    }
}