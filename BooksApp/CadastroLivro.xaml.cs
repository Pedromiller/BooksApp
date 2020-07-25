using BooksApp.Entidades;
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
    /// Interaction logic for CadastroLivro.xaml
    /// </summary>
    public partial class CadastroLivro : Window
    {
        private List<Genero> _generos = new List<Genero>();
        public CadastroLivro()
        {
            InitializeComponent();
            CarregarComboBox();
            GeneroDataGrid.ItemsSource = _generos;
        }

        private void CarregarComboBox()
        {
            using(var context = new BooksAppContext())
            {
                AutorComboBox.ItemsSource = context.Autores.ToList();
                AutorComboBox.DisplayMemberPath = "Nome";
                GeneroComboBox.ItemsSource = context.Generos.ToList();
                GeneroComboBox.DisplayMemberPath = "Nome";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using(var context = new BooksAppContext())
            {
                var autorId = ((Autor)AutorComboBox.SelectedItem).Id;
                var autor = context.Autores.Find(autorId);

                var livro = new Entidades.Livro()
                {
                    Titulo = TituloTextBox.Text,
                    Ano = AnoTextBox.Text,
                    Autor = autor                    
                };

                var livrosGeneros = new List<LivroGenero>();

                foreach (var genero in _generos)
                {
                    livrosGeneros.Add(new LivroGenero() { GeneroId = genero.Id, LivroId = livro.Id });
                }

                livro.LivrosGeneros = livrosGeneros;

                context.Livros.Add(livro);

                context.SaveChanges();                
                ResetScreen();

                MessageBox.Show("Livro salvo com sucesso!");

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using(var context = new BooksAppContext())
            {
                var genero = context.Generos.Find(((Genero)GeneroComboBox.SelectedItem).Id);
                _generos.Add(genero);                
            }

            GeneroDataGrid.Items.Refresh();
        }

        private void ResetScreen()
        {
            _generos.Clear();
            GeneroDataGrid.Items.Refresh();
            AnoTextBox.Clear();
            TituloTextBox.Clear();            
        }
    }
}
