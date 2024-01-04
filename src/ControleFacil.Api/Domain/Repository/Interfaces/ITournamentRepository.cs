using ControleFacil.Api.Domain.Models;

namespace ControleFacil.Api.Domain.Repository.Interfaces
{
    public interface ITournamentRepository : IRepository<Tournament, long>
    {
        Task<IEnumerable<PlayerTournaments>> GetByUserId(long UserId);
    }
}