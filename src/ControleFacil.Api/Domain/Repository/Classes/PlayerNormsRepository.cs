using ControleFacil.Api.Domain.Repository.Interfaces;
using ControleFacil.Api.Data;
using ControleFacil.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleFacil.Api.Domain.Repository.Classes
{
    public class PlayerNormsRepository : IPlayerNormsRepository
    {
        private readonly ApplicationContext _context;
        public PlayerNormsRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PlayerNorms>> Get()
        {
            return await _context.PlayerNorms.AsNoTracking()
                                                .OrderBy(u => u.Id)
                                                .ToListAsync();
        }

        public async Task<PlayerNorms?> Get(long id)
        {
            return await _context.PlayerNorms.AsNoTracking()
                                .Where(u => u.Id == id)
                                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PlayerNorms>> GetByUserId(long UserId)
        {
            return await _context.PlayerNorms.AsNoTracking()
                                                .Where(n => n.UserId == UserId)
                                                .OrderBy(n => n.Id)
                                                .ToListAsync();
        }

        public async Task<PlayerNorms> Post(PlayerNorms entity)
        {
            await _context.PlayerNorms.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<PlayerNorms> Put(PlayerNorms entity)
        {
            PlayerNorms entityDatabase = _context.PlayerNorms
                .Where(u => u.Id == entity.Id)
                .FirstOrDefault();

            _context.Entry(entityDatabase).CurrentValues.SetValues(entity);
            _context.Update<PlayerNorms>(entityDatabase);

            await _context.SaveChangesAsync();

            return entityDatabase;
        }

        public async Task Delete(PlayerNorms entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}