using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class cProduto
{
    public static bool InserirProduto(string nome, string fornecedor, int quantidade, int precoUnitario, DateTime dataHoraInclusao)
    {
        return ConsultasProduto.InserirProduto(nome, fornecedor, quantidade, precoUnitario, dataHoraInclusao);
    }
    public static bool ExcluirProduto(int id, DateTime dataHoraExclusao)
    {
        return ConsultasProduto.ExcluirProduto(id, dataHoraExclusao);
    }
    public static bool AtualizarProduto(int id, string nome, string fornecedor, int quantidade, int precoUnitario, DateTime dataHoraInclusao)
    {
        return ConsultasProduto.AtualizarProduto(id, nome, fornecedor, quantidade, precoUnitario, dataHoraInclusao);
    }
    public static List<Produto> ObterTodosOsProdutos()
    {
        return ConsultasProduto.ObterTodosOsProdutos();
    }
}
