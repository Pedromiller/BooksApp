using System;
using System.Collections.Generic;
using System.Text;

namespace BooksApp.Entidades
{
    public class Autor : Entidade
    {
        public string Nome { get; set; }
        public ICollection<Livro> Livros { get; set; }
    }
}
