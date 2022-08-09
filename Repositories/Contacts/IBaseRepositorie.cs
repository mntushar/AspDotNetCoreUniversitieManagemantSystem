using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Contacts
{
    public interface IBaseRepositorie<T> where T : class
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Remove(T entity);
        T Get(int? id);
        ICollection<T> GetAll();
    }
}
