using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabBimestral.Models;

namespace TrabBimestral.Control
{
    public class FornecedorControl
    {
        private static FornecedorControl _instance;
        private FornecedorControl() { }

        public static FornecedorControl getInstance()
        {
            if (_instance == null)
                _instance = new FornecedorControl();
            return _instance;
        }

        public (Fornecedor, bool, string) Gravar(int id, string nome, string cnpj)
        {
            bool sucesso = false;
            string msg = "";
            string operacao = "registrado";
            int registros = 0;

            Fornecedor fornecedor = new Fornecedor(id, nome, cnpj);
            if (fornecedor.Id == 0)
                (registros, msg) = fornecedor.Gravar();
            else
            {
                (registros, msg) = fornecedor.Atualizar();
                operacao = "alterado";
            }

            if (registros > 0)
            {
                sucesso = true;
                msg = $"{fornecedor.Nome} {operacao} com sucesso.";
            }
            return (fornecedor, sucesso, msg);
        }

        public (bool, string) Excluir(int id)
        {
            Fornecedor fornecedor = new();
            bool sucesso = false;
            string msg = "Id inválido";
            int registros = 0;

            if (id > 0)
            {
                (registros, msg) = fornecedor.Excluir(id);
                if (registros > 0)
                {
                    msg = "Cliente excluído com sucesso";
                    sucesso = true;
                }
            }
            return (sucesso, msg);
        }

        public (IEnumerable<Fornecedor>, string) ObterTodos()
        {
            string msg = "";
            Fornecedor fornecedor = new();
            IEnumerable<Fornecedor> fornecedores;
            fornecedores = fornecedor.ObterTodos();

            if (fornecedores.ToList().Count == 0)
                msg = "Não ha fornecedores para listar";

            return (fornecedores, msg);
        }

        public Fornecedor ObterPorCNPJ(string cnpj)
        {
            Fornecedor fornecedor = new();
            return fornecedor.ObterPorCNPJ(cnpj);
        }
    }
}
