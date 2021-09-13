using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabBimestral.Models;

namespace TrabBimestral.Control
{
    public class ClienteControl
    {
       private static ClienteControl _instance;
       private ClienteControl(){}

        public static ClienteControl getInstance()
        {
            if (_instance == null)
                _instance = new ClienteControl();
            return _instance;
        }

        public (Cliente, bool, string) Gravar(int id,string nome,string cpf, string email,string senha)
        {
            bool sucesso = false;
            string msg = "";
            string operacao = "registrado";
            int registros = 0;
           
            Cliente cliente = new Cliente(id,nome,cpf,email,senha);
            if (cliente.Id == 0)
                (registros, msg) = cliente.Gravar();
            else
            {
                (registros, msg) = cliente.Atualizar();
                operacao = "alterado";
            }

            if (registros > 0)
            {
                sucesso = true;
                msg = $"{cliente.Nome} {operacao} com sucesso.";
            }
            return (cliente, sucesso, msg);
        }

        public (bool, string) Excluir(int id)
        {
            Cliente cli = new();
            bool sucesso = false;
            string msg = "Id inválido";
            int registros = 0;

            if (id > 0)
            {
                (registros, msg) = cli.Excluir(id);
                if (registros > 0)
                {
                    msg = "Produto excluído com sucesso";
                    sucesso = true;
                }
            }
            return (sucesso, msg);
        }

        public (IEnumerable<Cliente>, string) ObterTodos()
        {
            string msg = "";
            Cliente cli = new();
            IEnumerable<Cliente> clientes;
            clientes = cli.ObterTodos();

            if (clientes.ToList().Count == 0)
                msg = "Não ha produtos para listar";

            return (clientes, msg);
        }

        public Cliente ObterPorCPF(string cpf)
        {
            Cliente cli = new();
            return cli.ObterPorCPF(cpf);
        }
    }
}
