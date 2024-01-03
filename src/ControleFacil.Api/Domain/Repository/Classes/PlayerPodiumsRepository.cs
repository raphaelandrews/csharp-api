using ControleFacil.Api.Domain.Repository.Interfaces;
using ControleFacil.Api.Data;
using ControleFacil.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleFacil.Api.Domain.Repository.Classes
{
    public class PlayerPodiumsRepository : IPlayerPodiumsRepository
    {
        private readonly ApplicationContext _context;
        public PlayerPodiumsRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PlayerPodiums>> Get()
        {
            return await _context.PlayerPodiums.AsNoTracking()
                                                .OrderBy(u => u.Id)
                                                .ToListAsync();
        }

        public async Task<PlayerPodiums?> Get(long id)
        {
            return await _context.PlayerPodiums.AsNoTracking()
                                .Where(u => u.Id == id)
                                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PlayerPodiums>> GetByUserId(long UserId)
        {
            return await _context.PlayerPodiums.AsNoTracking()
                                                .Where(n => n.UserId == UserId)
                                                .OrderBy(n => n.Id)
                                                .ToListAsync();
        }

        public async Task<PlayerPodiums> Post(PlayerPodiums entity)
        {
            await _context.PlayerPodiums.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<PlayerPodiums> Put(PlayerPodiums entity)
        {
            PlayerPodiums entityDatabase = _context.PlayerPodiums
                .Where(u => u.Id == entity.Id)
                .FirstOrDefault();

            _context.Entry(entityDatabase).CurrentValues.SetValues(entity);
            _context.Update<PlayerPodiums>(entityDatabase);

            await _context.SaveChangesAsync();

            return entityDatabase;
        }

        public async Task Delete(PlayerPodiums entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}