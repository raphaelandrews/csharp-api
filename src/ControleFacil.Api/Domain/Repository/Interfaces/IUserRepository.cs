using ControleFacil.Api.Domain.Models;

namespace ControleFacil.Api.Domain.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User, long>
    {
        Task<User?> Get(string  email);
    }
}