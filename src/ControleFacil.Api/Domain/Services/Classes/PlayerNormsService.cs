using AutoMapper;
using ControleFacil.Api.Contract.PlayerNorms;
using ControleFacil.Api.Domain.Models;
using ControleFacil.Api.Domain.Repository.Interfaces;
using ControleFacil.Api.Domain.Services.Interfaces;
using ControleFacil.Api.Exceptions;

namespace ControleFacil.Api.Damain.Services.Classes
{
    public class PlayerNormsService : IService<PlayerNormsRequestContract, PlayerNormsResponseContract, long>
    {
        private readonly IPlayerNormsRepository _playerNormsRepository;
        private readonly IMapper _mapper;

        public PlayerNormsService(
            IPlayerNormsRepository playerNormsRepository,
            IMapper mapper)
        {
            _playerNormsRepository = playerNormsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlayerNormsResponseContract>> Get(long userId)
        {
            var playersNorms = await _playerNormsRepository.GetByUserId(userId);
            return playersNorms.Select(player => _mapper.Map<PlayerNormsResponseContract>(player));
        }

        public async Task<PlayerNormsResponseContract> Get(long id, long userId)
        {
            PlayerNorms playerNorms = await GetByIdToUserId(id, userId);

            return _mapper.Map<PlayerNormsResponseContract>(playerNorms);
        }

        private async Task<PlayerNorms> GetByIdToUserId(long id, long userId)
        {
            var playerNorms = await _playerNormsRepository.Get(id);

            if (playerNorms is null || playerNorms.UserId != userId)
            {
                throw new NotFoundException($"Not found by the id: {id}");
            }

            return playerNorms;
        }

        public async Task<PlayerNormsResponseContract> Post(PlayerNormsRequestContract entity, long userId)
        {
            PlayerNorms playerNorms = _mapper.Map<PlayerNorms>(entity);

            playerNorms.UserId = entity.UserId;

            playerNorms = await _playerNormsRepository.Post(playerNorms);

            return _mapper.Map<PlayerNormsResponseContract>(playerNorms);
        }

        public async Task<PlayerNormsResponseContract> Put(long id, PlayerNormsRequestContract entity, long userId)
        {
            PlayerNorms playerNorms = await GetByIdToUserId(id, userId);

            playerNorms.Norm = entity.Norm;
            playerNorms.UserId = entity.UserId;

            playerNorms = await _playerNormsRepository.Put(playerNorms);

            return _mapper.Map<PlayerNormsResponseContract>(playerNorms);
        }

        public async Task Inactivation(long id, long userId)
        {
            PlayerNorms playerNorms = await GetByIdToUserId(id, userId);

            await _playerNormsRepository.Delete(playerNorms);
        }
    }
}