using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabBimestral.Models;

namespace TrabBimestral.DAL
{
    public class VendaDAO
    {
        MySQLPersistence _bd = new();
        private static VendaDAO _instance;
        private VendaDAO() { }

        public static VendaDAO getInstance()
        {
            if (_instance == null)
                _instance = new VendaDAO();
            return _instance;
        }

        public (int, string) Gravar(Venda venda)
        {
            int linhas = 0;
            string msg = "";

            try
            {
                string sql = "insert into venda (cliente,total)" +
                "values (@cliente, @total)";

                _bd.LimparParametros();
                _bd.AdicionarParametro("@cliente", venda.Cliente.Id);
                _bd.AdicionarParametro("@total", venda.Total);
                _bd.AbrirConexao();

                linhas = _bd.ExecutarNonQuery(sql);
                if (linhas > 0)
                {
                    venda.Id = _bd.UltimoId;
                    sql = "insert into itensvenda (idVenda,idProduto,quantidade,preco,subtotal)" +
                    "values (@idPedido, @idProduto, @quantidade, @preco, @subtotal)";

                    foreach (var item in venda.Pedido.Itens)
                    {
                        _bd.LimparParametros();
                        _bd.AdicionarParametro("@idVenda", venda.Id);
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

