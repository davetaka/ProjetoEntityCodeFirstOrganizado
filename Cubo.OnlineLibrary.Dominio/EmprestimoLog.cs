using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cubo.OnlineLibrary.Dominio
{
    [Table("TB_EMPRESTIMO_LOG")]
    public class EmprestimoLog
    {
        [Key]
        [Column("ID_LIVRO", Order=1)]
        public int? LivroId { get; set; }

        [Key]
        [Column("ID_USUARIO", Order=2)]
        public int? UsuarioId { get; set; }

        [ForeignKey("LivroId,UsuarioId")]
        public virtual Emprestimo Emprestimo { get; set; }

        [Key]
        [Column("DT_LOG", Order=3)]
        public DateTime? DataLog { get; set; }

        [Column("NR_IP")]
        public string NumeroIP { get; set; }
    }
}
