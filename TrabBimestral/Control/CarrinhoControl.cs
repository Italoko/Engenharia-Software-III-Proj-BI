using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabBimestral.Models;

namespace TrabBimestral.Control
{
    public class CarrinhoControl
    {
        private static CarrinhoControl _instance;
        private CarrinhoControl() { }
        public static CarrinhoControl getInstance()
        {
            if (_instance == null)
                _instance = new CarrinhoControl();
            return _instance;
        }

        public double calcularFrete(double total)
        {
            Frete f = new Frete();
                var frete = new FreteAControl();
                frete.Calcular(f, total);
            return f.frete;
        }
    }
}
