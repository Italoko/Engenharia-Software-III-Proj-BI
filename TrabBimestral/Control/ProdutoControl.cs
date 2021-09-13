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
        private ProdutoControl() { }

        public static ProdutoControl getInstance()
        {
            if (_instance == null)
                _instance = new ProdutoControl();
            return _instance;
        }

        public (Produto, bool, string) Gravar(int id, string nome, int idCategoria, decimal precoDeVenda, int quantidade)
        {
            bool sucesso = false;
            string msg = "";
            string operacao = "registrado";
            int registros = 0;
            Categoria categoria = new Categoria(){Id = idCategoria};
            Produto produto = new Produto(id, nome, quantidade, categoria, precoDeVenda);

            (sucesso, msg) = produto.ValidarDados();
            if (sucesso)
            {
                if (produto.Id == 0)
                    (registros, msg) = produto.Gravar();
                else
                {
                    (registros, msg) = produto.Atualizar();
                    operacao = "alterado";
                }

                if (registros > 0)
                {
                    sucesso = true;
                    msg = $"{produto.Nome} {operacao} com sucesso.";
                }
            }
            return (produto, sucesso, msg);
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
