using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace TradeBooks.Services
{
    public interface IService<T> where T : class
    {
        IQueryable<T> Query(Expression<Func<T, bool>> criteria);
        IQueryable<T> All();
        T Find(params object[] keys);

        T Add(T item);
        T Remove(T item);
        T Update(T item);
    }
}
