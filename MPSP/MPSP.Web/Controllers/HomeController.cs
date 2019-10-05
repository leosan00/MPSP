using Microsoft.AspNetCore.Mvc;
using s =MPSP.Search.Siel;
using j = MPSP.Search.Jucesp;
using m = MPSP.Model.Search;
using p = MPSP.Persistency.Repositories;

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

        public IActionResult Jucesp()
        {            
            var obj = _searchJu.Jucesp();
			if (obj != null)
			{
				ViewBag.Msg = true;
			}
			return RedirectToAction("Index", "Home");
        }

		public IActionResult Siel()
		{
			var obj = _searchSi.Siel();
			if(obj != null)
			{
				ViewBag.Msg= true;
			}
			return RedirectToAction("Relatorio", "Siel");
		}

	
    }
}