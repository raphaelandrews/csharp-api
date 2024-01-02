using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ControleFacil.Api.Contract.NaturezaDeLancamento;
using ControleFacil.Api.Damain.Models;
using ControleFacil.Api.Damain.Repository.Interfaces;
using ControleFacil.Api.Damain.Services.Interfaces;
using ControleFacil.Api.Exceptions;

namespace ControleFacil.Api.Damain.Services.Classes
{
    public class NaturezaDeLancamentoService : IService<NaturezaDeLancamentoRequestContract, NaturezaDeLancamentoResponseContract, long>
    {
        private readonly INaturezaDeLancamentoRepository _naturezaDeLancamentoRepository;
        private readonly IMapper _mapper;

        public NaturezaDeLancamentoService(
            INaturezaDeLancamentoRepository naturezaDeLancamentoRepository,
            IMapper mapper)
        {
            _naturezaDeLancamentoRepository = naturezaDeLancamentoRepository;
            _mapper = mapper;
        }

        public async Task<NaturezaDeLancamentoResponseContract> Post(NaturezaDeLancamentoRequestContract entidade, long idUser)
        {
            NaturezaDeLancamento naturezaDeLancamento = _mapper.Map<NaturezaDeLancamento>(entidade);

            naturezaDeLancamento.DataCadastro = DateTime.Now;
            naturezaDeLancamento.IdUser = idUser;

            naturezaDeLancamento = await _naturezaDeLancamentoRepository.Post(naturezaDeLancamento);

            return _mapper.Map<NaturezaDeLancamentoResponseContract>(naturezaDeLancamento);
        }

        public async Task<NaturezaDeLancamentoResponseContract> Put(long id, NaturezaDeLancamentoRequestContract entidade, long idUser)
        {
            NaturezaDeLancamento naturezaDeLancamento = await GetPorIdVinculadoAoIdUser(id, idUser);

            naturezaDeLancamento.Descricao = entidade.Descricao;
            naturezaDeLancamento.Observacao = entidade.Observacao;

            naturezaDeLancamento = await _naturezaDeLancamentoRepository.Put(naturezaDeLancamento);

            return _mapper.Map<NaturezaDeLancamentoResponseContract>(naturezaDeLancamento);
        }

        public async Task Inactivation(long id, long idUser)
        {
            NaturezaDeLancamento naturezaDeLancamento = await GetPorIdVinculadoAoIdUser(id, idUser);

            await _naturezaDeLancamentoRepository.Deletar(naturezaDeLancamento);
        }

        public async Task<IEnumerable<NaturezaDeLancamentoResponseContract>> Get(long idUser)
        {
            var naturezasDelancamento = await _naturezaDeLancamentoRepository.GetPeloIdUser(idUser);
            return naturezasDelancamento.Select(natureza => _mapper.Map<NaturezaDeLancamentoResponseContract>(natureza));
        }

        public async Task<NaturezaDeLancamentoResponseContract> Get(long id, long idUser)
        {
            NaturezaDeLancamento naturezaDeLancamento = await GetPorIdVinculadoAoIdUser(id, idUser);
            
            return _mapper.Map<NaturezaDeLancamentoResponseContract>(naturezaDeLancamento);
        }

        private async Task<NaturezaDeLancamento> GetPorIdVinculadoAoIdUser(long id, long idUser)
        {
            var naturezaDeLancamento = await _naturezaDeLancamentoRepository.Get(id);

            if (naturezaDeLancamento is null || naturezaDeLancamento.IdUser != idUser)
            {
                throw new NotFoundException($"Não foi encontrada nenhuma natureza de lançamento pelo id {id}");
            }

            return naturezaDeLancamento;
        }

    }
}