using BooksApp.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksApp
{
    public class BooksAppContext : DbContext
    {
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<LivroGenero> LivrosGeneros { get; set; }
        public BooksAppContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=BooksApp;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Livro
            modelBuilder.Entity<Livro>().HasKey(x => x.Id);

            modelBuilder.Entity<Livro>().HasOne(x => x.Autor)
                .WithMany(x => x.Livros)
                .HasForeignKey(x => x.AutorId);

            //Genero
            modelBuilder.Entity<Genero>().HasKey(x => x.Id);

            //LivroGenero
            modelBuilder.Entity<LivroGenero>()
                .HasKey(x => new { x.LivroId, x.GeneroId });

            modelBuilder.Entity<LivroGenero>()
                .HasOne(x => x.Livro)
                .WithMany(x => x.LivrosGeneros)
                .HasForeignKey(x => x.LivroId);

            modelBuilder.Entity<LivroGenero>()
                .HasOne(x => x.Genero)
                .WithMany(x => x.LivrosGeneros)
                .HasForeignKey(x => x.GeneroId);

            modelBuilder.Entity<LivroGenero>().ToTable("LivroGenero");
        }
    }
}
