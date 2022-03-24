using Microsoft.EntityFrameworkCore;
using Models.DbContexts;
using Repositories.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories.BaseRepositorie
{
    public class BaseRepositorie<T> : IBaseRepositorie<T> where T : class
    {
        private UniversityDbContext _db;
        private DbSet<T> Table
        {
            get { return _db.Set<T>(); }
        }

        public BaseRepositorie()
        {
            _db = new UniversityDbContext();
        }

        public virtual bool Add(T entity)
        {
            Table.Add(entity);
            return _db.SaveChanges() > 0;
        }

        public virtual bool Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            return _db.SaveChanges() > 0;
        }

        public virtual bool Remove(T entity)
        {
            Table.Remove(entity);
            return _db.SaveChanges() > 0;
        }

        public virtual T Get(int? id)
        {
            return Table.Find(id);
        }

        public virtual ICollection<T> GetAll()
        {
            return Table.ToList();
        }
    }
}
