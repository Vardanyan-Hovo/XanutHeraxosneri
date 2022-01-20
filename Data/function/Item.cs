using Microsoft.EntityFrameworkCore;
using XanutHeraxosneri.Models;

namespace XanutHeraxosneri.Data.function
{
    public class Item
    {
        public readonly ApplicationDbContext Db;
        public Item(ApplicationDbContext db)
        {
            Db = db;
        }
        public  string SesionId { get; set; } 
        public IEnumerable<Cart> Carts { get; set; }
       
      public static Item Items(IServiceProvider services)
        {
            Console.WriteLine("\n\n\n<<<<<<\n\n\n\n\n");
            ISession session = services.GetService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<ApplicationDbContext>();
            string shopcartid = session.GetString("newshop") ?? Guid.NewGuid().ToString();

            session.SetString("newshop", shopcartid);
            Console.WriteLine($"\n\n\n shopcartid== {shopcartid}\n\n\n");

            return new Item(context) { SesionId = shopcartid };
        }

        public async Task Createphone(Apranq a)
        {
            Console.WriteLine($"\n\n\n SesionId== {SesionId} \n\n\n");
            Category z=new Category();
            foreach (var x in Db.CategoryDb)
                if (x == a.categoryA)
                  z = x;

           DateTime s=DateTime.Now;
            Db.cartsDb.Add(new Cart
            {
                CategoryId=z.Id,
                CategoryName = z.Name,
                ApranqName = a.Name,
                Price = (int)a.Price,
                sessionId = SesionId,
                CardsessionTime = s,
                Apranq = a,
                IdApranq = a.Id,
                img = a.img,
            }); 
          await  Db.SaveChangesAsync();
        }
        public string GetSesionId()
        {
            return SesionId;
        }

        public List<Cart> GetShoping()
        {
            return Db.cartsDb.Where(c=>c.sessionId == SesionId).Include(p => p.Apranq).ToList();
        }


    }
}
