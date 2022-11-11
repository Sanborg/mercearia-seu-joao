﻿using System;
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

        private void BuscarProduto(object sender, RoutedEventArgs e)
        {
            
        }

        private void AdicionarProduto(object sender, RoutedEventArgs e)
        {
            if (VerificaCampos() == true)
            {
                Produto produto = new Produto();
                produto.nome = boxNome.Text;
                produto.quantidade = int.Parse(boxQuantidade.Text);
                int precoTotal = produto.quantidade * produto.precoUnitario;
                boxPrecoTotalProduto.Text = precoTotal.ToString();

            }
            else
            {
                MessageBoxResult result = MessageBox.Show(
                    "Preencha todos os campos!",
                    "Atenção",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
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

        private int RetornaUltimoIdDaLista()
        {
            int id = 0;
            foreach
        }

        private void LimparProduto(object sender, RoutedEventArgs e)
 
       {

        }

        private void RealizarVenda(object sender, RoutedEventArgs e)
        {

        }
        
        private void PegarItemNoGrid(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
