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
        //DELETE FROM TABLE
        public DataResult Delete(T entity)
        {
            DataResult result = new DataResult();
            try
            {
                dbSet.Remove(entity);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                result.LogError(ex);
                result.Successfull = false;
            }
            return result;
        }
        //GET ALL FROM TABLE
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
            DataResult result = new DataResult();
            try
            {
                if(includeProperties.Length > 0)
                {
                    result.Data = GetAllIncluding(includeProperties).Where(specification).ToList();
                }
            }
            catch(Exception x)
            {
                result.LogError(x);
            }
            return result;
        }

        private IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = dbSet;
            foreach(Expression<Func<T, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include(includeProperty);
            }

            return queryable;
        }

        public DataResult GetById(int id)
        {
            DataResult result = new DataResult();
            try
            {
                result.Data = dbSet.Find(id);
                result.Successfull = true;
            }
            catch(Exception ex)
            {
                result.LogError(ex);
                result.Successfull = false;
            }

            return result;
        }
        //INSERT TO TABLE
        public DataResult Insert(T entity)
        {
            DataResult result = new DataResult();
            try
            {
                dbSet.Add(entity);
                //context.SaveChanges();
                result.Successfull = true;
            }
            catch (Exception ex)
            {
                result.LogError(ex);
                result.Successfull = false;
            }

            return result;
        }
        //INSERT TO TABLE
        public DataResult Insert(T[] entities)
        {
            DataResult result = new DataResult();
            try
            {
                dbSet.AddRange(entities);
                //context.SaveChanges();
                result.Successfull = true;
            }
            catch (Exception ex)
            {
                result.LogError(ex);
                result.Successfull = false;
            }

            return result;
        }
        public Boolean SaveChanges()
        {
           return context.SaveChanges() > 0;
        }
        //UPDATE TO TABLE
        public DataResult Update(T entity)
        {
            DataResult result = new DataResult();

            try
            {
                context.SaveChanges();
                result.Data = entity;
                result.Successfull = true;
            }
            catch(Exception ex)
            {
                result.LogError(ex);
                result.Successfull = false;
            }
            return result;
        }
    }
}
