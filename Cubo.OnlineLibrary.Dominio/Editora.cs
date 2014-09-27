using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cubo.OnlineLibrary.Dominio
{
    //[Table("TB_EDITORA")]
    public class Editora
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Column("ID_EDITORA")]
        public int? Codigo { get; set; }

        //[Column("NR_CNPJ")]
        public string CNPJ { get; set; }

        //[Column("NM_EDITORA")]
        public string Nome { get; set; }

        public virtual ICollection<Livro> Livros { get; set; }

        public virtual ICollection<EditoraLog> Logs { get; set; }

        public Editora()
        {
            Logs = new HashSet<EditoraLog>();
            Livros = new HashSet<Livro>();
        }

    }
}
