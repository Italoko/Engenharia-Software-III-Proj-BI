using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TrabBimestral.Models;

namespace TrabBimestral.DAL
{
    public class CategoriaDAO
    {
        private static CategoriaDAO instance;
        MySQLPersistence _bd = new MySQLPersistence();
        private CategoriaDAO() { }

        public static CategoriaDAO getInstance()
        {
            if (instance == null)
                instance = new CategoriaDAO();
            return instance;    
        }

        public (int, string) Gravar(Categoria categoria)
        {
            int linhasAfetadas = 0;
            string msg = "";
            try
            {
                string sql = "insert into categoria (nome) values (@nome)";

                _bd.LimparParametros();
                _bd.AdicionarParametro("@nome", categoria.Nome);
                _bd.AbrirConexao();

                linhasAfetadas = _bd.ExecutarNonQuery(sql);
                _bd.FecharConexao();
            }
            catch (Exception ex)
            { msg = "Não foi possível salvar. Tente novamente."; }
            return (linhasAfetadas, msg);
        }

        public IEnumerable<Categoria> Obter()
        {
            List<Categoria> categorias = new List<Categoria>();

            string select = "select * from categoria";
            _bd.AbrirConexao();
            DataTable dt = _bd.ExecutarSelect(select);
            _bd.FecharConexao();

            foreach (DataRow row in dt.Rows)
            {
                var c = new Categoria()
                {
                    Id = Convert.ToInt32(row["id"]),
                    Nome = row["nome"].ToString()
                };
                categorias.Add(c);
            }
            return categorias;
        }
    }
}
