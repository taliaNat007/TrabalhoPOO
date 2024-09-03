using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace tabela_marca
{
    public static class Conexao
    {
        public static MySqlConnection conexao;

        public static MySqlConnection Conectar() 
        {
            try
            {
                string strconexao = "server=localhost;port=3306;uid=root;pwd=root;database=CadMarca";
                conexao = new MySqlConnection(strconexao);
                conexao.Open();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Erro ao realizar conexão com a base de dados! {ex.Message}");
            }

            return conexao;
        }

        public static void FecharConexao()
        {
            conexao.Close();
        }
    }
}
