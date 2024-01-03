using AutoMapper;
using ControleFacil.Api.Contract.PlayerPodiums;
using ControleFacil.Api.Domain.Models;
using ControleFacil.Api.Domain.Repository.Interfaces;
using ControleFacil.Api.Domain.Services.Interfaces;
using ControleFacil.Api.Exceptions;

namespace ControleFacil.Api.Damain.Services.Classes
{
    public class PlayerPodiumsService : IService<PlayerPodiumsRequestContract, PlayerPodiumsResponseContract, long>
    {
        private readonly IPlayerPodiumsRepository _playerPodiumsRepository;
        private readonly IMapper _mapper;

        public PlayerPodiumsService(
            IPlayerPodiumsRepository playerPodiumsRepository,
            IMapper mapper)
        {
            _playerPodiumsRepository = playerPodiumsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlayerPodiumsResponseContract>> Get(long userId)
        {
            var playersPodiums = await _playerPodiumsRepository.GetByUserId(userId);
            return playersPodiums.Select(player => _mapper.Map<PlayerPodiumsResponseContract>(player));
        }

        public async Task<PlayerPodiumsResponseContract> Get(long id, long userId)
        {
            PlayerPodiums playerPodiums = await GetByIdToUserId(id, userId);

            return _mapper.Map<PlayerPodiumsResponseContract>(playerPodiums);
        }

        private async Task<PlayerPodiums> GetByIdToUserId(long id, long userId)
        {
            var playerPodiums = await _playerPodiumsRepository.Get(id);

            if (playerPodiums is null || playerPodiums.UserId != userId)
            {
                throw new NotFoundException($"Not found by the id: {id}");
            }

            return playerPodiums;
        }

        public async Task<PlayerPodiumsResponseContract> Post(PlayerPodiumsRequestContract entity, long userId)
        {
            PlayerPodiums playerPodiums = _mapper.Map<PlayerPodiums>(entity);

            playerPodiums.UserId = userId;

            playerPodiums = await _playerPodiumsRepository.Post(playerPodiums);

            return _mapper.Map<PlayerPodiumsResponseContract>(playerPodiums);
        }

        public async Task<PlayerPodiumsResponseContract> Put(long id, PlayerPodiumsRequestContract entity, long userId)
        {
            PlayerPodiums playerPodiums = await GetByIdToUserId(id, userId);

            playerPodiums.Place = entity.Place;
            playerPodiums.UserId = entity.UserId;
            playerPodiums.TournamentId = entity.TournamentId;

            playerPodiums = await _playerPodiumsRepository.Put(playerPodiums);

            return _mapper.Map<PlayerPodiumsResponseContract>(playerPodiums);
        }

        public async Task Inactivation(long id, long userId)
        {
            PlayerPodiums playerPodiums = await GetByIdToUserId(id, userId);

            await _playerPodiumsRepository.Delete(playerPodiums);
        }
    }
}