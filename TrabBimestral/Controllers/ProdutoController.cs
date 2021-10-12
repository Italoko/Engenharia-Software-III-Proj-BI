using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabBimestral.Control;
using TrabBimestral.Models;

namespace TrabBimestral.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Listagem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Gravar([FromBody] System.Text.Json.JsonElement dados)
        {
            bool sucesso = false;
            string msg = "";
            Produto produto;
            ProdutoControl pc = ProdutoControl.getInstance();
            
            (produto,sucesso,msg) = pc.Gravar(dados);
           
            var retorno = new
            {
                sucesso = sucesso,
                msg = msg,
                produtoId = produto.Id
            };
            return Json(retorno);
        }


        [HttpGet]
        public IActionResult ObterProdutos()
        {
            IEnumerable<Produto> produtos;
            string msg;
            (produtos, msg) = ProdutoControl.getInstance().ObterTodos();
            var retorno = new
            {
                produtos,
                msg
            };
            return Json(retorno);
        }
    }
}
