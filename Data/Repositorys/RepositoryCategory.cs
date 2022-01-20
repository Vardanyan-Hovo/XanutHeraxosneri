using Microsoft.EntityFrameworkCore;
using XanutHeraxosneri.Models;

namespace XanutHeraxosneri.Data.Repositorys
{
    public class RepositoryCategory : ICategory
    {
        private readonly ApplicationDbContext Db;
        public RepositoryCategory(ApplicationDbContext _db)
        {
            Db = _db;
        }
        public IEnumerable<Category> CategoriAll => Db.CategoryDb.Include(c=>c.Name);

        public async Task AddCategory(Category cat)
        {
           if(cat!=null)
            {
              await  Db.CategoryDb.AddAsync(cat);
            }
        }
    
    
    }
    
}
