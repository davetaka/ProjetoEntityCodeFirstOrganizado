using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cubo.OnlineLibrary.Dominio.Contexto;
using Cubo.OnlineLibrary.Dominio;
using System.IO;

namespace Cubo.OnlineLibrary.TestDominio
{
    public class TestConsultas
    {
        static void Main()
        {
            BibliotecaContexto dba = new BibliotecaContexto();
            BibliotecaContexto dbb = new BibliotecaContexto();

            IQueryable<Editora> listaEditoras = dba.Editoras;
            IQueryable<Livro> listaLivros = dbb.Livros;

            var novaListaEditora = from editora in listaEditoras
                                   where editora.Nome.Contains("E")
                                   select new
                                   {
                                       IdEditora = editora.Codigo,
                                       NomeEditora = editora.Nome
                                   };

            var novaListaLivro = from livro in listaLivros
                                 where livro.Nome.Contains("L")
                                 select new
                                 {
                                     IdEditora = livro.EditoraId,
                                     NomeLivro = livro.Nome
                                 };

            var listaJuncao = from editora in novaListaEditora.ToList()
                              join livro in novaListaLivro.ToList()
                              on editora.IdEditora equals livro.IdEditora
                              orderby editora.NomeEditora ascending,
                              livro.NomeLivro ascending
                              select new
                              {
                                  NomeEditora = editora.NomeEditora,
                                  NomeLivro = livro.NomeLivro
                              };

            foreach (var item in listaJuncao)
            {
                Console.WriteLine(item.NomeEditora + " > " + item.NomeLivro);
            }

            dba.Dispose();
            dbb.Dispose();

            Console.ReadKey();
        }
    }
}
