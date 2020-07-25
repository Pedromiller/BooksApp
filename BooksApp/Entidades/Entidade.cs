using System;
using System.Collections.Generic;
using System.Text;

namespace BooksApp.Entidades
{
    public class Entidade
    {
        public Guid Id { get; set; }
        public Entidade()
        {
            Id = Guid.NewGuid();
        }
    }
}
