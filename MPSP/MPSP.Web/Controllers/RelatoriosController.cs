using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using p = MPSP.Persistency.Repositories;
using MPSP.Model.Search;

namespace MPSP.Web.Controllers
{
	public class RelatoriosController : Controller
	{

		private p.IJucespRepository _jucespRepository;
		private p.ISielRepository _sielRepository;

		public RelatoriosController(p.IJucespRepository jucespRepository, p.ISielRepository sielRepository)
		{
			_jucespRepository = jucespRepository;
			_sielRepository = sielRepository;
		}

		public IActionResult Index()
		{
			List<Jucesp> lstJucesp = new List<Jucesp>();
			lstJucesp = _jucespRepository.GetAll().ToList();
			ViewBag.ListaJucesp = lstJucesp;


			List<Siel> lstSiel = new List<Siel>();
			lstSiel = _sielRepository.GetAll().ToList();
			ViewBag.ListaSiel = lstSiel;


			return View();
		}

		
		public ActionResult Siel()
		{
			return View();
		}

	}
}