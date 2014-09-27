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
    public class TestUpdateParcial
    {
        static void Main()
        {
            using (EditoraServico servico = new EditoraServico())
            {
                Editora editora = servico.ConsultarPorId(2);
                editora.Nome = "FTD";

                Resultado retorno = servico.SalvarEditora(editora);

                Console.WriteLine(retorno.Mensagem);
            }

            Console.ReadKey();
        }
    }
}
