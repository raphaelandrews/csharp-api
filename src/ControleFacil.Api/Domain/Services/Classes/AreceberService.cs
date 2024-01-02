using AutoMapper;
using ControleFacil.Api.Contract.NaturezaDeLancamento;
using ControleFacil.Api.Damain.Models;
using ControleFacil.Api.Damain.Repository.Interfaces;
using ControleFacil.Api.Damain.Services.Interfaces;
using ControleFacil.Api.Exceptions;

namespace ControleFacil.Api.Damain.Services.Classes
{
    public class AreceberService : IService<AreceberRequestContract, AreceberResponseContract, long>
    {
        private readonly IAreceberRepository _areceberRepository;
        private readonly IMapper _mapper;

        public AreceberService(
            IAreceberRepository areceberRepository,
            IMapper mapper)
        {
            _areceberRepository = areceberRepository;
            _mapper = mapper;
        }

        public async Task<AreceberResponseContract> Post(AreceberRequestContract entidade, long idUser)
        {
            Validar(entidade);

            Areceber areceber = _mapper.Map<Areceber>(entidade);

            areceber.DataCadastro = DateTime.Now;
            areceber.IdUser = idUser;

            areceber = await _areceberRepository.Post(areceber);

            return _mapper.Map<AreceberResponseContract>(areceber);
        }

        public async Task<AreceberResponseContract> Put(long id, AreceberRequestContract entidade, long idUser)
        {
            Validar(entidade);

            Areceber Areceber = await GetPorIdVinculadoAoIdUser(id, idUser);

            var contract = _mapper.Map<Areceber>(entidade);

            contract.IdUser = Areceber.IdUser;
            contract.Id = Areceber.Id;
            contract.DataCadastro = Areceber.DataCadastro;

            contract = await _areceberRepository.Put(contract);

            return _mapper.Map<AreceberResponseContract>(contract);
        }

        public async Task Inactivation(long id, long idUser)
        {
            Areceber areceber = await GetPorIdVinculadoAoIdUser(id, idUser);

            await _areceberRepository.Deletar(areceber);
        }

        public async Task<IEnumerable<AreceberResponseContract>> Get(long idUser)
        {
            var titulosAreceber = await _areceberRepository.GetPeloIdUser(idUser);

            return titulosAreceber.Select(titulo => _mapper.Map<AreceberResponseContract>(titulo));
        }

        public async Task<AreceberResponseContract> Get(long id, long idUser)
        {
            Areceber areceber = await GetPorIdVinculadoAoIdUser(id, idUser);
            
            return _mapper.Map<AreceberResponseContract>(areceber);
        }

        private async Task<Areceber> GetPorIdVinculadoAoIdUser(long id, long idUser)
        {
            var areceber = await _areceberRepository.Get(id);

            if (areceber is null || areceber.IdUser != idUser)
            {
                throw new NotFoundException($"Não foi encontrada nenhum titulo Areceber pelo id {id}");
            }

            return areceber;
        }

        private void Validar(AreceberRequestContract entidade)
        {
            // Aqui validar varias coisas. 
            if(entidade.ValorOriginal < 0 || entidade.ValorRecebido < 0) 
            {
                throw new BadRequestException("Os campos ValorOriginal e ValorRecebimento não podem ser negativos.");
            }

        }

    }
}