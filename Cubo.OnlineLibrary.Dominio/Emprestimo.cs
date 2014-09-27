using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cubo.OnlineLibrary.Dominio
{
    [Table("TB_EMPRESTIMO")]
    public class Emprestimo
    {
        //[Key]
        //[Column("ID_EMPRESTIMO")]
        //public int? Codigo { get; set; }

        //Sabor nº 1 - ForeignKey
        [Key]
        [Column("ID_LIVRO", Order=1)]
        public int? LivroId { get; set; }
        [ForeignKey("LivroId")]
        public virtual Livro Livro { get; set; }

        //Sabor nº 2 - ForeignKey
        [Key]
        [Column("ID_USUARIO", Order=2)]
        [ForeignKey("Usuario")]
        public int? UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        [Column("DT_EMPRESTIMO")]
        public DateTime? DataEmprestimo { get; set; }

        [Column("DT_DEVOLUCAO")]
        public DateTime? DataDevolucao { get; set; }

        [NotMapped]
        public string Status
        {
            get
            {
                if (DataDevolucao == null)
                {
                    return "Pendente";
                }
                else
                {
                    return "Efetivado";
                }
            }
        }
    }
}
