using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cubo.OnlineLibrary.Dominio.Repositorio
{
    public interface IRepositorio<T> where T : class
    {
        IQueryable<T> Listar();
        IQueryable<T> Filtrar(Func<T, bool> criterio);
        IQueryable<T> FiltrarPorExpressao(Expression<Func<T, bool>> criterio);
        T Consultar(params object[] chaves);
        T Consultar(Func<T, bool> criterio);
        bool Contem(Func<T, bool> criterio);
        int Quantidade();
        int Quantidade(Func<T, bool> criterio);
        T Adicionar(T t);
        void Alterar(T t);

        void Alterar(T t, params string[] excluidos);

        void Remover(params object[] chaves);
        void Remover(T t);
        void Remover(Func<T, bool> criterio);
    }
}
