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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace mercearia_seu_joao.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(string nomeUsuario, string tipoUsuario)
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(VerificaCampos() == true)
            {
                string email = boxEmail.Text;
                string senha = boxSenha.Password;
                Login(email, senha);

            }
        }

        private void EsqueceuSenhaUsuario(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
               "Contate o seu Gerente",
               "Informação",
               MessageBoxButton.OK,
               MessageBoxImage.Warning
               );
        }

        private bool VerificaCampos()
        {
            if(boxEmail.Text != "" && boxSenha.Password != "")
            {
                return true;
            }
            else
            {
              MessageBoxResult result = MessageBox.Show(
              "Preencha todos os campos",
              "Atenção",
              MessageBoxButton.OK,
              MessageBoxImage.Warning
              );
                return false;
            }
        }
        public void Login(string email, string senha)
        {
            Usuario usuario = cUsuario.BuscarDadosUsuario(email, senha);
            frmMenu frmMenu = new frmMenu(usuario.nome, usuario.tipoUsuario);
            frmMenu.Show();
            Close();
        }
    }
}
