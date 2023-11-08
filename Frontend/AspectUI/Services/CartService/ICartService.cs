using AspectUI.Models;

namespace AspectUI.Services.CartService
{
    public interface ICartService : IBaseService<Cart>
    {
        Task<IEnumerable<Cart>> GetAllByUser(int id);
        Task<IEnumerable<Cart>> GetPendingByUser(int id);
    }
}
