using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabBimestral.DAL;
using TrabBimestral.Interface;

namespace TrabBimestral.Models
{
    public class Produto : IProduto
    {
        int _id;
        string _nome;
        int _quantidade;
        Categoria _categoria;
        decimal _precoVenda;
        List<IObserverProduto> _observadores;

        public Produto()
        {
            Id = 0;
            Nome = "";
            Quantidade = 0;
            PrecoVenda = 0;
            Categoria = new Categoria();
            Observadores = new List<IObserverProduto>();
        }

        public Produto(int id, string nome, int quantidade, Categoria categoria, decimal precoVenda)
        {
            Id = id;
            Nome = nome;
            Quantidade = quantidade;
            Categoria = categoria;
            PrecoVenda = precoVenda;
            Observadores = new List<IObserverProduto>();
        }

        public int Id { get => _id; set => _id = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public int Quantidade { get => _quantidade; set => _quantidade = value; }
        public Categoria Categoria { get => _categoria; set => _categoria = value; }
        public decimal PrecoVenda { get => _precoVenda; set => _precoVenda = value; }
        public List<IObserverProduto> Observadores { get => _observadores; set => _observadores = value; }

        public (int,string)Gravar()
        {
            ProdutoDAO pd = ProdutoDAO.getInstance();
            return(_,_)=pd.Gravar(this);
        }
        public (int,string)Atualizar()
        {
            ProdutoDAO pd = ProdutoDAO.getInstance();
            Notify();
            return (_, _) = pd.Atualizar(this);
        }

        public (int,string)Excluir(int id)
        {
            ProdutoDAO pd = ProdutoDAO.getInstance();
            return (_, _) = pd.Excluir(id);
        }
        
        public IEnumerable<Produto> ObterTodos() 
        {
            ProdutoDAO pd = ProdutoDAO.getInstance();
            return  pd.ObterTodos();
        }

        public Produto ObterPorId(int id)
        {
            ProdutoDAO pd = ProdutoDAO.getInstance();
            return pd.ObterPorId(id);
        }

        public void Add(IObserverProduto observer)
        {
            Observadores.Add(observer);
        }

        public void Remove(IObserverProduto observer)
        {
            Observadores.Remove(observer);
        }

        public void Notify()
        {
            if (Quantidade == 0)
            {
                foreach (var item in Observadores)
                    if (Equals(item.GetType(), typeof(Fornecedor)))
                        item.Update();
            } 
            else
                foreach (var item in Observadores)
                        if (Equals(item.GetType(), typeof(Cliente)))
                            item.Update();
        }
    }
}
