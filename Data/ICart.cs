using XanutHeraxosneri.Models;

namespace XanutHeraxosneri.Data
{
    public interface ICart
    {
        public Task DeleteCart(int idCart);
        public Cart SearchCart(int idCart);
    }
}
