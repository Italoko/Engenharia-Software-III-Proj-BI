using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabBimestral.Models;

namespace TrabBimestral.DAL
{
    public class PedidoDAO
    {
        MySQLPersistence _bd = new();
        public (int, string) Gravar(Pedido pedido)
        {
            int linhas = 0;
            string msg = "";

            try
            {
                string sql = "insert into pedido (total) values (@total)";
                _bd.LimparParametros();
                _bd.AdicionarParametro("@total", pedido.Total);
                _bd.AbrirConexao();

                linhas = _bd.ExecutarNonQuery(sql);
                if (linhas > 0)
                {
                    pedido.Id = _bd.UltimoId;
                    sql = "insert into pedidoitem (idPedido,idProduto,quantidade,preco,subtotal)" +
                    "values (@idPedido, @idProduto, @quantidade, @preco, @subtotal)";

                    foreach (var item in pedido.Itens)
                    {
                        _bd.LimparParametros();
                        _bd.AdicionarParametro("@idPedido", pedido.Id);
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
            {msg = "Não foi possível salvar. Tente novamente.";}
            return (linhas, msg);
        }
    }
}
