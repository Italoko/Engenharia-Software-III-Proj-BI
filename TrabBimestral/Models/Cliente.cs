using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabBimestral.DAL;
using TrabBimestral.Interface;

namespace TrabBimestral.Models
{
    public class Cliente : IObserverProduto
    {
        int _id;
        string _nome;
        string _cpf;
        string _email;
        string _senha;
        public Cliente()
        {
            _id = 0;
            _nome = "";
            _cpf = "";
            _email = "";
            _senha = "";
        }

        public Cliente(int id, string nome, string cpf, string email, string senha)
        {
            _id = id;
            _nome = nome;
            _cpf = cpf;
            _email = email;
            _senha = senha;
        }

        public int Id { get => _id; set => _id = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string Cpf { get => _cpf; set => _cpf = value; }
        public string Email { get => _email; set => _email = value; }
        public string Senha { get => _senha; set => _senha = value; }

        public (int, string) Gravar()
        {
            ClienteDAO cd = ClienteDAO.getInstance();
            int registros;
            string msg;
            return (registros, msg) = cd.Gravar(this);
        }

        public (int, string) Atualizar()
        {
            ClienteDAO cd = ClienteDAO.getInstance();
            int registros;
            string msg;
            return (registros, msg) = cd.Atualizar(this);
        }

        public (int, string) Excluir(int id)
        {
            ClienteDAO cd = ClienteDAO.getInstance();
            int registros;
            string msg;
            return (registros, msg) = cd.Excluir(id);
        }
        public IEnumerable<Cliente> ObterTodos()
        {
            ClienteDAO cd = ClienteDAO.getInstance();
            return cd.ObterTodos();
        }
        public Cliente ObterPorCPF(string cpf)
        {
            ClienteDAO cd = ClienteDAO.getInstance();
            return cd.ObterPorCPF(cpf);
        }

        public void Update()
        {
            Console.WriteLine("Chegou o produto que você aguardava ...");
        }
    }
}
