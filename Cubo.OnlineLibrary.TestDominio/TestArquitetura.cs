using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cubo.OnlineLibrary.Dominio;
using Cubo.OnlineLibrary.Dominio.Servico;
using Cubo.OnlineLibrary.Framework;

namespace Cubo.OnlineLibrary.TestDominio
{
    class TestArquitetura
    {
        static void Main()
        {
            using (EditoraServico servico = new EditoraServico())
            {
                Editora editora = new Editora()
                {
                    Nome = "Vagalume6",
                    CNPJ = "1234567896"
                };

                editora.Logs.Add(
                    new EditoraLog() { 
                        DataLog = DateTime.Now,
                        Descricao = "xpto",
                        Editora = editora
                    }
                );

                Resultado retorno = servico.SalvarEditora(editora);

                Console.WriteLine(retorno.Mensagem);
            }

            Console.ReadKey();

        }
    }
}
