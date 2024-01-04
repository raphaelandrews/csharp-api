using ControleFacil.Api.Domain.Repository.Interfaces;
using ControleFacil.Api.Data;
using ControleFacil.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleFacil.Api.Domain.Repository.Classes
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly ApplicationContext _context;
        public TournamentRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tournament>> Get()
        {
            return await _context.Tournament.AsNoTracking()
                                          .OrderBy(u => u.Id)
                                          .ToListAsync();
        }

        public async Task<Tournament?> Get(long id)
        {
            return await _context.Tournament.AsNoTracking()
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


        public async Task<Tournament> Post(Tournament entity)
        {
            await _context.Tournament.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Tournament> Put(Tournament entity)
        {
            Tournament entityDatabase = _context.Tournament
                .Where(u => u.Id == entity.Id)
                .FirstOrDefault();

            _context.Entry(entityDatabase).CurrentValues.SetValues(entity);
            _context.Update<Tournament>(entityDatabase);

            await _context.SaveChangesAsync();

            return entityDatabase;
        }

        public async Task Delete(Tournament entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}