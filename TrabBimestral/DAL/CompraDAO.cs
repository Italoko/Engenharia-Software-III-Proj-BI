using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabBimestral.Models;

namespace TrabBimestral.DAL
{
    public class CompraDAO
    {
        MySQLPersistence _bd = new();
        private static CompraDAO _instance;
        private CompraDAO() { }

        public static CompraDAO getInstance()
        {
            if (_instance == null)
                _instance = new CompraDAO();
            return _instance;
        }
        public (int, string) Gravar(Compra compra)
        {
            int linhas = 0;
            string msg = "";

            try
            {
                string sql = "insert into compra (fornecedor,total)" +
                "values (@fornecedor, @total)";

                _bd.LimparParametros();
                _bd.AdicionarParametro("@fornecedor", compra.Fornecedor.Id);
                _bd.AdicionarParametro("@total", compra.Total);
                _bd.AbrirConexao();

                linhas = _bd.ExecutarNonQuery(sql);
                if (linhas > 0)
                {
                    compra.Id = _bd.UltimoId;
                    sql = "insert into itenscompra (idCompra,idProduto,quantidade,preco,subtotal)" +
                    "values (@idPedido, @idProduto, @quantidade, @preco, @subtotal)";

                    foreach (var item in compra.Pedido.Itens)
                    {
                        _bd.LimparParametros();
                        _bd.AdicionarParametro("@idCompra", compra.Id);
                        _bd.AdicionarParametro("@idProduto", item.Produto.Id);
                        _bd.AdicionarParametro("@quantidade", item.Quantidade);
                        _bd.AdicionarParametro("@preco", item.Preco);
                        _bd.AdicionarParametro("@subtotal", item.Subtotal);

                        linhas = _bd.ExecutarNonQuery(sql);
                    }
                }
                _bd.FecharConexao();
            }
            catch (Exception ex)
            {
                msg = "Não foi possível salvar. Tente novamente.";
            }
            return (linhas, msg);
        }
    }
}
