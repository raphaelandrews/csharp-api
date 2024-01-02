using AutoMapper;
using ControleFacil.Api.Contract.NaturezaDeLancamento;
using ControleFacil.Api.Damain.Models;
using ControleFacil.Api.Damain.Repository.Interfaces;
using ControleFacil.Api.Damain.Services.Interfaces;
using ControleFacil.Api.Exceptions;

namespace ControleFacil.Api.Damain.Services.Classes
{
    public class ApagarService : IService<ApagarRequestContract, ApagarResponseContract, long>
    {
        private readonly IApagarRepository _apagarRepository;
        private readonly IMapper _mapper;

        public ApagarService(
            IApagarRepository apagarRepository,
            IMapper mapper)
        {
            _apagarRepository = apagarRepository;
            _mapper = mapper;
        }

        public async Task<ApagarResponseContract> Post(ApagarRequestContract entidade, long idUser)
        {
            Validar(entidade);

            Apagar Apagar = _mapper.Map<Apagar>(entidade);

            Apagar.DataCadastro = DateTime.Now;
            Apagar.IdUser = idUser;

            // Ter alguma validação para saber se tudo que eu preciso esta no contract.

            Apagar = await _apagarRepository.Post(Apagar);

            return _mapper.Map<ApagarResponseContract>(Apagar);
        }

        public async Task<ApagarResponseContract> Put(long id, ApagarRequestContract entidade, long idUser)
        {
            Validar(entidade);
            
            Apagar apagar = await GetPorIdVinculadoAoIdUser(id, idUser);

            var contract = _mapper.Map<Apagar>(entidade);
            contract.IdUser = apagar.IdUser;
            contract.Id = apagar.Id;
            contract.DataCadastro = apagar.DataCadastro;

            contract = await _apagarRepository.Put(contract);

            return _mapper.Map<ApagarResponseContract>(contract);
        }

        public async Task Inactivation(long id, long idUser)
        {
            Apagar apagar = await GetPorIdVinculadoAoIdUser(id, idUser);

            await _apagarRepository.Deletar(apagar);
        }

        public async Task<IEnumerable<ApagarResponseContract>> Get(long idUser)
        {
            var titulosApagar = await _apagarRepository.GetPeloIdUser(idUser);

            return titulosApagar.Select(titulo => _mapper.Map<ApagarResponseContract>(titulo));
        }

        public async Task<ApagarResponseContract> Get(long id, long idUser)
        {
            Apagar apagar = await GetPorIdVinculadoAoIdUser(id, idUser);
            
            return _mapper.Map<ApagarResponseContract>(apagar);
        }

        private async Task<Apagar> GetPorIdVinculadoAoIdUser(long id, long idUser)
        {
            var apagar = await _apagarRepository.Get(id);

            if (apagar is null || apagar.IdUser != idUser)
            {
                throw new NotFoundException($"Não foi encontrada nenhum titulo apagar pelo id {id}");
            }

            return apagar;
        }

        private void Validar(ApagarRequestContract entidade)
        {
            // Aqui validar varias coisas. 
            if(entidade.ValorOriginal < 0 || entidade.ValorPago < 0) 
            {
                throw new BadRequestException("Os campos ValorOriginal e ValorPago não podem ser negativos.");
            }

        }

    }
}