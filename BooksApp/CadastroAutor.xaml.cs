using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BooksApp
{
    /// <summary>
    /// Interaction logic for CadastrarAutor.xaml
    /// </summary>
    public partial class CadastroAutor : Window
    {
        public CadastroAutor()
        {
            InitializeComponent();
            CarregarGrid();
        }

        private void CarregarGrid()
        {
            using (var context = new BooksAppContext())
            {
                AutorDataGrid.ItemsSource = context.Autores.ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using(var context = new BooksAppContext())
            {
                context.Autores.Add(new Entidades.Autor() { Nome = NomeTextBox.Text });

                context.SaveChanges();
                
                CarregarGrid();

                NomeTextBox.Clear();
                MessageBox.Show("Autor salvo com sucesso!");
            }
        }
    }
}
