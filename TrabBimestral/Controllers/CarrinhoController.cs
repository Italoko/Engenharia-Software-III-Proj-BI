using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabBimestral.Control;

namespace TrabBimestral.Controllers
{
    public class CarrinhoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ObterFrete(double valor)
        {
            double frete = CarrinhoControl.getInstance().calcularFrete(valor);
            return Json(frete);
        }
    }
}
