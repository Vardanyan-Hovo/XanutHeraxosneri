using XanutHeraxosneri.Models;

namespace XanutHeraxosneri.Data.Repositorys
{
    public class RepositoryCart:ICart
    {
        private readonly ApplicationDbContext Db;
        public RepositoryCart(ApplicationDbContext _db)
        {
            Db = _db;
        }

        public async Task DeleteCart(int idCart)
        {
            Cart result = new Cart();

           result= SearchCart(idCart);
              if (result!=null)
                Db.cartsDb.Remove(result);
           await Db.SaveChangesAsync();
        }




        public Cart SearchCart(int idCart)
        {
            Cart result = new Cart();


            if (idCart != 0)
            {
                foreach (Cart x in Db.cartsDb)
                {
                    if (x.Id == idCart)
                        result = x;
                }
            }
            if (result != null)
                return result;

            return null;
        }
    }
}
