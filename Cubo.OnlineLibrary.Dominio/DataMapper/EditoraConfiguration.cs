using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubo.OnlineLibrary.Dominio.DataMapper
{
    public class EditoraConfiguration : EntityTypeConfiguration<Editora>
    {
        public EditoraConfiguration()
        {
            this.ToTable("TB_EDITORA");

            this.HasKey(t => t.Codigo);

            this.Property(t => t.Codigo)
                .HasColumnName("ID_EDITORA")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.CNPJ)
                .HasColumnName("NR_CNPJ");

            this.Property(t => t.Nome)
                .HasColumnName("NM_EDITORA");

        }
    }
}
