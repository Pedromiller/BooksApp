using System;
using System.Collections.Generic;
using System.Text;

namespace BooksApp.Entidades
{
    public class Genero : Entidade
    {
        public string Nome { get; set; }
        public ICollection<LivroGenero> LivrosGeneros { get; set; }
    }
}
