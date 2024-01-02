using ControleFacil.Api.Damain.Repository.Interfaces;
using ControleFacil.Api.Data;
using ControleFacil.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleFacil.Api.Damain.Repository.Classes
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<User> Post(User entity)
        {
            await _context.User.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<User> Put(User entity)
        {
            User entityDatabase = _context.User
                .Where(u => u.Id == entity.Id)
                .FirstOrDefault();

            _context.Entry(entityDatabase).CurrentValues.SetValues(entity);
            _context.Update<User>(entityDatabase);

            await _context.SaveChangesAsync();

            return entityDatabase;
        }

        public async Task Delete(User entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<User?> Get(string email)
        {
            return await _context.User.AsNoTracking()
                                          .Where(u => u.Email == email)
                                          .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> Get()
        {
            return await _context.User.AsNoTracking()
                                          .OrderBy(u => u.Id)
                                          .ToListAsync();
        }

        public async Task<User?> Get(long id)
        {
            return await _context.User.AsNoTracking()
                                .Where(u => u.Id == id)
                                .FirstOrDefaultAsync();
        }
    }
}