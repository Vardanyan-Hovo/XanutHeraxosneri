using Microsoft.AspNetCore.Mvc;
using XanutHeraxosneri.Data;
using XanutHeraxosneri.Models;


namespace XanutHeraxosneri.Controllers
{
    public class HomeController : Controller
    {
        private readonly Iapranq Ap;
        public HomeController(Iapranq ap)
        {
            Ap = ap;
        }
 
        public IActionResult Index()
        {
            IEnumerable<Apranq> s = Ap.IsFavorit;
            return View(s);
        }


        public IActionResult Privacy()
        {
      
            return View();
        }
    }
}