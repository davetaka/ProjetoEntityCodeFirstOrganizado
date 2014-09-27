using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubo.OnlineLibrary.Dominio.DataMapper
{
    public class EscritorConfiguration : EntityTypeConfiguration<Escritor>
    {
        public EscritorConfiguration()
        {
            this.ToTable("TB_ESCRITOR");

            this.HasKey(t => t.Codigo);

            this.Property(t => t.Codigo)
                .HasColumnName("ID_ESCRITOR")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.Nome)
                .HasColumnName("NM_ESCRITOR")
                .IsRequired()
                .HasMaxLength(60)
                .IsFixedLength()
                .IsUnicode(false);

            this.HasMany(t => t.Livros)
                .WithMany(t => t.Escritores)
                .Map(m => m.MapLeftKey("ID_ESCRITOR")
                    .MapRightKey("ID_LIVRO")
                .ToTable("TB_ESCRITOR_LIVRO"));


        }
    }
}
