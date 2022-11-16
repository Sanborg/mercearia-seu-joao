using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

public class ConsultasUsuario
{
    public static Usuario BuscarDadosUsuario(string email, string senha)
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        Usuario usuario = null;

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"
                SELECT * FROM Usuario WHERE email = @email AND senha = @senha;";
            comando.Parameters.AddWithValue("@email", email);
            comando.Parameters.AddWithValue("@senha", senha);
            var leitura = comando.ExecuteReader();
            while (leitura.Read())
            {
                usuario = new Usuario();
                usuario.id = leitura.GetInt32("id");
                usuario.nome = leitura.GetString("nome");
                usuario.email = leitura.GetString("email");
                usuario.senha = leitura.GetString("senha");
                usuario.tipoUsuario = leitura.GetString("tipoUsuario");
                usuario.dataHoraInclusao = leitura.GetDateTime("dataHoraInclusao");
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
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
    public static bool AdicionarUsuario(string nome, string senha, string tipoUsuario, DateTime dataHoraInclusao)
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        bool foiAdicionado = false;

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"
                  INSERT INTO Usuario ( nome, senha, tipoUsuario, dataHoraInclusao)
                  VALUES (@id,@nome,@senha,@tipoUsuario,@dataHoraInclusao)";
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@senha", senha);
            comando.Parameters.AddWithValue("@tipoUsuario", tipoUsuario);
            comando.Parameters.AddWithValue("@dataHoraInclusao", DateTime.Now);
            var leitura = comando.ExecuteReader();

            foiAdicionado = true;




        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        return foiAdicionado;
    }
    public static bool ExcluirUsuario(DateTime dataHoraExclusao)
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        bool foiExcluido = false;

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"
                 INSERT INTO Usuario (dataHoraExclusao)
                  VALUES (@dataHoraExclusao)";
            comando.Parameters.AddWithValue("@dataHoraExclusao", DateTime.Now);
            var leitura = comando.ExecuteReader();
            foiExcluido = true;

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        return foiExcluido;
    }
    public static bool AtualizarUsuario(int id, string nome, string senha, string tipoUsuario, DateTime dataHoraAlteracao)
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        bool foiAdicionado = false;

        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"
                  UPDATE Usuario SET nome = @nome, senha = @senha, tipoUsuario = @tipoUsuario, dataHoraAlteracao = @dataHoraAlteracao
                   WHERE id = @id";
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@senha", senha);
            comando.Parameters.AddWithValue("@tipoUsuario", tipoUsuario);
            comando.Parameters.AddWithValue("@dataHoraInclusao", DateTime.Now);
            var leitura = comando.ExecuteReader();
            foiAdicionado = true;




        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        return foiAdicionado;
    }
    public static List<Usuario> ObterDadosUsuario()
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        List<Usuario> listaDeUsuarios = new List<Usuario>();


        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"
                SELECT * FROM Usuario;";
            var leitura = comando.ExecuteReader();
            while (leitura.Read())
            {
                Usuario usuario = new Usuario();
                usuario.id = leitura.GetInt32("id");
                usuario.nome = leitura.GetString("nome");
                usuario.email = leitura.GetString("email");
                usuario.senha = leitura.GetString("senha");
                usuario.tipoUsuario = leitura.GetString("tipoUsuario");
                usuario.dataHoraInclusao = leitura.GetDateTime("dataHoraInclusao");
                listaDeUsuarios.Add(usuario);
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            if (conexao.State == System.Data.ConnectionState.Open)
            {
                conexao.Close();
            }
        }

        return listaDeUsuarios;
    }
}