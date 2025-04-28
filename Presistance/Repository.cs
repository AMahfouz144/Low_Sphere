    using Microsoft.EntityFrameworkCore;
    using System.Linq.Expressions;
    using Application.Interfaces;
    using Domain.Common;

    namespace Presistance.Core
    {
        public class Repository<T> : IRepository<T> where T : class, IEntity
        {
            private DbSet<T> _store = null;

            protected DbContext dbContext => provider.GetService(typeof(AppDbContext)) as DbContext;
            protected DbSet<T> store => _store ?? dbContext.Set<T>();

            protected IServiceProvider provider;

            public Repository(IServiceProvider provider)
            {
                this.provider = provider;
            }

            public virtual T Add(T item)
            {
                dbContext.Entry(item).State = EntityState.Added;
                return store.Add(item).Entity;
            }

            public virtual void AddRange(List<T> range)
            {
                range.ForEach(obj =>
                {
                    Add(obj);
                });
            }

            public virtual void AddNew(List<T> range)
            {
                range.ForEach(obj =>
                {
                    Add(obj);
                });
            }

            public virtual void Delete(Expression<Func<T, bool>> where)
            {
                T item = store.Where(where).FirstOrDefault();

                if (item != null)
                {
                    store.Remove(item);
                    dbContext.Entry(item).State = EntityState.Deleted;
                }

            }
            public virtual void Delete(T item)
            {
                store.Remove(item);
                dbContext.Entry(item).State = EntityState.Deleted;
            }
            public virtual void Remove(T entity)
            {
                if (entity != null)
                {
                    store.Remove(entity);
                    dbContext.Entry(entity).State = EntityState.Deleted;
                }
            }

            public virtual IQueryable<IGrouping<TKey, T>> GroupBy<TKey>(Expression<Func<T, TKey>> exp)
            {
                return store.GroupBy(exp);
            }

            public virtual void DeleteRange(List<T> range)
            {
                range.ForEach(obj => Delete(obj));
            }

            public virtual IList<T> Get(Expression<Func<T, bool>> where)
            {
                var query = store.Where(where);
                return query.AsNoTracking().ToList();
            }
            public virtual IList<T> GetAll()
            {
                return store.ToList();
            }

            public virtual T Single(Expression<Func<T, bool>> where)
            {
                var result = store.FirstOrDefault(where);
                return result;
            }
            public virtual async Task<T> SingleAsync(Expression<Func<T, bool>> where)
            {
                var result = await store.FirstOrDefaultAsync(where);
                return result;
            }

            public T Single(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes)
            {
                var query = store.AsQueryable();
                foreach (var include in includes)
                    query = query.Include(include);

                var result = query.FirstOrDefault(where);
                return result;
            }

            public async Task<T> SingleAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes)
            {
                var query = store.AsQueryable();
                foreach (var include in includes)
                    query = query.Include(include);

                var result = await query.FirstOrDefaultAsync(where);
                return result;
            }

            public virtual List<T> GetWith(Expression<Func<T, bool>> where)
            {
                var result = store.Where(where).ToList();

                return result;
            }

            public async virtual Task<List<T>> GetWithAsync(Expression<Func<T, bool>> where)
            {
                var result = await store.Where(where).ToListAsync();

                return result;
            }

            public virtual List<T> GetWith(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes)
            {
                var query = store.AsQueryable();
                foreach (var include in includes)
                    query = query.Include(include);

                return query.Where(where).ToList();

            }

            public async virtual Task<List<T>> GetWithAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes)
            {
                var query = store.AsQueryable();
                foreach (var include in includes)
                    query = query.Include(include);

                var result = await query.Where(where).ToListAsync();

                return result;
            }

            public virtual IQueryable<T> Where(Expression<Func<T, bool>> where)
            {
                var query = store.AsQueryable();

                return query.Where(where);
            }


            public virtual T GetById(object id)
            {
                return store.Find(id);
            }

            public virtual T Update(T item)
            {
                store.Attach(item);
                dbContext.Entry(item).State = EntityState.Modified;
                return item;
            }

            public virtual void UpdateRange(List<T> range)
            {
                range.ForEach(obj => Update(obj));
            }


            public virtual int Count(Expression<Func<T, bool>> where)
            {
                return this.store.Count(where);
            }

            public virtual int Count()
            {
                return this.store.Count();
            }

            public virtual bool Any(Expression<Func<T, bool>> where)
            {
                bool res = store.Any(where);
                return res;
            }

            public virtual bool Any()
            {
                return store.Any();
            }


            public List<T> GetPage(int pageIndex, int pageSize, params Expression<Func<T, bool>>[] conditions)
            {
                var query = store.AsQueryable();
                int skipCount = (pageIndex - 1) * pageSize;
                int takeCount = pageSize;

                foreach (var cond in conditions)
                    query = query.Where(cond);

                return query.Skip(skipCount).Take(takeCount).ToList();
            }

            public List<T> GetPage(int pageIndex, int pageSize)
            {
                var query = store.AsQueryable();
                int skipCount = (pageIndex - 1) * pageSize;

                return query.Skip(skipCount).Take(pageSize).ToList();
            }

            public List<T> GetPage(int pageIndex, int pageSize, params Expression<Func<T, object>>[] includes)
            {
                var query = store.AsQueryable();
                int skipCount = (pageIndex - 1) * pageSize;

                foreach (var include in includes)
                    query = query.Include(include);

                return query.Skip(skipCount).Take(pageSize).ToList();
            }


            public T Last(Expression<Func<T, bool>> where)
            {
                var result = store.LastOrDefault(where);
                return result;
            }

            public IQueryable<T> AsQueryable()
            {
                return store.AsQueryable<T>();
            }
        }
    }
