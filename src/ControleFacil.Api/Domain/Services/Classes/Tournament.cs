using AutoMapper;
using ControleFacil.Api.Contract.Tournament;
using ControleFacil.Api.Domain.Models;
using ControleFacil.Api.Domain.Repository.Interfaces;
using ControleFacil.Api.Domain.Services.Interfaces;

namespace ControleFacil.Api.Damain.Services.Classes
{
    public class TournamentService : IService<TournamentRequestContract, TournamentResponseContract, long>
    {
        private readonly IRepository<Tournament, long> _tournamentRepository;
        private readonly IMapper _mapper;

        public TournamentService(
            IRepository<Tournament, long> tournamentRepository,
            IMapper mapper)
        {
            _tournamentRepository = tournamentRepository;
            _mapper = mapper;
        }

        public Task<IEnumerable<TournamentResponseContract>> Get(long userId)
        {
            return null;
        }

        public async Task<TournamentResponseContract> Get(long id, long userId)
        {
            Tournament tournament = await GetByIdToUserId(id, userId);

            return _mapper.Map<TournamentResponseContract>(tournament);
        }

        private async Task<Tournament> GetByIdToUserId(long id, long userId)
        {
            var tournament = await _tournamentRepository.Get(id);

            return tournament;
        }

        public async Task<TournamentResponseContract> Post(TournamentRequestContract entity, long userId)
        {
            Tournament tournament = _mapper.Map<Tournament>(entity);

            tournament = await _tournamentRepository.Post(tournament);

            return _mapper.Map<TournamentResponseContract>(tournament);
        }

        public async Task<TournamentResponseContract> Put(long id, TournamentRequestContract entity, long userId)
        {
            Tournament tournament = await GetByIdToUserId(id, userId);

            tournament.Name = entity.Name;
            tournament.ChessResults = entity.ChessResults;
            tournament.Date = entity.Date;

            tournament = await _tournamentRepository.Put(tournament);

            return _mapper.Map<TournamentResponseContract>(tournament);
        }

        public async Task Inactivation(long id, long userId)
        {
            Tournament tournament = await GetByIdToUserId(id, userId);

            await _tournamentRepository.Delete(tournament);
        }
    }
}