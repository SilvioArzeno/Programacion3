using System;
using System.Linq.Expressions;
using INTEC.Data.Infraestructure;

namespace INTEC.Repository.Framework
{
    public class Repository2<T> : IRepository<T> where T : class
    {
        public Repository2()
        {
        }

        public DataResult Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public DataResult GetAll()
        {
            throw new NotImplementedException();
        }

        public DataResult GetAll(Expression<Func<T, bool>> specification, params Expression<Func<T, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public DataResult GetById(int id)
        {
            throw new NotImplementedException();
        }

        public DataResult Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public DataResult SaveChanges()
        {
            throw new NotImplementedException();
        }

        public DataResult Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
