using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient; 


namespace TrabBimestral.DAL
{
    public class MySQLPersistence
    {
        string _strCon = ""; 
        MySqlConnection _conexao; 
        MySqlCommand _comando;
        public int UltimoId { get; set; }

        public MySQLPersistence() 
        {
            _strCon = "Data Source = den1.mysql4.gear.host; Database = aulalp4; User Id = aulalp4; Password = Al59dz6?6v7_; ; SSL Mode = None";
            _conexao = new MySqlConnection(_strCon);
            _comando = _conexao.CreateCommand(); 
        }

        public void AbrirConexao()
        {
            if (_conexao.State != System.Data.ConnectionState.Open)  
                _conexao.Open(); 
        }

        public void FecharConexao()
        {
            _conexao.Close();
        }


        public void AdicionarParametro(string nome, object valor)
        {
            _comando.Parameters.AddWithValue(nome, valor);
        }

        public void LimparParametros()
        {
            _comando.Parameters.Clear();  
        }
                                                  
        public int ExecutarNonQuery(string instrucao, Dictionary<string, object> parametros = null)// Executa os comandos de NonQuery
        {
            _comando.CommandText = instrucao;
            if (parametros != null)
            {
                foreach (var item in parametros)
                {
                    _comando.Parameters.AddWithValue(item.Key, item.Value);
                }
            }
            int linhasAfetadas = _comando.ExecuteNonQuery();
            if (linhasAfetadas > 0)
                UltimoId = Convert.ToInt32(_comando.LastInsertedId);
            return linhasAfetadas; 
        }

        public DataTable ExecutarSelect(string select, Dictionary<string, object> parametros = null)
        {
            DataTable tabMemoria = new DataTable();  
            _comando.CommandText = select;

            if (parametros != null)
            {
                foreach (var item in parametros)
                {
                    _comando.Parameters.AddWithValue(item.Key, item.Value);
                }
            }
            tabMemoria.Load(_comando.ExecuteReader()); 
            return tabMemoria; 
        }
        public object ExecutarConsultaSimples(string select, Dictionary<string, object> parametros = null)
        {
            object valor = null;
            _comando.CommandText = select;

            if (parametros != null)
            {
                foreach (var item in parametros)
                {
                    _comando.Parameters.AddWithValue(item.Key, item.Value);
                }
            }
            valor = _comando.ExecuteScalar();
            return valor;
        }
    }
}
