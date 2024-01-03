using ControleFacil.Api.Domain.Repository.Interfaces;
using ControleFacil.Api.Data;
using ControleFacil.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleFacil.Api.Domain.Repository.Classes
{
    public class PlayerTournamentsRepository : IPlayerTournamentsRepository
    {
        private readonly ApplicationContext _context;
        public PlayerTournamentsRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PlayerTournaments>> Get()
        {
            return await _context.PlayerTournaments.AsNoTracking()
                                                .OrderBy(u => u.Id)
                                                .ToListAsync();
        }

        public async Task<PlayerTournaments?> Get(long id)
        {
            return await _context.PlayerTournaments.AsNoTracking()
                                .Where(u => u.Id == id)
                                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PlayerTournaments>> GetByUserId(long UserId)
        {
            return await _context.PlayerTournaments.AsNoTracking()
                                                .Where(n => n.UserId == UserId)
                                                .OrderBy(n => n.Id)
                                                .ToListAsync();
        }

        public async Task<PlayerTournaments> Post(PlayerTournaments entity)
        {
            await _context.PlayerTournaments.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<PlayerTournaments> Put(PlayerTournaments entity)
        {
            PlayerTournaments entityDatabase = _context.PlayerTournaments
                .Where(u => u.Id == entity.Id)
                .FirstOrDefault();

            _context.Entry(entityDatabase).CurrentValues.SetValues(entity);
            _context.Update<PlayerTournaments>(entityDatabase);

            await _context.SaveChangesAsync();

            return entityDatabase;
        }

        public async Task Delete(PlayerTournaments entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}