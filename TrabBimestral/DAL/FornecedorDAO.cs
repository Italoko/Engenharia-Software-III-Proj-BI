using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TrabBimestral.Models;

namespace TrabBimestral.DAL
{
    public class FornecedorDAO
    {
        private static FornecedorDAO _instance;
        MySQLPersistence _bd = new MySQLPersistence();
        private FornecedorDAO() { }

        public static FornecedorDAO getInstance()
        {
            if (_instance == null)
                _instance = new FornecedorDAO();
            return _instance;
        }

        public (int, string) Gravar(Fornecedor fornecedor)
        {
            int linhasAfetadas = 0;
            string msg = "";
            try
            {
                string sql = "insert into fornecedor (nome, cnpj) values (@nome, @cnpj)";

                _bd.LimparParametros();
                _bd.AdicionarParametro("@nome", fornecedor.Nome);
                _bd.AdicionarParametro("@cnpj", fornecedor.Cnpj);

                _bd.AbrirConexao();

                linhasAfetadas = _bd.ExecutarNonQuery(sql);
                _bd.FecharConexao();
            }
            catch (Exception ex) { msg = "Não foi possível salvar. Tente novamente"; }
            return (linhasAfetadas, msg);
        }

        public (int, string) Atualizar(Fornecedor fornecedor)
        {
            int linhasAfetadas = 0;
            string msg = "";
            try
            {
                string sql = @$"update fornecedor set nome = @nome, cnpj = @cnpj where id = @id";

                _bd.LimparParametros();
                _bd.AdicionarParametro("@nome", fornecedor.Nome);
                _bd.AdicionarParametro("@cnpj", fornecedor.Cnpj);
                _bd.AdicionarParametro("@id", fornecedor.Id);

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
                string sql = $"delete from fornecedor where id = '{id}';";
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

        public Fornecedor ObterPorCNPJ(string cnpj)
        {
            Fornecedor fornecedor = null;

            string select = $@"select * from fornecedor  where cnpj = '{cnpj}'";
            _bd.AbrirConexao();

            DataTable dt = _bd.ExecutarSelect(select);

            if (dt.Rows.Count > 0)
            {
                fornecedor = new Fornecedor()
                {
                    Id = Convert.ToInt32(dt.Rows[0]["id"]),
                    Nome = dt.Rows[0]["nome"].ToString(),
                    Cnpj = dt.Rows[0]["cnpj"].ToString()
                };
            }
            _bd.FecharConexao();
            return fornecedor;
        }

        public IEnumerable<Fornecedor> ObterTodos()
        {
            List<Fornecedor> fornecedores = new List<Fornecedor>();

            string select = $@"select * from fornecedor";
            _bd.AbrirConexao();
            DataTable dt = _bd.ExecutarSelect(select);
            _bd.FecharConexao();

            foreach (DataRow row in dt.Rows)
            {
                var fornecedor = new Fornecedor()
                {
                    Id = Convert.ToInt32(row["id"]),
                    Nome = row["nome"].ToString(),
                    Cnpj = row["cnpj"].ToString()
                };
                fornecedores.Add(fornecedor);
            }
            return (fornecedores);
        }
    }
}
