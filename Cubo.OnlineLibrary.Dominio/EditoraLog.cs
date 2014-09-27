using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubo.OnlineLibrary.Dominio
{
    [Table("TB_EDITORA_LOG")]
    public class EditoraLog
    {
        [Key]
        [Column("ID_EDITORA", Order=1)]
        public int? Id { get; set; }

        [ForeignKey("Id")]
        public virtual Editora Editora { get; set; }

        [Key]
        [Column("DT_LOG", Order=2)]
        public DateTime? DataLog { get; set; }

        [Column("DS_LOG")]
        public string Descricao { get; set; }

    }
}
