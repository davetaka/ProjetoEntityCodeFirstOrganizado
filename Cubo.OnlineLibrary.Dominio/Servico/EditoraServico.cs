using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cubo.OnlineLibrary.Dominio.Contexto;
using Cubo.OnlineLibrary.Dominio.Repositorio;
using Cubo.OnlineLibrary.Framework;

namespace Cubo.OnlineLibrary.Dominio.Servico
{
    public class EditoraServico : IDisposable
    {
        private BibliotecaContexto contexto;
        private IRepositorio<Editora> repoEditora;
        private IRepositorio<EditoraLog> repoLog;

        public EditoraServico()
        {
            contexto = new BibliotecaContexto();
            repoEditora = new Repositorio<Editora>(contexto);
            repoLog = new Repositorio<EditoraLog>(contexto);
        }

        public IQueryable<Editora> ListarEditoras()
        {
            return repoEditora.Listar();
        }

        public Editora ConsultarPorId(int id)
        {
            return repoEditora.Consultar(id);
        }

        public Resultado SalvarEditora(Editora editora)
        {
            Resultado retorno = new Resultado("Editora registrada com sucesso!");

            try
            {
                if (editora.Codigo == null)
                {
                    repoEditora.Adicionar(editora);
                    foreach (EditoraLog log in editora.Logs)
                    {
                        repoLog.Adicionar(log);
                    }
                }
                else
                {
                    repoEditora.Alterar(editora, "CNPJ");
                }
            }
            catch (Exception ex)
            {
                retorno.ErroExecucao(ex.Message);
            }

            //int? teste = contexto.Entry(editora).Entity.Codigo;
            contexto.SaveChanges();

            return retorno;
        }

        public Resultado ExcluirEditora(int id)
        {
            Resultado retorno = new Resultado("Editora excluida com sucesso!");

            try
            {
                repoEditora.Remover(id);

                contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                retorno.ErroExecucao(ex.Message);
            }

            return retorno;
        }

        public void Dispose()
        {
            if (contexto != null)
            {
                contexto.Dispose();
            }
        }
    }
}
