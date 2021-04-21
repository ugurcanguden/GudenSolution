using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Guden.Core.Entities;

namespace Guden.Core.DataAccess
{
    /// <summary>
    /// Varlıklara eait tip metod tanımlamaları yapılır.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntityRepository<T> where T:class,IEntity,new ()
    {
        T Get(Expression<Func<T,bool>> filter);
        IList<T> GetList(Expression<Func<T, bool>> filter=null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
