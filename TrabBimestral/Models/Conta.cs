using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabBimestral.DAL;

namespace TrabBimestral.Models
{
    public class Conta
    {
        int _id;
        string _nome;
        DateTime _dataVencimento;
        decimal valor;

        public Conta()
        {
            Id = 0;
            Nome = "";
            DataVencimento = DateTime.Now;
            Valor = 0;
        }
        public Conta(int id, string nome, DateTime dataVencimento, decimal valor)
        {
            Id = id;
            Nome = nome;
            DataVencimento = dataVencimento;
            this.Valor = valor;
        }

        public int Id { get => _id; set => _id = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public DateTime DataVencimento { get => _dataVencimento; set => _dataVencimento = value; }
        public decimal Valor { get => valor; set => valor = value; }

        public (int, string) Gravar()
        {
            ContaDAO cd = ContaDAO.getInstance();
            int registros;
            string msg;
            return (registros, msg) = cd.Gravar(this);
        }

        public (int, string) Atualizar()
        {
            ContaDAO cd = ContaDAO.getInstance();
            int registros;
            string msg;
            return (registros, msg) = cd.Atualizar(this);
        }

        public (int, string) Excluir(int id)
        {
            ContaDAO cd = ContaDAO.getInstance();
            int registros;
            string msg;
            return (registros, msg) = cd.Excluir(id);
        }
        public IEnumerable<Conta> ObterTodos(string filtro)
        {
            ContaDAO cd = ContaDAO.getInstance();
            if (String.IsNullOrEmpty(filtro))
                return cd.ObterTodos();
            return cd.ObterTodos(filtro);
        }
    }
}
