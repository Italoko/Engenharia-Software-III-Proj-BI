using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            if(total <= 50)
            {
                return FreteAControl.Calcular();
            }
            else
                return FreteBControl.Calcular();
        }
    }
}
