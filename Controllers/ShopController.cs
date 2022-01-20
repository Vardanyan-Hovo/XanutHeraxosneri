using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XanutHeraxosneri.Data;
using XanutHeraxosneri.Data.function;
using XanutHeraxosneri.Models;

namespace XanutHeraxosneri.Controllers
{
    public class ShopController : Controller
    {
        private readonly Iapranq Ap;
        private readonly ICart icart;
        public Item item;
        private ApplicationDbContext db;
        public ShopController(Iapranq ap, Item item, ICart cart, ApplicationDbContext db)
        {
            this.item = item;
            this.db = db;
            icart = cart;
            Ap = ap;
        }
        public IActionResult Shoping()
        {
            if (db.ApranqnerDb.Any() && db.CategoryDb.Any())
            {
                //var zx= db.ApranqnerDb.Include(c => c)
                foreach (Apranq x in db.ApranqnerDb.Include(c => c.categoryA))
                {
                    x.idCategory = x.categoryA.Id;
                    db.ApranqnerDb.Update(x);
                }
            }
            db.SaveChanges();

            IEnumerable<Apranq> v = Ap.Apranqner;
            return View(v);
        }


        public async Task<IActionResult> DeleteCart(int idcart)
        {
            if (idcart != 0)
                await icart.DeleteCart(idcart);

            return RedirectToAction("PeoplData", "Baza");
        }



        public async Task<IActionResult> Addproduct(int ide)
        {
            Apranq phone = new Apranq();

            phone = await Ap.SearchAprancId(ide);
            if (phone != null)
            {
                await item.Createphone(phone);
            }
            return RedirectToAction("Shoping");
        }

        public async Task<IActionResult> buy(int idCard)
        {
            Cart Cartphone = new Cart();
            People P = new People();

            Cartphone = icart.SearchCart(idCard);
            var z = item.GetSesionId();
            if (Cartphone != null && z != null)
            {
                foreach (People x in db.PeoplesDb)
                {
                    if (x.session == z)
                    {
                        P = x;
                        var cartpeopl = P.Carts;
                        P.Carts = new List<Cart>();
                        if (cartpeopl != null)
                            P.Carts.AddRange(cartpeopl);
                        P.Carts.Add(Cartphone);
                    }
                }
            }
            db.PeoplesDb.Update(P);
            Order or = new Order()
            {
                img = Cartphone.img,
                Date = DateTime.Now,
                Idcart = Cartphone.Id,
                cart = Cartphone,
                Idpeople = P.Id,
                Peopleorder = P
            };

            await db.ordersDb.AddAsync(or);
            await db.SaveChangesAsync();
            return RedirectToAction("Shoping");
        }


    }
}
