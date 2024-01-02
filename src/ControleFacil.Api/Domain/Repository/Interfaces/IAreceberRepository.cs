using ControleFacil.Api.Damain.Models;

namespace ControleFacil.Api.Damain.Repository.Interfaces
{
    public interface IAreceberRepository : IRepository<Areceber, long>
    {
        Task<IEnumerable<Areceber>> GetPeloIdUser(long idUser);
    }
}