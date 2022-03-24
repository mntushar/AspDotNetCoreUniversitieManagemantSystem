using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Contacts
{
    public interface IBaseRepositorie<T> where T : class
    {
        public bool Add(T entity);
        public bool Update(T entity);
        public bool Remove(T entity);
        public T Get(int? id);
        public ICollection<T> GetAll();
    }
}
