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
    /// Lógica interna para frmUsuario.xaml
    /// </summary>
    public partial class frmUsuario : Window
    {
        List<Usuario> listaDeUsuarios = new List<Usuario>();
        public frmUsuario()
        {
            InitializeComponent();
            AtualizaDatagrid();

        }

        private void NovoUsuario(object sender, RoutedEventArgs e)
        {
            if (VerificaCampos() == true)
            {
                AdicionaUsuario();
            }
            else
            {
                MessageBoxResult result = MessageBox.Show(
                   "Preencha todos os campos",
                   "Atenção",
                   MessageBoxButton.OK,
                   MessageBoxImage.Information);
            }
        }
        private bool VerificaCampos()
        {
            if (boxNomeUsuario.Text != "" && boxEmailUsuario.Text != "" &&
               boxSenhaUsuario.Text != "" && boxConfirmarSenhaUsuario.Text != "" && boxConfirmarSenhaUsuario.Text != boxSenhaUsuario.Text)
            {
                return true;
            }
            else
            {

                return false;
            }
        }
        private void AlterarUsuario(object sender, RoutedEventArgs e)
        {
            if (boxId.Text != "")
            {
                int id = int.Parse(boxId.Text);
                MessageBoxResult result = MessageBox.Show(
                    $"Deseja alterar o usuario id: {id}?",
                    "alterar o produto",
                    MessageBoxButton.OK,
                    MessageBoxImage.Question
                    );
            }
        }

        private void AdicionaUsuario()
        {
            bool foiAdicionado = ConsultasUsuario.AdicionarUsuario(
                boxNomeUsuario.Text,
                boxSenhaUsuario.Text,
                boxConfirmarSenhaUsuario.Text,
                DateTime.Today
                );
            if (foiAdicionado == true)
            {
                MessageBoxResult result = MessageBox.Show(
                    "Usuario Adicionado",
                    "Atenção",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                LimpaCampos();
                AtualizaDatagrid();

            }

        }
        private void ExcluirUsuario(object sender, RoutedEventArgs e)
        {
            if (boxId.Text != "")
            {
                int id = int.Parse(boxId.Text);
                MessageBoxResult result = MessageBox.Show(
                    $"Deseja excluir o usuario id{id}?",
                    "Excluir produto",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);
            }
        }

        private void LimpaUsuario(object sender, RoutedEventArgs e)
        {
            LimpaCampos();
        }

        private void LimpaCampos()
        {
            boxNomeUsuario.Text = "";
            boxId.Text = "";
            boxEmailUsuario.Text = "";
            boxSenhaUsuario.Text = "";
            boxConfirmarSenhaUsuario.Text = "";
        }

        private void PegarItemNoGrid(object sender, MouseButtonEventArgs e)
        {
            Usuario usuario = (Usuario)dgvUsuarios.SelectedItem;
            boxId.Text = usuario.id.ToString();
            boxNomeUsuario.Text = usuario.nome;
            boxSenhaUsuario.Text = usuario.senha;
            boxEmailUsuario.Text = usuario.email;
            boxConfirmarSenhaUsuario.Text = usuario.senha;

        }
        private void AtualizaDatagrid()
        {
            listaDeUsuarios.Clear();
            listaDeUsuarios = ConsultasUsuario.ObterDadosUsuario();
            dgvUsuarios.ItemsSource = listaDeUsuarios;
            dgvUsuarios.Items.Refresh();

        }
    }
}   
