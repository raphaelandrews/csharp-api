using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleFacil.Api.Damain.Models;
using ControleFacil.Api.Damain.Repository.Interfaces;
using ControleFacil.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleFacil.Api.Damain.Repository.Classes
{
    
    public class NaturezaDeLancamentoRepository : INaturezaDeLancamentoRepository
    {

        private readonly ApplicationContext _contexto;

        public NaturezaDeLancamentoRepository(ApplicationContext context)
        {
            _contexto = context;
        }

        public async Task<NaturezaDeLancamento> Post(NaturezaDeLancamento entidade)
        {
            await _contexto.NaturezaDeLancamento.AddAsync(entidade);
            await _contexto.SaveChangesAsync();

            return entidade;
        }

        public async Task<NaturezaDeLancamento> Put(NaturezaDeLancamento entidade)
        {
            NaturezaDeLancamento entidadeBanco = _contexto.NaturezaDeLancamento
                .Where(u => u.Id == entidade.Id)
                .FirstOrDefault();

            _contexto.Entry(entidadeBanco).CurrentValues.SetValues(entidade);
            _contexto.Update<NaturezaDeLancamento>(entidadeBanco);

            await _contexto.SaveChangesAsync();
            
            return entidadeBanco;
        }

        public async Task Deletar(NaturezaDeLancamento entidade)
        {
            // Deletar logico, só altero a data de inativação.
            entidade.DataInativacao = DateTime.Now;
            await Put(entidade);
        }

        public async Task<IEnumerable<NaturezaDeLancamento>> Get()
        {
            return await _contexto.NaturezaDeLancamento.AsNoTracking()
                                           .OrderBy(u => u.Id)
                                           .ToListAsync();
        }

        public async Task<NaturezaDeLancamento?> Get(long id)
        {
            return await _contexto.NaturezaDeLancamento.AsNoTracking()
                                                       .Where(u => u.Id == id)
                                                       .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<NaturezaDeLancamento>> GetPeloIdUser(long idUser)
        {
            return await _contexto.NaturezaDeLancamento.AsNoTracking()
                                                       .Where(n => n.IdUser == idUser)
                                                        .OrderBy(n => n.Id)
                                                        .ToListAsync();
        }
    }
}