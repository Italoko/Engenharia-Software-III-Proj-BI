using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabBimestral.Interface
{
    public interface IProduto
    {
        void Add(IObserverProduto op);
        void Remove(IObserverProduto op);
        void Notify();
    }
}
