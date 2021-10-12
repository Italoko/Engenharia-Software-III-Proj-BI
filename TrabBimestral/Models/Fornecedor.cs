using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabBimestral.DAL;
using TrabBimestral.Interface;

namespace TrabBimestral.Models
{
    public class Fornecedor : IObserverProduto
    {
        int _id;
        string _nome;
        string _cnpj;

        public Fornecedor(int id, string nome, string cnpj)
        {
            Id = id;
            Nome = nome;
            Cnpj = cnpj;
        }

        public Fornecedor()
        {
            Id = 0;
            Nome = "";
            Cnpj = "";
        }

        public int Id { get => _id; set => _id = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string Cnpj { get => _cnpj; set => _cnpj = value; }


        public (int, string) Gravar()
        {
            FornecedorDAO fd = FornecedorDAO.getInstance();
            int registros;
            string msg;
            return (registros, msg) = fd.Gravar(this);
        }

        public (int, string) Atualizar()
        {
            FornecedorDAO fd = FornecedorDAO.getInstance();
            int registros;
            string msg;
            return (registros, msg) = fd.Atualizar(this);
        }

        public (int, string) Excluir(int id)
        {
            FornecedorDAO fd = FornecedorDAO.getInstance();
            int registros;
            string msg;
            return (registros, msg) = fd.Excluir(id);
        }
        public IEnumerable<Fornecedor> ObterTodos()
        {
            FornecedorDAO fd = FornecedorDAO.getInstance();
            return fd.ObterTodos();
        }
        public Fornecedor ObterPorCNPJ(string cnpj)
        {
            FornecedorDAO fd = FornecedorDAO.getInstance();
            return fd.ObterPorCNPJ(cnpj);
        }

        public void Update()
        {
            Console.WriteLine($"Fornecedor:{Nome} Informado sobre o estoque.");
        }
    }
}
