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
    /// Lógica interna para frmMenu.xaml
    /// </summary>
    public partial class frmMenu : Window
    {
        SolidColorBrush corBtnIndisponivel = new SolidColorBrush(Color.FromArgb(255, 211, 211, 211));
        public frmMenu()
        {
            InitializeComponent();

        }
        public frmMenu(string nomeUsuario, string tipoUsuario)
        {
            InitializeComponent();
            this.nomeUsuario = nomeUsuario;
            this.tipoUsuario = tipoUsuario;
        }

        private void PressionarBtnProdutos(object sender, RoutedEventArgs e)
        {
            if(tipoUsuario == "gerente")
            {
                Window frmProduto = new frmProduto();
                frmProduto.Show();
            }
            else
            {
                btnProduto.IsHitTestVisible = false;
                btnProduto.Background = corBtnIndisponivel;
            }
        }

        private void PressionarBtnUsuarios(object sender, RoutedEventArgs e)
        {
            if (tipoUsuario == "gerente")
            {
                Window frmUsuario = new frmUsuario();
                frmUsuario.Show();
            }
            else
            {
                btnUsuario.IsHitTestVisible = false;
                btnUsuario.Background = corBtnIndisponivel;
            }
        }

        private void PressionarBtnEfetuarVenda(object sender, RoutedEventArgs e)
        {
            Window frmVenda = new frmVenderProduto();
            frmVenda.Show();
        }

        private void PressionarBtnSair(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void CumprimentarUsuario()
        {
            var dataAtual = DateTime.Today.ToString("D");
            txtData.Text = $"Olá {nomeUsuario}, hoje é {dataAtual}";
        }
    }
}
