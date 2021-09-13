using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TrabBimestral.Models;

namespace TrabBimestral.DAL
{
    public class ClienteDAO
    {
        private static ClienteDAO _instance;
        MySQLPersistence _bd = new MySQLPersistence();
        private ClienteDAO() {}

        public static ClienteDAO getInstance()
        {
            if (_instance == null)
                _instance = new ClienteDAO();
            return _instance;
        }

        public (int, string) Gravar(Cliente cliente)
        {
            int linhasAfetadas = 0;
            string msg = "";
            try
            {
                string sql = "insert into cliente (nome, cpf, email, senha) values (@nome, @cpf, @email, @senha)";

                _bd.LimparParametros();
                _bd.AdicionarParametro("@nome", cliente.Nome);
                _bd.AdicionarParametro("@cpf", cliente.Cpf);
                _bd.AdicionarParametro("@email", cliente.Email);
                _bd.AdicionarParametro("@senha", cliente.Senha);

                _bd.AbrirConexao();

                linhasAfetadas = _bd.ExecutarNonQuery(sql);
                _bd.FecharConexao();
            }
            catch (Exception ex) { msg = "Não foi possível salvar. Tente novamente"; }
            return (linhasAfetadas, msg);
        }

        public (int, string) Atualizar(Cliente cliente)
        {
            int linhasAfetadas = 0;
            string msg = "";
            try
            {
                string sql = @$"update cliente set nome = @nome, cpf = @cpf,email = @email,senha = @senha where id = @id";

                _bd.LimparParametros();
                _bd.AdicionarParametro("@nome", cliente.Nome);
                _bd.AdicionarParametro("@cpf", cliente.Cpf);
                _bd.AdicionarParametro("@email", cliente.Email);
                _bd.AdicionarParametro("@senha", cliente.Senha);
                _bd.AdicionarParametro("@id", cliente.Id);

                _bd.AbrirConexao();

                linhasAfetadas = _bd.ExecutarNonQuery(sql);
                _bd.FecharConexao();
            }
            catch (Exception ex) { msg = "Não foi possível salvar. Tente novamente"; }
            return (linhasAfetadas, msg);
        }

        public (int, string) Excluir(int id)
        {
            int linhasAfetadas = 0;
            string msg = "";
            try
            {
                string sql = $"delete from cliente where id = '{id}';";
                _bd.AbrirConexao();

                linhasAfetadas = _bd.ExecutarNonQuery(sql);

                _bd.FecharConexao();
            }
            catch (Exception ex)
            {
                msg = "Não foi possível excluir. Tente novamente.";
            }
            return (linhasAfetadas, msg);
        }

        public Cliente ObterPorCPF(string cpf)
        {
            Cliente cli = null;

            string select = $@"select * from cliente  where cpf = '{cpf}'";
            _bd.AbrirConexao();

            DataTable dt = _bd.ExecutarSelect(select);

            if (dt.Rows.Count > 0)
            {
                cli = new Cliente()
                {
                    Id = Convert.ToInt32(dt.Rows[0]["id"]),
                    Nome = dt.Rows[0]["nome"].ToString(),
                    Cpf = dt.Rows[0]["cpf"].ToString(),
                    Email = dt.Rows[0]["email"].ToString(),
                    Senha = dt.Rows[0]["senha"].ToString()
                };
            }
            _bd.FecharConexao();
            return cli;
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            List<Cliente> clientes = new List<Cliente>();

            string select = $@"select * from cliente";
            _bd.AbrirConexao();
            DataTable dt = _bd.ExecutarSelect(select);
            _bd.FecharConexao();

            foreach (DataRow row in dt.Rows)
            {
                var cliente = new Cliente()
                {
                    Id = Convert.ToInt32(row["id"]),
                    Nome = row["nome"].ToString(),
                    Email = row["email"].ToString(),
                    Senha = row["senha"].ToString(),
                    Cpf = row["cpf"].ToString(),
                };
                clientes.Add(cliente);
            }
            return (clientes);
        }
    }
}
