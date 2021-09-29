using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabBimestral.Models;

namespace TrabBimestral.Control
{
    public abstract class  ComercioControl
    {
        public  bool GravarTransacao(System.Text.Json.JsonElement dados) 
        {
            ProdutoControl pc = ProdutoControl.getInstance();
            Pedido pedido = new();

            int op = Convert.ToInt32(dados.GetProperty("op").ToString());
            string idUser = dados.GetProperty("idUser").ToString();

            foreach (var item in dados.GetProperty("itens").EnumerateArray())
            {
                Produto produto = pc.ObterPorId(Convert.ToInt32(item.GetProperty("idProd").ToString()));
                if(produto != null)
                {
                    PedidoItem pedidoItem = new()
                    {
                        Quantidade = Convert.ToInt32(item.GetProperty("qtd").ToString()),
                        Preco = produto.PrecoVenda,
                        Subtotal = produto.PrecoVenda * Convert.ToInt32(item.GetProperty("qtd").ToString()),
                        Produto = produto
                    };
                    pedido.Total += pedidoItem.Subtotal;
                    pedido.Itens.Add(pedidoItem);
                }
            }
            if(pedido.Itens.Count() > 0)
            {
                switch (op)
                {
                    //Cliente
                    case 1:
                        VendaControl CVenda = VendaControl.getInstance();
                        CVenda.Gravar(pedido, idUser);
                        break;
                    //Fornecedor
                    case 2:
                        CompraControl CCompra = CompraControl.getInstance();
                        CCompra.Gravar(pedido, idUser);
                        break;
                }
            }
            return true;
        }
        public abstract bool Gravar(Pedido pedido, string idUser);
    }
}
