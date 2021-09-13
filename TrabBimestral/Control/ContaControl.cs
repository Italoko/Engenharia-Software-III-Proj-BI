using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabBimestral.Models;

namespace TrabBimestral.Control
{
    public class ContaControl
    {
        private static ContaControl _instance;
        private ContaControl() { }
        public static ContaControl getInstance()
        {
            if (_instance == null)
                _instance = new ContaControl();
            return _instance;
        }

        public (Conta, bool, string) Gravar(int id, string nome, DateTime dataVencimento, decimal valor)
        {
            bool sucesso = false;
            string msg = "";
            string operacao = "registrado";
            int registros = 0;

            Conta conta = new Conta(id, nome, dataVencimento, valor);
            
            (sucesso, msg) = ValidarData(dataVencimento);
            if (sucesso)
            {
                (sucesso, msg) = ValidarValor(valor);
                if (sucesso)
                {
                    if (conta.Id == 0)
                        (registros, msg) = conta.Gravar();
                    else
                    {
                        (registros, msg) = conta.Atualizar();
                        operacao = "alterado";
                    }

                    if (registros > 0)
                    {
                        sucesso = true;
                        msg = $"{conta.Nome} {operacao} com sucesso.";
                    }
                }
            }
            return (conta, sucesso, msg);
        }

        public (bool, string) Excluir(int id)
        {
            Conta conta = new();
            bool sucesso = false;
            string msg = "Id inválido";
            int registros = 0;

            if (id > 0)
            {
                (registros, msg) = conta.Excluir(id);
                if (registros > 0)
                {
                    msg = "Conta excluído com sucesso";
                    sucesso = true;
                }
            }
            return (sucesso, msg);
        }

        public (IEnumerable<Conta>, string) ObterTodos(string filtro)
        {
            string msg = "";
            Conta conta = new();
            IEnumerable<Conta> contas;
            contas = conta.ObterTodos(filtro);

            if (contas.ToList().Count == 0)
                msg = "Não ha contas para listar";

            return (contas, msg);
        }

        public (bool, string) ValidarData(DateTime data)
        {
            bool sucesso = false;
            string msg = "";
            if (data >= DateTime.Now)
                sucesso = true;
            else
                msg = "Data data de vencimento deve ser igual ou maior que hoje.";
            return (sucesso, msg);
        }

        public (bool, string) ValidarValor(decimal valor)
        {
            bool sucesso = false;
            string msg = "";
            if (valor != 0)
                sucesso = true;
            else
                msg = "Valor deve ser diferente de zero.";
            return (sucesso, msg);
        }
    }
}
