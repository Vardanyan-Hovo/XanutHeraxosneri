using XanutHeraxosneri.Models;

namespace XanutHeraxosneri.Data.Repositorys
{
    public class RepositoryPeople : IPeople
    {
        private readonly ApplicationDbContext Db;
        public RepositoryPeople(ApplicationDbContext _db)
        {
            Db = _db;
        }


        public Task DeletePeople(int idCart)
        {
            throw new NotImplementedException();
        }

        public Task EditPeople(int idCart)
        {
            throw new NotImplementedException();
        }

        public People SearchPeople(int idCart)
        {
            throw new NotImplementedException();
        }
    }
}
