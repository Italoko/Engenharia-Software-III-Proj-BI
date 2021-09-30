using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabBimestral.Interface;
using TrabBimestral.Models;

namespace TrabBimestral.Control
{
    public class FreteAControl : ICalculoFrete
    {
        
        public void Calcular(Frete f)
        {
            f.frete = 5;
        }
    }
}
