using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Etools.Entities.Repositories
{
    public class GenericRepository<T> : ContextRepository where T : class
    {
        private static GenericRepository<T> _instance;
        public GenericRepository()
        {

        }

        public static GenericRepository<T> Inst
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GenericRepository<T>();
                }

                return _instance;
            }
        }
        public DbSet<T> Set
        {
            get
            {
                return JoinContext.Set<T>();
            }
        }


        public void Delete(object id)
        {
            T exists = JoinContext.Set<T>().Find(id);
            JoinContext.Set<T>().Remove(exists);
        }

        public List<T> GetAll()
        {
            return JoinContext.Set<T>().ToList();
        }

        public T GetById(object id)
        {
            return JoinContext.Set<T>().Find(id);
        }

        public void Insert(T obj)
        {
            JoinContext.Set<T>().Add(obj);
            JoinContext.SaveChanges();

        }
        public List<M> GetResult<M>(Expression<Func<T, bool>> whereClause, Expression<Func<T, M>> selectClause)
        {
            return JoinContext.Set<T>().Where(whereClause).Select(selectClause).ToList();
        }

        public async Task<int> Add(T model, int userId)
        {
            try
            {
                dynamic entity = model;
                entity.CreatedAt = DateTime.UtcNow;
                entity.CreatedBy = userId;
                entity.LastUpdated = DateTime.UtcNow;
                entity.UpdatedBy = userId;

                await JoinContext.AddAsync(model);
                await JoinContext.SaveChangesAsync(true);
                return entity.Id;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public async Task<int> Update(T model, int userId)
        {


            dynamic entity = (dynamic)model;
            entity.LastUpdated = DateTime.UtcNow;
            entity.UpdatedBy = userId;
            JoinContext.Update(model);
            await JoinContext.SaveChangesAsync();
            return entity.Id;
        }

        public virtual T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes)
        {

            IQueryable<T> query = JoinContext.Set<T>();

            foreach (Expression<Func<T, object>> include in includes)
                query = query.Include(include);

            return query.FirstOrDefault(filter);

        }

        public M FirstOrDefaultResult<M>(Expression<Func<T, bool>> whereClause, Expression<Func<T, M>> selectClause)
        {


            return JoinContext.Set<T>().Where(whereClause).Select(selectClause).FirstOrDefault();

        }
        public async Task<int> Delete(T model, int userId)
        {

            dynamic entity = (dynamic)model;
            entity.IsActive = false;
            entity.LastUpdated = DateTime.UtcNow;
            entity.UpdatedBy = userId;

            JoinContext.Update(model);
            await JoinContext.SaveChangesAsync();
            return entity.Id;

        }

        //public void Save()
        //{
        //    JoinContext.Set<T>().SaveChanges();
        //}

        //public void Update(T obj)
        //{
        //    JoinContext.Set<T>().Attach(obj);
        //    JoinContext.Set<T>().Entry(obj).State = EntityState.Modified;
        //}
    }
}
