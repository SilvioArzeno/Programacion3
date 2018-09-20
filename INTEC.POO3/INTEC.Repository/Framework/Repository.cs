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
            if(context == null)
            {
                throw new ArgumentNullException("Verdugo Pasame la Conexion");
            }

            this.context = context;
            dbSet = context.Set<T>();
            connectionString = context.Database.GetDbConnection().ConnectionString;
        }

        //DELETE FROM TABLA
        public DataResult Delete(T entity)
        {
            DataResult result = new DataResult();

            try
            {
                dbSet.Remove(entity);
                context.SaveChanges();
                result.Successfull = true;
            }
            catch (Exception ex)
            {
                result.LogError(ex);
                result.Successfull = false;
            }

            return result;
        }

        //SELECT * FROM Tabla
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

        //SELECT * FROM TABLA WHERE campo = (n)
        public DataResult GetAll(
            Expression<Func<T, bool>> specification, 
             params Expression<Func<T, object>>[] includeProperties)
        {
            DataResult result = new DataResult();

            try
            {
                if(includeProperties.Length > 0)
                {
                    result.Data = GetAllIncluding(includeProperties)
                        .Where(specification).ToList();

                    result.Successfull = true;
                }
            }
            catch (Exception ex)
            {
                result.LogError(ex);
                result.Successfull = false;
            }

            return result;
        }

        //SELECT * FROM TABLA WHERE Id = 1
        public DataResult GetById(int id)
        {
            DataResult result = new DataResult();

            try
            {
                result.Data = dbSet.Find(id);
                result.Successfull = true;
            }
            catch (Exception ex)
            {
                result.LogError(ex);
                result.Successfull = false;
            }

            return result;
        }

        //INSERT INTO TABLA (field1, field2) VALUES (values1, values2)
        public DataResult Insert(T entity)
        {
            DataResult result = new DataResult();

            try
            {
                dbSet.Add(entity);
                context.SaveChanges();
                result.Successfull = true;
            }
            catch (Exception ex)
            {
                result.LogError(ex);
                result.Successfull = false;
            }

            return result;
        }

        public DataResult Insert(T[] entities)
        {
            DataResult result = new DataResult();

            try
            {
                dbSet.AddRange(entities);
                context.SaveChanges();
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

        //UPDATE TABLE SET field1 = value1, field2 = value2
        public DataResult Update(T entity)
        {
            DataResult result = new DataResult();

            try
            {
                context.SaveChanges();
                result.Data = entity;
                result.Successfull = true;
            }
            catch (Exception ex)
            {
                result.LogError(ex);
                result.Successfull = false;
            }

            return result;
        }

        private IQueryable<T> GetAllIncluding(
            params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = dbSet;
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include<T, object>(includeProperty);
            }

            return queryable;
        }
    }
}
