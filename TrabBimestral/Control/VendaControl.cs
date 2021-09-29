using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabBimestral.Models;

namespace TrabBimestral.Control
{
    public class VendaControl : ComercioControl
    {
        private static VendaControl _instance;
        private VendaControl() { }

        public static VendaControl getInstance()
        {
            if (_instance == null)
                _instance = new VendaControl();
            return _instance;
        }


        override public bool Gravar(Pedido pedido, string cpf)
        {
            bool sucesso = false;
            string msg = "";
            string operacao = "registrado";
            int registros = 0;

            ClienteControl cc = ClienteControl.getInstance();
            Cliente cliente = cc.ObterPorCPF(cpf);

            if (cliente != null)
            {
                Venda venda = new()
                {
                    Cliente = cliente,
                    Pedido = pedido,
                    Total = pedido.Total
                };
                (registros, msg) = venda.Gravar();
            }
            return true;
        }
    }
}
