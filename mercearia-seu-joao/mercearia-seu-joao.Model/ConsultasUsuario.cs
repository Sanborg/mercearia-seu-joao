using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

public class ConsultaUsuario
{
    public static Usuario ObterUsuarioPeloLoginSenha(string email, string senha)
    {
        var conexao = new MySqlConnection(ConexaoBD.Conexao.ConnectionString);
        Usuario usuario = null;

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"Select * from Usuario Where email = @email and senha = @senha";
            comando.Parameters.AddWithValue("@email", email);
            comando.Parameters.AddWithValue("@senha", senha);
            var leitura = comando.ExecuteReader();
            while(leitura.Read())
             {
                usuario = new Usuario();
                usuario.Id = leitura.GetInt32("id");
                usuario.email = leitura.GetString("email");
                usuario.senha = leitura.GetString("senha"); 
                break;
             }
        } 
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
        }
        return usuario;
    }
}
