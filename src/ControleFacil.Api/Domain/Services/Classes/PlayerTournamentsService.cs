using AutoMapper;
using ControleFacil.Api.Contract.PlayerTournaments;
using ControleFacil.Api.Domain.Models;
using ControleFacil.Api.Domain.Repository.Interfaces;
using ControleFacil.Api.Domain.Services.Interfaces;
using ControleFacil.Api.Exceptions;

namespace ControleFacil.Api.Damain.Services.Classes
{
    public class PlayerTournamentsService : IService<PlayerTournamentsRequestContract, PlayerTournamentsResponseContract, long>
    {
        private readonly IPlayerTournamentsRepository _playerTournamentsRepository;
        private readonly IMapper _mapper;

        public PlayerTournamentsService(
            IPlayerTournamentsRepository playerTournamentsRepository,
            IMapper mapper)
        {
            _playerTournamentsRepository = playerTournamentsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlayerTournamentsResponseContract>> Get(long userId)
        {
            var playersTournaments = await _playerTournamentsRepository.GetByUserId(userId);
            return playersTournaments.Select(player => _mapper.Map<PlayerTournamentsResponseContract>(player));
        }

        public async Task<PlayerTournamentsResponseContract> Get(long id, long userId)
        {
            PlayerTournaments playerTournaments = await GetByIdToUserId(id, userId);

            return _mapper.Map<PlayerTournamentsResponseContract>(playerTournaments);
        }

        private async Task<PlayerTournaments> GetByIdToUserId(long id, long userId)
        {
            var playerTournaments = await _playerTournamentsRepository.Get(id);

            if (playerTournaments is null || playerTournaments.UserId != userId)
            {
                throw new NotFoundException($"Not found by the id: {id}");
            }

            return playerTournaments;
        }

        public async Task<PlayerTournamentsResponseContract> Post(PlayerTournamentsRequestContract entity, long userId)
        {
            PlayerTournaments playerTournaments = _mapper.Map<PlayerTournaments>(entity);

            playerTournaments.UserId = entity.UserId;

            playerTournaments = await _playerTournamentsRepository.Post(playerTournaments);

            return _mapper.Map<PlayerTournamentsResponseContract>(playerTournaments);
        }

        public async Task<PlayerTournamentsResponseContract> Put(long id, PlayerTournamentsRequestContract entity, long userId)
        {
            PlayerTournaments playerTournaments = await GetByIdToUserId(id, userId);

            playerTournaments.RatingType = entity.RatingType;
            playerTournaments.OldRating = entity.OldRating;
            playerTournaments.Variation = entity.Variation;

            playerTournaments = await _playerTournamentsRepository.Put(playerTournaments);

            return _mapper.Map<PlayerTournamentsResponseContract>(playerTournaments);
        }

        public async Task Inactivation(long id, long userId)
        {
            PlayerTournaments playerTournaments = await GetByIdToUserId(id, userId);

            await _playerTournamentsRepository.Delete(playerTournaments);
        }
    }
}