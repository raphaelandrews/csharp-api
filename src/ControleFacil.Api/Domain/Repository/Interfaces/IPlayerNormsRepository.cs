using ControleFacil.Api.Domain.Models;

namespace ControleFacil.Api.Domain.Repository.Interfaces
{
    public interface IPlayerNormsRepository : IRepository<PlayerNorms, long>
    {
         Task<IEnumerable<PlayerNorms>> GetByUserId(long UserId);
    }
}