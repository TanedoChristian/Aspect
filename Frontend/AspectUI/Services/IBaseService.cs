namespace AspectUI.Services
{
    public interface IBaseService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById();
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
