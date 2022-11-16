using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace mercearia_seu_joao.View
{
    /// <summary>
    /// Lógica interna para frmVenderProduto.xaml
    /// </summary>
    public partial class frmVenderProduto : Window
    {
        List<Produto> listaDeProdutos = new List<Produto>();
        public frmVenderProduto()
        {
            InitializeComponent();
        }

        public void BuscarProduto(object sender, RoutedEventArgs e)
        {
            if(boxId.Text != "")
            {
                listaDeProdutos.Clear();
                listaDeProdutos = cProduto.ObterTodosOsProdutos(int.Parse(boxId.Text));
                datagridProdutos.ItemsSource = listaDeProdutos;
                datagridProdutos.Items.Refresh();
            }

        }

        private void AdicionarProduto(object sender, RoutedEventArgs e)
        {
            if (VerificaCampos() == true)
            {
                Produto produto = new Produto();
                produto.id = RetornaUltimoIdIncrementadoDaLista();
                produto.nome = boxNome.Text;
                produto.quantidade = int.Parse(boxQuantidade.Text);
                float precoTotal = produto.quantidade * produto.precoUnitario;
                boxPrecoTotalProduto.Text = precoTotal.ToString();
                listaDeProdutos.Add(produto);
                AtualizaDataGrid();
            }
           
        }
        
        private void AtualizaDataGrid ()
        {
            datagridProdutos.ItemsSource = listaDeProdutos;
            datagridProdutos.Items.Refresh();
        }

        private bool VerificaCampos ()
        {
            if (boxNome.Text != "" && boxQuantidade.Text != "" && boxPrecoTotalProduto.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int RetornaUltimoIdIncrementadoDaLista()
        {
            int id = 0;
            if (listaDeProdutos.Count > 0)
            {
                int index = listaDeProdutos.Count - 1;
                id = listaDeProdutos[index].id;
            }
            id++;
            return id;
        }

        private void LimparProduto(object sender, RoutedEventArgs e)

        {
            boxId.Text = "";
            boxNome.Text = "";
            boxPrecoTotalProduto.Text = "";
            boxQuantidade.Text = "";
        }

        private void RealizarVenda(object sender, RoutedEventArgs e)
        {

        }
        
        private void PegarItemNoGrid(object sender, MouseButtonEventArgs e)
        {
            Produto produto = (Produto)datagridProdutos.SelectedItem;
            boxId.Text = produto.id.ToString();
            boxNome.Text = produto.nome;
            boxQuantidade.Text= produto.quantidade.ToString();
            boxPrecoTotalProduto.Text = produto.precoUnitario.ToString();
        }
    }
}
