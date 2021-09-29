using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabBimestral.Models
{
    public class Pedido
    {
        int _id;
        List<PedidoItem> _itens;
        decimal _total;
        public Pedido(){ }
        
        public int Id { get => _id; set => _id = value; }
        public List<PedidoItem> Itens { get => _itens; set => _itens = value; }
        public decimal Total { get => _total; set => _total = value; }
    }
}
