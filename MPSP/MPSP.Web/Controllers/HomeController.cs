using Microsoft.AspNetCore.Mvc;
using MPSP.Search.Jucesp;

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
            var teste = _search.Jucesp();
            return View("Index");
        }
    }
}