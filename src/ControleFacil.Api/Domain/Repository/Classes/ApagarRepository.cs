using ControleFacil.Api.Damain.Models;
using ControleFacil.Api.Damain.Repository.Interfaces;
using ControleFacil.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleFacil.Api.Damain.Repository.Classes
{
    
    public class ApagarRepository : IApagarRepository
    {

        private readonly ApplicationContext _contexto;

        public ApagarRepository(ApplicationContext context)
        {
            _contexto = context;
        }

        public async Task<Apagar> Post(Apagar entidade)
        {
            await _contexto.Apagar.AddAsync(entidade);
            await _contexto.SaveChangesAsync();

            return entidade;
        }

        public async Task<Apagar> Put(Apagar entidade)
        {
            Apagar entidadeBanco = _contexto.Apagar
                .Where(u => u.Id == entidade.Id)
                .FirstOrDefault();

            _contexto.Entry(entidadeBanco).CurrentValues.SetValues(entidade);
            _contexto.Update<Apagar>(entidadeBanco);

            await _contexto.SaveChangesAsync();
            
            return entidadeBanco;
        }

        public async Task Deletar(Apagar entidade)
        {
            // Deletar logico, só altero a data de inativação.
            entidade.DataInativacao = DateTime.Now;
            await Put(entidade);
        }

        public async Task<IEnumerable<Apagar>> Get()
        {
            return await _contexto.Apagar.AsNoTracking()
                                           .OrderBy(u => u.Id)
                                           .ToListAsync();
        }

        public async Task<Apagar?> Get(long id)
        {
            return await _contexto.Apagar.AsNoTracking()
                                                       .Where(u => u.Id == id)
                                                       .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Apagar>> GetPeloIdUser(long idUser)
        {
            return await _contexto.Apagar.AsNoTracking()
                                                       .Where(n => n.IdUser == idUser)
                                                        .OrderBy(n => n.Id)
                                                        .ToListAsync();
        }
    }
}