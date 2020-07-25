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

namespace BooksApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CarregarGrid();
            GotFocus += OnFocus;            
        }

        private void CarregarGrid()
        {
            using(var context = new BooksAppContext())
            {
                var livros = context.Livros.ToList();
                LivrosDataGrid.ItemsSource = livros;                
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new CadastroLivro().ShowDialog();
            CarregarGrid();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new CadastroAutor().ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var dialog = new CadastroGenero().ShowDialog();
        }

        private void OnFocus(Object sender, RoutedEventArgs e)
        {
            CarregarGrid();
        }
    }
}
