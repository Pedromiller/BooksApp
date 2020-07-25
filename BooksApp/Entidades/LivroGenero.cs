using System;
using System.Collections.Generic;
using System.Text;

namespace BooksApp.Entidades
{
    public class LivroGenero
    {
        public Livro Livro { get; set; }
        public Guid LivroId { get; set; }
        public Genero Genero { get; set; }
        public Guid GeneroId { get; set; }
    }
}
