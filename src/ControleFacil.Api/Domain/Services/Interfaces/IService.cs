namespace ControleFacil.Api.Domain.Services.Interfaces
{

    /// <summary>
    ///Interface genérica para criação de serviços do tipo CRUD.
    /// </summary>
    /// <typeparam name="RQ">Contrato de request</typeparam>
    /// <typeparam name="RS">Contrato de response</typeparam>
    /// <typeparam name="I">Tipo do Id</typeparam>
    public interface IService<RQ, RS, I> where RQ : class
    {
        Task<IEnumerable<RS>> Get(I idUser);
        Task<RS> Get(I id, I idUser);
        Task<RS> Post(RQ entidade, I idUser);
        Task<RS> Put(I id, RQ entidade, I idUser);
        Task Inactivation(I id, I idUser);
    }
}