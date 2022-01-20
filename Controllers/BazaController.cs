using Microsoft.AspNetCore.Mvc;
using XanutHeraxosneri.Data.function;
using XanutHeraxosneri.Models;

namespace XanutHeraxosneri.Controllers
{
    public class BazaController : Controller
    {
       private  ApplicationDbContext Db;
       private readonly Item item;
       public BazaController(ApplicationDbContext db,Item item)
        {
            this.item = item;
            Db = db;
        }



      public IActionResult PeoplData()
        {
          if(ISBuyer)
            {
               List<Cart> cart = new List<Cart>();

                if (item.GetSesionId()!=null)
                {
                  
                   foreach(var v in Db.cartsDb)
                    {
                        if(v.sessionId==item.GetSesionId())
                        {
                            cart.Add(v);    
                        }
                    }
                }
                
                return View(cart);
            }
            return RedirectToAction("Create");
        }


      public static bool ISBuyer = false;//skzbum grancvac chi

      public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
      public async Task< IActionResult> Create(People buyer)//new People()
        {
            People Buyer = new People();
            Buyer = buyer;
            /*  
           if (ModelState.IsValid)
              {
                  ISBuyer = true;


                  Db.PeoplesDb.AddAsync(Buyer);
              }
              */

            ISBuyer = true;
            Buyer.session = item.GetSesionId();

           await Db.PeoplesDb.AddAsync(Buyer);
           await Db.SaveChangesAsync();
            return RedirectToAction("PeoplData");
        }
    }
}