using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.IO;
using Cubo.OnlineLibrary.Framework;
using Cubo.OnlineLibrary.Dominio.DataMapper;

namespace Cubo.OnlineLibrary.Dominio.Contexto
{
    public class BibliotecaContexto : DbContext
    {
        public DbSet<Editora> Editoras { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
        public DbSet<Livro> Livros { get; set; }

        public BibliotecaContexto()
            : base("conexaoBiblioteca")
        {
            this.Database.Log = FileHelper.SaveFile;
            Database.SetInitializer<BibliotecaContexto>(null);
            Database.SetInitializer<BibliotecaContexto>(new DropCreateDatabaseAlways<BibliotecaContexto>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new EditoraConfiguration());
            modelBuilder.Configurations.Add(new LivroConfiguration());
            modelBuilder.Configurations.Add(new EscritorConfiguration());
        }
    }
}
