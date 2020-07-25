using System;
using System.Collections.Generic;
using System.Text;

namespace BooksApp.Entidades
{
    public class Livro : Entidade
    {
        public string Titulo { get; set; }
        public string Ano { get; set; }
        public Autor Autor { get; set; }
        public Guid AutorId { get; set; }
        public ICollection<LivroGenero> LivrosGeneros { get; set; }
    }
}
