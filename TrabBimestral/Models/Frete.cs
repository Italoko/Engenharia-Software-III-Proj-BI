using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabBimestral.Models
{
    public class Frete
    {
        double _frete;


        public Frete()
        {
            _frete = 0;
        }

        public double frete { get => _frete; set => _frete = value; }
    }
}
