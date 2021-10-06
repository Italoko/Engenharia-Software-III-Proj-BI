using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabBimestral.DAL;

namespace TrabBimestral.Models
{
    public class Categoria
    {
        int _id;
        string _nome;

        public Categoria()
        {
            Id = 0;
            Nome = "";
        }

        public int Id { get => _id; set => _id = value; }
        public string Nome { get => _nome; set => _nome = value; }

        public (int,string) Gravar()
        {
            CategoriaDAO cd = CategoriaDAO.getInstance();
            int registros;
            string msg;
            return (registros, msg) = cd.Gravar(this);
        }

        public IEnumerable<Categoria> Obter()
        {
            CategoriaDAO cd = CategoriaDAO.getInstance();

            return cd.Obter();
        }

        public bool ValidarCampos()
        {
            return !string.IsNullOrEmpty(Nome);
        }
    }
}
