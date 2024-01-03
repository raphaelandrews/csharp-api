using ControleFacil.Api.Domain.Models;

namespace ControleFacil.Api.Domain.Repository.Interfaces
{
    public interface IPlayerTournamentsRepository : IRepository<PlayerTournaments, long>
    {
         Task<IEnumerable<PlayerTournaments>> GetByUserId(long UserId);
    }
}