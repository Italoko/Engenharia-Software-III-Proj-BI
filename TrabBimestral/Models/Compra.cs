using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabBimestral.DAL;

namespace TrabBimestral.Models
{
    public class Compra
    {
        int _id;
        Fornecedor _fornecedor;
        Pedido _pedido;
        decimal _total;

        public Compra()
        {
            Id = 0;
            Fornecedor = null;
            Pedido = null;
            Total = 0;
        }

        public int Id { get => _id; set => _id = value; }
        public Fornecedor Fornecedor { get => _fornecedor; set => _fornecedor = value; }
        public Pedido Pedido { get => _pedido; set => _pedido = value; }
        public decimal Total { get => _total; set => _total = value; }


        public (int, string) Gravar()
        {
            CompraDAO cd = CompraDAO.getInstance();
            int registros;
            string msg;
            return (registros, msg) = cd.Gravar(this);
        }

    }
}
