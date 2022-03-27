using Manager.BaseManager;
using Manager.Contacts;
using Models;
using Repositories.Contacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager
{
    public class StudentManager : BaseManager<StudentModel>, IStudentManager
    {
        private IStudentRepositore _studentRepositore;
        private IDepartmentManager _departmentManager;

        public StudentManager(IStudentRepositore studentRepositore) : base(studentRepositore)
        {
            _studentRepositore = studentRepositore;
        }

        public StudentManager(IStudentRepositore studentRepositore, IDepartmentManager departmentManager) : base(studentRepositore)
        {
            _studentRepositore = studentRepositore;
            _departmentManager = departmentManager;
        }

        public override bool Add(StudentModel entity)
        {
            DepartmentModel department = _departmentManager.Get(entity.DeptId);
            if (department != null)
            {
                 return _studentRepositore.Add(entity);
            }
            else
            {
                return false;
            }
        }
    }
}
