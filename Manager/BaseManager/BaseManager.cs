using Manager.Contacts;
using Repositories.Contacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.BaseManager
{
    public abstract class BaseManager<T> : IBaseManager<T> where T : class
    {
        private IBaseRepositorie<T> _baseRepositorie;

        public BaseManager(IBaseRepositorie<T> baseRepositorie)
        {
            _baseRepositorie = baseRepositorie;
        }

        public bool Add(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Get(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
