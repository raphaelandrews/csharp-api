using AutoMapper;
using ControleFacil.Api.Contract.PlayerTournaments;
using ControleFacil.Api.Domain.Models;

namespace ControleFacil.Api.AutoMapper
{
    public class PlayerTournamentsProfile : Profile
    {
        public PlayerTournamentsProfile()
        {
            CreateMap<PlayerTournaments, PlayerTournamentsRequestContract>().ReverseMap();
            CreateMap<PlayerTournaments, PlayerTournamentsResponseContract>().ReverseMap();
        }
    }
}