using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Cubo.OnlineLibrary.Dominio.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private DbContext contexto;

        public Repositorio(DbContext contexto)
        {
            this.contexto = contexto;
        }

        private DbSet<T> SetDados
        {
            get { return contexto.Set<T>(); }
        }

        public IQueryable<T> Listar()
        {
            return SetDados.AsQueryable();
        }

        public IQueryable<T> Filtrar(Func<T, bool> criterio)
        {
            return SetDados.Where(criterio).AsQueryable();
        }

        public IQueryable<T> FiltrarPorExpressao(System.Linq.Expressions.Expression<Func<T, bool>> criterio)
        {
            var expressao = (BinaryExpression)criterio.Body;
            string nomeProp = ((MemberExpression)expressao.Left).Member.Name;

            return SetDados.Where(criterio).AsQueryable();
        }

        public T Consultar(params object[] chaves)
        {
            return SetDados.Find(chaves);
        }

        public T Consultar(Func<T, bool> criterio)
        {
            return SetDados.FirstOrDefault(criterio);
        }

        public bool Contem(Func<T, bool> criterio)
        {
            return SetDados.Any(criterio);
        }

        public int Quantidade()
        {
            return SetDados.Count();
        }

        public int Quantidade(Func<T, bool> criterio)
        {
            return SetDados.Count(criterio);
        }

        public T Adicionar(T t)
        {
            return SetDados.Add(t);
        }

        public void Alterar(T t)
        {
            var entrada = contexto.Entry(t);
            SetDados.Attach(t);
            entrada.State = EntityState.Modified;
        }

        public void Alterar(T t, params string[] excluidos)
        {
            var entrada = contexto.Entry(t);
            SetDados.Attach(t);
            entrada.State = EntityState.Modified;

            foreach (string atributo in excluidos)
            {
                entrada.Property(atributo).IsModified = false;
            }
        }

        public void Remover(params object[] chaves)
        {
            this.Remover(this.Consultar(chaves));
        }

        public void Remover(T t)
        {
            SetDados.Remove(t);
        }

        public void Remover(Func<T, bool> criterio)
        {
            foreach (T item in this.Filtrar(criterio))
            {
                this.Remover(item);
            }
        }
    }
}
