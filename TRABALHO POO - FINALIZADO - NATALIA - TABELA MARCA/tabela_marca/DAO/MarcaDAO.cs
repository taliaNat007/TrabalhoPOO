using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabela_marca.Models;
using MySql.Data.MySqlClient;
namespace tabela_marca.DAO
{
    internal class MarcaDAO
    {
        public void Insert(Marca marca)
        {
			try
			{
				string sql = " INSERT INTO Marca(Nome, Observacao, Localidade)" +
					"VALUES(@nome, @observacao, @localidade)";
				MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
				comando.Parameters.AddWithValue("@nome", marca.Nome);
				comando.Parameters.AddWithValue("@observacao", marca.Observacao);
				comando.Parameters.AddWithValue("@localidade", marca.Localidade);
				comando.ExecuteNonQuery();
                Console.WriteLine(@"            Marca Cadastrada com sucesso!");
				Conexao.FecharConexao();

            }
			catch (Exception ex)
			{

				throw new Exception (@$"            Erro ao cadastrar Marca! {ex.Message}");
			}
        }

		public void Delete(Marca marca)
		{
			try
			{
				string sql = "DELETE FROM Marca WHERE Id_marca= @id_marca";
				MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
				comando.Parameters.AddWithValue("@id_marca", marca.Id_marca);
				comando.ExecuteNonQuery ();
                Console.WriteLine(@"            Marca excluída com sucesso!");
				Conexao.FecharConexao();
            }
			catch (Exception ex)
			{

				throw new Exception(@$"            Erro ao excluir Marca {ex.Message}");
			}
		}

		public void Update(Marca marca)
		{
			try
			{
				string sql = "UPDATE Marca SET Nome = @nome, Observacao = @observacao, Localidade = @localidade WHERE Id_marca = @id_marca";
				MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
				comando.Parameters.AddWithValue("@nome", marca.Nome);
				comando.Parameters.AddWithValue("@observacao", marca.Observacao);
				comando.Parameters.AddWithValue("@localidade", marca.Localidade);
				comando.Parameters.AddWithValue("@id_marca", marca.Id_marca);
				comando.ExecuteNonQuery();
				Console.WriteLine(@"            Marca Atualizada com sucesso!");
				Conexao.FecharConexao();
			}
			catch (Exception ex)
			{

				throw new Exception(@$"            Erro ao atualizar marca {ex.Message}");
			}
        }

		public List<Marca> List()
		{
			List<Marca> marcas = new List<Marca>();

			try
			{
				var sql = "SELECT * FROM Marca ORDER BY Nome";
				MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

				using (MySqlDataReader dr = comando.ExecuteReader()) 
				{
					while (dr.Read()) 
					{
						Marca marca = new Marca();
						marca.Id_marca = dr.GetInt32("Id_marca");
						marca.Nome = dr.GetString("Nome");
						marca.Observacao = dr.GetString("Observacao");
						marca.Localidade = dr.GetString("Localidade");
						marcas.Add(marca);
					}
				}
				Conexao.FecharConexao();
			}
			catch (Exception ex)
			{

                throw new Exception(@$"            Erro ao listar marca {ex.Message}");
            }

            return marcas; 
		}
    }
}
