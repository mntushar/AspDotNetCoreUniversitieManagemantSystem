using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Contacts
{
    public interface IBaseManager<T> where T : class
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Remove(T entity);
        T Get(int? id);
        ICollection<T> GetAll();
    }
}
