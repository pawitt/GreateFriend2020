using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace TradeBooks.Services
{
    public abstract class ServiceBase<T> : IService<T> where T : class
    {
        private readonly App app;

        public ServiceBase(App app) => this.app = app;
        public IQueryable<T> Query(Expression<Func<T, bool>> criteria) => app.db.Set<T>().Where(criteria);
        public virtual IQueryable<T> All() => Query(x => true);
        //public T Find(params object[] keys)
        //{
        //    return app.db.Set<T>().Find(keys);
        //}
        public virtual T Find(params object[] keys) => app.db.Set<T>().Find(keys);
        public virtual T Add(T item) => app.db.Set<T>().Add(item).Entity;
        public virtual T Remove(T item) => app.db.Set<T>().Remove(item).Entity;
        public virtual T Update(T item) => app.db.Set<T>().Update(item).Entity;
    }
}
