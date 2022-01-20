using XanutHeraxosneri.Models;

namespace XanutHeraxosneri.Data
{
    public interface ICategory
    {
        public IEnumerable<Category> CategoriAll{ get; }
        public Task AddCategory(Category cat);

    }
}
