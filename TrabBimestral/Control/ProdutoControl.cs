using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabBimestral.Models;

namespace TrabBimestral.Control
{
    public class ProdutoControl
    {
        private static ProdutoControl _instance;
        Produto _produto;
        private ProdutoControl() { Produto = new Produto();}
        public Produto Produto { get => _produto; set => _produto = value; }
        public static ProdutoControl getInstance()
        {
            if (_instance == null)
                _instance = new ProdutoControl();
            return _instance;
        }

        public (Produto, bool, string) Gravar(System.Text.Json.JsonElement dados)//(int id, string nome, int idCategoria, decimal precoDeVenda, int quantidade)
        {
            bool sucesso = false;
            string msg = "";
            string operacao = "registrado";
            int registros = 0;
            Fornecedor fornecedor = FornecedorControl.getInstance().ObterPorCNPJ(dados.GetProperty("fornecedor").ToString());
            Categoria categoria = new Categoria(){Id = Convert.ToInt32(dados.GetProperty("categoriaId").ToString()) };

            Produto.Id = Convert.ToInt32(dados.GetProperty("id").ToString());
            Produto.Nome = dados.GetProperty("nome").ToString();
            Produto.Quantidade = Convert.ToInt32(dados.GetProperty("quantidade").ToString());
            Produto.Categoria = categoria;
            Produto.PrecoVenda = Convert.ToDecimal(dados.GetProperty("valor").ToString());

            if (Produto.Id == 0)
            {
               (registros, msg) = Produto.Gravar();
                Produto.Add(fornecedor);
            }  
            else
            {
                (registros, msg) = Produto.Atualizar();
                operacao = "alterado";
            }

            if (registros > 0)
            {
                sucesso = true;
                msg = $"{Produto.Nome} {operacao} com sucesso.";
            }
            return (Produto, sucesso, msg);
        }

        public (bool,string) Excluir(int id)
        {
            Produto prod = new();
            bool sucesso = false;
            string msg = "Id inválido";
            int registros = 0;

            if (id > 0)
            {
                (registros, msg) = prod.Excluir(id);
                if (registros > 0)
                {
                    msg = "Produto excluído com sucesso";
                    sucesso = true;
                }
            }
            return (sucesso, msg);
        }

        public (IEnumerable<Produto>, string) ObterTodos()
        {
            string msg = "";
            Produto prod = new();
            IEnumerable<Produto> produtos;
            produtos = prod.ObterTodos();

            if (produtos.ToList().Count == 0)
                msg = "Não ha produtos para listar";

            return (produtos, msg);
        }
        public Produto ObterPorId(int id)
        {
            Produto prod = new();
            return prod.ObterPorId(id);
        }
    }
}
