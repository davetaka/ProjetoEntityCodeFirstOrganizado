using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubo.OnlineLibrary.Dominio.DataMapper
{
    public class LivroConfiguration : EntityTypeConfiguration<Livro>
    {
        public LivroConfiguration()
        {
            this.ToTable("TB_LIVRO");
            this.HasKey(t => t.Codigo);

            this.Property(t => t.Codigo)
                .HasColumnName("ID_LIVRO")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.Nome)
                .HasColumnName("NM_LIVRO");

            this.Property(t => t.Autor)
                .HasColumnName("NM_AUTOR");

            this.Property(t => t.Resumo)
                .HasColumnName("DS_RESUMO");

            this.Property(t => t.Capa)
                .HasColumnName("IM_CAPA");

            this.Property(t => t.DataEdicao)
                .HasColumnName("DT_EDICAO");

            this.Property(t => t.ValorMulta)
                .HasColumnName("VL_MULTA_DIARIA");

            this.Property(t => t.EditoraId)
                .HasColumnName("ID_EDITORA");

            this.HasRequired(e => e.Editora)
                .WithMany(e => e.Livros)
                .HasForeignKey(e => e.EditoraId);

        }
    }
}
