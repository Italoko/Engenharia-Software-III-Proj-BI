using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TrabBimestral.Models;

namespace TrabBimestral.DAL
{
    public class ContaDAO
    {
        private static ContaDAO _instance;
        MySQLPersistence _bd = new MySQLPersistence();
        private ContaDAO() { }

        public static ContaDAO getInstance()
        {
            if (_instance == null)
                _instance = new ContaDAO();
            return _instance;
        }

        public (int, string) Gravar(Conta conta)
        {
            int linhasAfetadas = 0;
            string msg = "";
            try
            {
                string sql = "insert into conta (nome, dataVencimento, valor) values (@nome, @dataVencimento, @valor)";

                _bd.LimparParametros();
                _bd.AdicionarParametro("@nome", conta.Nome);
                _bd.AdicionarParametro("@dataVencimento", conta.DataVencimento);
                _bd.AdicionarParametro("@valor", conta.Valor);

                _bd.AbrirConexao();

                linhasAfetadas = _bd.ExecutarNonQuery(sql);
                _bd.FecharConexao();
            }
            catch (Exception ex) { msg = "Não foi possível salvar. Tente novamente"; }
            return (linhasAfetadas, msg);
        }

        public (int, string) Atualizar(Conta conta)
        {
            int linhasAfetadas = 0;
            string msg = "";
            try
            {
                string sql = @"update conta set nome = @nome, dataVencimento = @dataVencimento,valor = @valor where id = @id";

                _bd.LimparParametros();
                _bd.AdicionarParametro("@nome", conta.Nome);
                _bd.AdicionarParametro("@dataVencimento", conta.DataVencimento);
                _bd.AdicionarParametro("@valor", conta.Valor);
                _bd.AdicionarParametro("@id", conta.Id);

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
                string sql = $"delete from conta where id = '{id}';";
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

        public IEnumerable<Conta> ObterTodos()
        {
            List<Conta> contas = new List<Conta>();

            string select = $@"select * from conta";
            _bd.AbrirConexao();
            DataTable dt = _bd.ExecutarSelect(select);
            _bd.FecharConexao();

            foreach (DataRow row in dt.Rows)
            {
                var conta = new Conta()
                {
                    Id = Convert.ToInt32(row["id"]),
                    Nome = row["nome"].ToString(),
                    DataVencimento = Convert.ToDateTime(row["dataVencimento"]),
                    Valor = Convert.ToDecimal(row["valor"])
                };
                contas.Add(conta);
            }
            return contas;
        }

        public IEnumerable<Conta> ObterTodos(string filtro)
        {
            List<Conta> contas = new List<Conta>();
            string select = $@"select * from conta where nome like '%{filtro}%'";
            _bd.AbrirConexao();
            DataTable dt = _bd.ExecutarSelect(select);
            _bd.FecharConexao();

            foreach (DataRow row in dt.Rows)
            {
                var conta = new Conta()
                {
                    Id = Convert.ToInt32(row["id"]),
                    Nome = row["nome"].ToString(),
                    DataVencimento = Convert.ToDateTime(row["dataVencimento"]),
                    Valor = Convert.ToDecimal(row["valor"])
                };
                contas.Add(conta);
            }
            return contas;
        }
    }
}
