using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cubo.OnlineLibrary.Dominio;
using Cubo.OnlineLibrary.Dominio.Contexto;

namespace Cubo.OnlineLibrary.TestDominio
{
    class Program
    {
        static void Main(string[] args)
        {
            using (BibliotecaContexto contexto
                = new BibliotecaContexto())
            {

                foreach (Editora editora
                    in contexto.Editoras.ToList())
                {
                    Console.WriteLine("Editora: " + editora.Nome);
                    Console.WriteLine("===========================");

                    foreach (Livro livro in editora.Livros)
                    {
                        Console.WriteLine("  Livro: " + livro.Nome);
                        Console.WriteLine("  --------------------------");

                        foreach (Emprestimo emprestimo in livro.Emprestimos)
                        {
                            Console.WriteLine("********************");

                            Console.WriteLine("Empréstimo: " +
                                ((DateTime)emprestimo.DataEmprestimo).ToString("dd/MM/yyyy"));

                            Console.WriteLine("Usuário: " +
                                emprestimo.Usuario.Nome);

                            Console.WriteLine("Status: " +
                                emprestimo.Status);

                            Console.WriteLine("********************");
                        }
                    }
                }

                Console.ReadKey();
            }
        }
    }
}
