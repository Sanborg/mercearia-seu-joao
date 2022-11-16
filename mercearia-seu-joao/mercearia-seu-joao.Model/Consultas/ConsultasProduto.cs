using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class ConsultasProduto
{
    public static bool InserirProduto(string nome, string fornecedor, int quantidade, int precoUnitario, DateTime dataHoraInclusao)
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        bool foiInserido = false;


        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"
                INSERT INTO Produto (nome,quantidade,precoUnitario,fornecedor,dataHoraInclusao)
                Values (@nome,@quantidade,@precoUnitario,@fornecedor,@dataHoraInclusao)";
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@quantidade", quantidade);
            comando.Parameters.AddWithValue("@precoUnitario", precoUnitario);
            comando.Parameters.AddWithValue("@fornecedor", fornecedor);
            comando.Parameters.AddWithValue("@dataHoraInclusao", dataHoraInclusao);
            var leitura = comando.ExecuteReader();
            foiInserido = true;

        }
        catch (Exception e)
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
        return foiInserido;
    }

    public static bool ExcluirProduto(int id, DateTime dataHoraExclusao)
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        bool foiExcluido = false;


        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"
                UPDATE Produto SET dataHoraExclusao = @dataHoraExclusao
                    WHERE id= @id";
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@dataHoraExclusao", dataHoraExclusao);
            var leitura = comando.ExecuteReader();
            foiExcluido = true;

        }
        catch (Exception e)
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
        return foiExcluido;
    }
    public static bool AtualizarProduto(int id,string nome, string fornecedor, int quantidade, int precoUnitario, DateTime dataHoraInclusao)
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        bool foiAtualizado = false;


        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"
                UPDATE Produto SET nome = @nome, quantidade = @quantidade, precoUnitario = @precoUnitario, fornecedor = @fornecedor, dataHoraInclusao = @dataHoraInclusao
                    WHERE id= @id";
            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@quantidade", quantidade);
            comando.Parameters.AddWithValue("@precoUnitario", precoUnitario);
            comando.Parameters.AddWithValue("@fornecedor", fornecedor);
            comando.Parameters.AddWithValue("@dataHoraInclusao", dataHoraInclusao);
            var leitura = comando.ExecuteReader();
            foiAtualizado = true;

        }
        catch (Exception e)
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
        return foiAtualizado;
    }

    public static List<Produto> ObterTodosOsProdutos(int id)
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        List<Produto> listadeProdutos = new List<Produto>();


        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"
                SELECT * FROM Produto WHERE id = @id";
            comando.Parameters.AddWithValue("@id", id);
            var leitura = comando.ExecuteReader();
            while(leitura.Read())
            {
                Produto produto = new Produto();
                produto.id = leitura.GetInt32("id");
                produto.nome = leitura.GetString("nome");
                produto.quantidade = leitura.GetInt32("quantidade");
                produto.precoUnitario = leitura.GetInt32("precoUnitario");
                produto.fornecedor = leitura.GetString("fornecedor");
                produto.dataHoraInclusao = leitura.GetDateTime("dataHoraInclusao");

                listadeProdutos.Add(produto);
            }
        }
        catch (Exception e)
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
        return listadeProdutos;
    }
}

