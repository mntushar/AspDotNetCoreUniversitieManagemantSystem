using Manager.BaseManager;
using Manager.Contacts;
using Models;
using Repositories;
using Repositories.Contacts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class DepartmentManager : BaseManager<DepartmentModel>, IDepartmentManager
    {
        private IDepartmentRepositorie _departmentRepositorie;

        public DepartmentManager(IDepartmentRepositorie departmentRepositorie):base(departmentRepositorie)
        {
            _departmentRepositorie = departmentRepositorie;
        }
    }
}
