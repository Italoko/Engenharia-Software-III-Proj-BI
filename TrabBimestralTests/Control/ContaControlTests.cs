using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrabBimestral.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabBimestral.Models;

namespace TrabBimestral.Control.Tests
{
    [TestClass()]
    public class ContaControlTests
    {
        bool sucesso = false;
        string msg = "";
        Conta conta;
        ContaControl contaCtrl = ContaControl.getInstance();
        

        [TestMethod()]
        public void GravarTest()
        {
            //DateTime dt = new DateTime(2021, 10, 05);
            //(conta, sucesso, msg) = contaCtrl.Gravar(4, "SERVIÇO Y",dt,2500);
            string filtro = "";
            IEnumerable<Conta> cts;
            (cts,msg) = contaCtrl.ObterTodos("x");

            if (cts.Count() > 0)
                sucesso = true;

            Assert.IsTrue(sucesso);
            if (sucesso)
                sucesso = false;
        }
    }
}