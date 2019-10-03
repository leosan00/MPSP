using Microsoft.AspNetCore.Mvc;
using s=MPSP.Search.Siel;
using j = MPSP.Search.Jucesp;
using m = MPSP.Model.Search;

namespace MPSP.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly j.ISearch _searchJu;
		private readonly s.ISearch _searchSi;
        public HomeController(j.ISearch searchJu, s.ISearch searchSi)
        {
            _searchJu = searchJu;
			_searchSi = searchSi;
		}
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult InfoCrim()
        {            
            var obj = _searchJu.Jucesp();
            return RedirectToAction("Jucesp",obj);

			
        }

		public IActionResult InfoCrimSiel()
		{
			var obj = _searchSi.Siel();
			return RedirectToAction("Siel", obj);
		}

        public IActionResult Jucesp(m.Jucesp obj)
        {
            return View(obj);
        }

		public IActionResult Siel(m.Siel siel)
		{
			return View(siel);
		}
    }
}