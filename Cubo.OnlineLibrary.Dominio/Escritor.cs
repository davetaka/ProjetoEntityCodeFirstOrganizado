using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubo.OnlineLibrary.Dominio
{
    public class Escritor
    {
        public int? Codigo { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Livro> Livros { get; set; }


    }
}
