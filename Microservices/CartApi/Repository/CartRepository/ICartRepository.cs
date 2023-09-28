using CartApi.Entities;

namespace CartApi.Repository.CartRepository
{
    public interface ICartRepository : IBaseRepository<Cart>
    {
        Task<IEnumerable<Cart>> GetByUserId(int id);
    }
}
