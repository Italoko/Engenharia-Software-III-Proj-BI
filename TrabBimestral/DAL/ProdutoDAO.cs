using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TrabBimestral.Models;

namespace TrabBimestral.DAL
{
    public class ProdutoDAO
    {
        MySQLPersistence _bd = new MySQLPersistence();
        private static ProdutoDAO instance;
        private ProdutoDAO() { }
        public static ProdutoDAO getInstance()
        {
            if (instance == null)
                instance = new ProdutoDAO();
            return instance;
        }

        public (int, string) Gravar(Produto produto)
        {
            int linhas = 0;
            string msg = "";

            try
            {
                string sql = "insert into produto (nome, categoria, quantidade, precovenda)" +
                "values (@nome, @categoria, @quantidade, @precovenda)";

                _bd.LimparParametros();
                _bd.AdicionarParametro("@nome", produto.Nome);
                _bd.AdicionarParametro("@categoria", produto.Categoria.Id);
                _bd.AdicionarParametro("@quantidade", produto.Quantidade);
                _bd.AdicionarParametro("@precovenda", produto.PrecoVenda);

                _bd.AbrirConexao();
                linhas = _bd.ExecutarNonQuery(sql);
                if (linhas > 0)
                    produto.Id = _bd.UltimoId;
                _bd.FecharConexao();
            }
            catch (Exception ex)
            {
                msg = "Não foi possível salvar. Tente novamente.";
            }
            return (linhas, msg);
        }

        public (int, string) Atualizar(Produto produto)
        {
            int linhasAfetadas = 0;
            string msg = "";
            try
            {
                string sql = @"update produto set nome = @nome, categoria = @categoria, 
                quantidade = @quantidade, precovenda = @precovenda where id = @id";

                _bd.LimparParametros();
                _bd.AdicionarParametro("@nome", produto.Nome);
                _bd.AdicionarParametro("@categoria", produto.Categoria.Id);
                _bd.AdicionarParametro("@quantidade", produto.Quantidade);
                _bd.AdicionarParametro("@precovenda", produto.PrecoVenda);
                _bd.AdicionarParametro("@id", produto.Id);

                _bd.AbrirConexao();
                linhasAfetadas = _bd.ExecutarNonQuery(sql);
                _bd.FecharConexao();
            }
            catch (Exception ex)
            {
                msg = "Não foi possível salvar. Tente novamente.";
            }
            return (linhasAfetadas, msg);
        }

        public (int, string) Excluir(int id)
        {
            int linhasAfetadas = 0;
            string msg = "";
            try
            {
                string sql = $"delete from produto where id = '{id}';"; 
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

        public IEnumerable<Produto> ObterTodos()
        {
            List<Produto> produtos = new List<Produto>();

            string select = $@"select *, c.id as CategoriaId, c.nome as CategoriaNome FROM produto
                            inner join categoria c on produto.categoria = c.id";
            _bd.AbrirConexao();
            DataTable dt = _bd.ExecutarSelect(select);
            _bd.FecharConexao();

            foreach (DataRow row in dt.Rows)
            {
                var produto = new Produto()
                {
                    Id = Convert.ToInt32(row["id"]),
                    Nome = row["nome"].ToString(),
                    Categoria = new Categoria()
                    {
                        Id = Convert.ToInt32(row["CategoriaId"]),
                        Nome = row["CategoriaNome"].ToString()
                    },
                    Quantidade = Convert.ToInt32(row["quantidade"]),
                    PrecoVenda = Convert.ToDecimal(row["PrecoVenda"])
                };
                produtos.Add(produto);
            }
            return (produtos);
        }

        public Produto ObterPorId(int id)
        {
            Produto produto = null;

            string sql = $@"select * from produto where id = {id}";
            _bd.AbrirConexao();
            DataTable dt = _bd.ExecutarSelect(sql);
            if (dt.Rows.Count > 0)
            {
                produto = new Produto()
                {
                    Id = Convert.ToInt32(dt.Rows[0]["id"]),
                    Nome = dt.Rows[0]["nome"].ToString(),
                    Categoria = new Categoria()
                    {
                        Id = Convert.ToInt32(dt.Rows[0]["Categoria"]),
                        Nome = dt.Rows[0]["nome"].ToString()
                    },
                    Quantidade = Convert.ToInt32(dt.Rows[0]["quantidade"]),
                    PrecoVenda = Convert.ToDecimal(dt.Rows[0]["PrecoVenda"])
                };
            }
            _bd.FecharConexao();
            return produto;
        }
    }
}
