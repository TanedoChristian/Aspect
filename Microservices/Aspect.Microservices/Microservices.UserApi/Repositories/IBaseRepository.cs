namespace Microservices.UserApi.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);

        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);

    }
}
