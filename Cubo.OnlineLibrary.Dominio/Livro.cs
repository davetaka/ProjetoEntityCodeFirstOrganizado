using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cubo.OnlineLibrary.Dominio
{
    [Table("TB_LIVRO")]
    public class Livro
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Column("ID_LIVRO")]
        public int? Codigo { get; set; }

        //[Column("NM_LIVRO")]
        public string Nome { get; set; }

        //[Column("NM_AUTOR")]
        public string Autor { get; set; }

        //[Column("DS_RESUMO")]
        public string Resumo { get; set; }

        //[Column("IM_CAPA")]
        public byte[] Capa { get; set; }

        //[Column("DT_EDICAO")]
        public DateTime? DataEdicao { get; set; }

        //[Column("VL_MULTA_DIARIA")]
        public decimal? ValorMulta { get; set; }

        //[Column("ID_EDITORA")]
        //Sabor nº2 - [ForeignKey("Editora")]
        public int? EditoraId { get; set; }

        //[ForeignKey("EditoraId")]
        public virtual Editora Editora { get; set; }

        //[Column("IS_EMPRESTADO")]
        public bool? Emprestado { get; set; }

        public virtual ICollection<Emprestimo> Emprestimos { get; set; }

        public virtual ICollection<Escritor> Escritores { get; set; }

    }
}
