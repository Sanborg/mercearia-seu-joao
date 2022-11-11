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
    /// Lógica interna para frmProduto.xaml
    /// </summary>
    public partial class frmProduto : Window
    {
        List<Produto> listaDeProdutos = new List<Produto>();
        public frmProduto()
        {
            InitializeComponent();

            Produto Produto = new Produto()
            {
                id = 1,
                nome = "Leite",
                quantidade = 200,
                preco_unitario = 6,
                fornecedor = "Jerson"
            };
            listaDeProdutos.Add(Produto);
            datagrid.ItemsSource = listaDeProdutos;
            datagrid.Items.Refresh();
        }

        private void NovoProduto(object sender, RoutedEventArgs e)
        {
            if (verificaCampos() == true)
            {
                Produto Produto = new Produto();
                Produto.nome = txtbox_nome.Text;
                Produto.preco_unitario = int.Parse(txtbox_preco_unitario.Text);
                Produto.fornecedor = txtbox_fornecedor.Text;
                Produto.quantidade = int.Parse(txtbox_quantidade.Text);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Preencha todos os campos.",
                    "Atenção",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }
        private bool verificaCampos()
        {
            if (txtbox_nome.Text != "" && txtbox_fornecedor.Text != "" && txtbox_preco_unitario.Text != "" && txtbox_quantidade.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void LimpaProduto(object sender, RoutedEventArgs e)
        {
            if (txtbox_id.Text != "")
            {
                int id = int.Parse(txtbox_id.Text);
            }
        }

        private void AlterarProduto(object sender, RoutedEventArgs e)
        {

        }

        private void ExcluirProduto(object sender, RoutedEventArgs e)
        {

        }

        private void PegarItemDoGrid(object sender, MouseButtonEventArgs e)
        {
            Produto Produto = (Produto)datagrid.SelectedItems;
            txtbox_id.Text = Produto.id.ToString();
            txtbox_nome.Text = Produto.nome;
            txtbox_preco_unitario.Text = Produto.preco_unitario.ToString();
            txtbox_quantidade.Text = Produto.quantidade.ToString();
            txtbox_fornecedor.Text = Produto.fornecedor;
        }

        private void PegarItemNoGrid(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
