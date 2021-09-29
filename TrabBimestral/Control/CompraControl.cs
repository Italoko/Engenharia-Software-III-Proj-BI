using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabBimestral.Models;

namespace TrabBimestral.Control
{
    public class CompraControl : ComercioControl
    {
        private static CompraControl _instance;
        private CompraControl() { }

        public static CompraControl getInstance()
        {
            if (_instance == null)
                _instance = new CompraControl();
            return _instance;
        }

        override public bool Gravar(Pedido pedido,string cnpj)
        {
            bool sucesso = false;
            string msg = "";
            string operacao = "registrado";
            int registros = 0;

            FornecedorControl fc = FornecedorControl.getInstance();
            Fornecedor fornecedor = fc.ObterPorCNPJ(cnpj);

            if (fornecedor != null)
            {
                Compra compra = new()
                {
                    Fornecedor = fornecedor,
                    Pedido = pedido,
                    Total = pedido.Total
                };
                (registros, msg) = compra.Gravar();
            }
            return true;
        }
    }
}
