using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cubo.OnlineLibrary.Dominio
{
    [Table("TB_USUARIO")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_USUARIO")]
        public int? Codigo { get; set; }

        [Column("NM_USUARIO")]
        public string Nome { get; set; }

        [Column("DS_LOGIN")]
        public string Login { get; set; }

        [Column("DS_SENHA")]
        public string Senha { get; set; }

        [Column("QT_EMPRESTIMOS_DISPONIVEL")]
        public byte? QtdeEmprestimosDisponivel { get; set; }

        public virtual ICollection<Emprestimo>
            Emprestimos { get; set; }

    }
}
