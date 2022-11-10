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
        bool telaProdutoFoiAberta = false;
        bool telaUsuarioFoiAberta = false;
        bool telaVenderProdutoFoiAberta = false;
        SolidColorBrush corBtnIndisponivel = new SolidColorBrush(Color.FromArgb(255, 211, 211, 211));

        public string nomeUsuario { get; }
        public string tipoUsuario { get; }

        public frmMenu()
        {
            InitializeComponent();

        }
        public frmMenu(string nomeUsuario, string tipoUsuario)
        {
            InitializeComponent();
            this.nomeUsuario = nomeUsuario;
            this.tipoUsuario = tipoUsuario;
            CumprimentarUsuario();
            AnalisaTipoUsuario();
        }
        public void AnalisaTipoUsuario()
        {
            if(tipoUsuario == "caixa")
            {
                btnProduto.IsHitTestVisible = false;
                btnUsuario.IsHitTestVisible = false;
                btnProduto.Background = corBtnIndisponivel;
                btnUsuario.Background = corBtnIndisponivel;
            }
            else if(tipoUsuario == "gerente")
            {

            }
        }
        private void PressionarBtnProdutos(object sender, RoutedEventArgs e)
        {
            telaProdutoFoiAberta = true;
            Window frmProduto = new frmProduto();
            frmProduto.Show();
        }

        private void PressionarBtnUsuarios(object sender, RoutedEventArgs e)
        {
            Window frmUsuario = new frmUsuario();
            frmUsuario.Show();
        }

        private void PressionarBtnEfetuarVenda(object sender, RoutedEventArgs e)
        {
            Window frmVenda = new frmVenderProduto();
            frmVenda.Show();
        }

        private void PressionarBtnSair(object sender, RoutedEventArgs e)
        {
            Window frmLogin = new MainWindow();
            frmLogin.Show();
            Close();
        }
        private void CumprimentarUsuario()
        {
            var dataAtual = DateTime.Today.ToString("D");
            txtData.Text = $"Olá {nomeUsuario}, hoje é {dataAtual}";
        }
    }
}
