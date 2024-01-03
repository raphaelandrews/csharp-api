using AutoMapper;
using ControleFacil.Api.Contract.Tournament;
using ControleFacil.Api.Domain.Models;

namespace ControleFacil.Api.AutoMapper
{
    public class TournamentProfile : Profile
    {
        public TournamentProfile()
        {
            CreateMap<Tournament, TournamentRequestContract>().ReverseMap();
            CreateMap<Tournament, TournamentResponseContract>().ReverseMap();
        }
    }
}