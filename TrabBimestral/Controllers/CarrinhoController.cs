﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabBimestral.Controllers
{
    public class CarrinhoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
