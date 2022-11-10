using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class ConsultasProduto
{
    public static bool InserirProduto(string nome, string fornecedor, int quantidade, int preco_unitario)
    {
        var conexao = new MySqlConnection(ConexaoBD.Connection.ConnectionString);
        bool foiInserido = false;


        try
        {
            conexao.Open();
            var comando = conexao.CreateCommand();
            comando.CommandText = @"INSERT INTO Produto (nome, quantidade, "
        }
        catch (Exception e)
        {   
            Console.WriteLine(e.Message);
        }
        finally
        {

        }
        return foiInserido;
    }
}

