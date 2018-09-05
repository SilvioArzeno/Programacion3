using System;
using System.Linq.Expressions;
using INTEC.Data.Infraestructure;

namespace INTEC.Repository.Framework
{
    public interface IRepository<T>
    {
        DataResult GetAll();
        DataResult GetAll(Expression<Func<T, bool>> specification, params Expression<Func<T, object>>[] includeProperties);
        DataResult GetById(int id);
        DataResult Insert(T entity);
        DataResult Update(T entity);
        DataResult Delete(T entity);

        DataResult SaveChanges();
    }
}
