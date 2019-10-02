using Microsoft.AspNetCore.Mvc;
using MPSP.Search.Jucesp;
using m = MPSP.Model.Search;

namespace MPSP.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISearch _search;
        public HomeController(ISearch search)
        {
            _search = search;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult InfoCrim()
        {            
            var obj = _search.Jucesp();
            return RedirectToAction("Jucesp",obj);
        }

        public IActionResult Jucesp(m.Jucesp obj)
        {
            return View(obj);
        }
    }
}