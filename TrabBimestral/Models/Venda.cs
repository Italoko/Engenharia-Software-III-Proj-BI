using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabBimestral.Models
{
    public class Venda
    {
        int _id;
        Cliente _cliente;
        Pedido _pedido;
        decimal _total;

        public Venda()
        {
            Id = 0;
            Cliente = null;
            Pedido = null;
            Total = 0;
        }

        public int Id { get => _id; set => _id = value; }
        public Cliente Cliente { get => _cliente; set => _cliente = value; }
        public Pedido Pedido { get => _pedido; set => _pedido = value; }
        public decimal Total { get => _total; set => _total = value; }

        public (int, string) Gravar()
        {
            //VendaDAO vd = VendaDAO.getInstance();
            int registros;
            string msg;
            return (registros, msg) = vd.Gravar(this);
        }
    }
}
