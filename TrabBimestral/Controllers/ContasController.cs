using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabBimestral.Controllers
{
    public class ContasController : Controller
    {
        public IActionResult ContasAPagar()
        {
            return View();
        }

        public IActionResult ContasAReceber()
        {
            return View();
        }
    }
}
