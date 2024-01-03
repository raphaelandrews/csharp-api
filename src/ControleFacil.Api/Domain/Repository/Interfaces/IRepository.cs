namespace ControleFacil.Api.Domain.Repository.Interfaces
{
    public interface IRepository<T, I> where T : class
    {
        Task<IEnumerable<T>> Get();
        Task<T?> Get(I id);

        Task<T> Post(T entity);

        Task<T> Put(T entity);

        Task Delete(T entity);
    }
}