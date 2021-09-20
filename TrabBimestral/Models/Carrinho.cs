using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabBimestral.Models
{
    public class Carrinho
    {
        List<Produto> _produtos;
        double _valorTotal;

        public Carrinho()
        {
            _produtos = new List<Produto>();
            _valorTotal = 0;
        }

        public List<Produto> produtos { get => _produtos; set => _produtos = value; }
        public double valorTotal { get => _valorTotal; set => _valorTotal = value; }
    }
}
