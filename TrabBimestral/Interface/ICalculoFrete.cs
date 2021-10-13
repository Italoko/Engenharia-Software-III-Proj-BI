using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabBimestral.Models;

namespace TrabBimestral.Interface
{
    public interface ICalculoFrete
    {
        public void Calcular(Frete f, double total);
    }
}
