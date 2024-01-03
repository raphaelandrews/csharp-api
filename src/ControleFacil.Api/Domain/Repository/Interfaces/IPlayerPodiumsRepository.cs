using ControleFacil.Api.Domain.Models;

namespace ControleFacil.Api.Domain.Repository.Interfaces
{
    public interface IPlayerPodiumsRepository : IRepository<PlayerPodiums, long>
    {
         Task<IEnumerable<PlayerPodiums>> GetByUserId(long UserId);
    }
}