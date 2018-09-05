using System;
using System.Linq;
using System.Linq.Expressions;
using INTEC.Data.Infraestructure;
using Microsoft.EntityFrameworkCore;

namespace INTEC.Repository.Framework
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationContext context;
        private DbSet<T> dbSet;
        string connectionString = string.Empty;

        public Repository(ApplicationContext context)
        {
            this.context = context ?? throw new ArgumentNullException("Verdugo Pasame la Conexion");
            dbSet = context.Set<T>();
            connectionString = context.Database.GetDbConnection().ConnectionString;
        }

        public DataResult Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public DataResult GetAll()
        {
            DataResult result = new DataResult();

            try
            {
                result.Data = dbSet.ToList();
                result.Successfull = true;
            }
            catch (Exception ex)
            {
                result.LogError(ex);
                result.Successfull = false;
            }

            return result;
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
