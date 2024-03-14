using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public abstract class Repository<T> : IDisposable where T : class
    {
        protected DatabaseRPP Context { get; set; }

        protected DbSet<T> Entities { get; set; }
        public Repository(DatabaseRPP context)
        {
            Context = context;
            Entities = context.Set<T>();

        }
        public virtual void Dispose()
        {
            Context.Dispose();
        }

        public virtual IQueryable<T> GetAll()
        {
            var query = from entity in Entities
                        select entity;
            return query;
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public virtual int Add(T entity, bool saveChanges = true)
        {
            Entities.Add(entity);
            return saveChanges ? SaveChanges() : 0;
        }

        public abstract int Update(T entity, bool saveChanges = true);

        public virtual int Remove (T entity, bool saveChanges = true)
        {
            Entities.Attach(entity);
            Entities.Remove(entity);
            return saveChanges ? SaveChanges() : 0;
        }
    }
}
