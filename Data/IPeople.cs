using XanutHeraxosneri.Models;

namespace XanutHeraxosneri.Data
{
    public interface IPeople
    {
        public Task DeletePeople(int idCart);
        public People SearchPeople(int idCart);
        public Task EditPeople(int idCart);
    }
}
