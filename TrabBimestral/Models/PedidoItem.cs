using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabBimestral.Models
{
    public class PedidoItem
    {
        int _id;
        int _quantidade;
        decimal _preco;
        decimal _subtotal;
        Produto _produto;

        public PedidoItem()
        {
            Id = 0;
            Quantidade = 0;
            Preco = 0;
            Subtotal = 0;
            Produto = null;
        }

        public int Id { get => _id; set => _id = value; }
        public int Quantidade { get => _quantidade; set => _quantidade = value; }
        public decimal Preco { get => _preco; set => _preco = value; }
        public decimal Subtotal { get => _subtotal; set => _subtotal = value; }
        public Produto Produto { get => _produto; set => _produto = value; }
    }
}
