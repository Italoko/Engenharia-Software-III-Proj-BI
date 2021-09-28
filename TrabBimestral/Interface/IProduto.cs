using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabBimestral.Interface
{
    public interface IProduto
    {
        void add(IObserverProduto op);
        void remove(IObserverProduto op);
        void notify();
    }
}
