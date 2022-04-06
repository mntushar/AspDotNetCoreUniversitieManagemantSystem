using Manager.BaseManager;
using Manager.Contacts;
using Models;
using Repositories.Contacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager
{
    public class StudentRegristrationManager : BaseManager<StudentRegistrationModel>, IStudentRegristrationManager
    {
        private IStudentRegristrationRepositorie _baseRepositorie;

        public StudentRegristrationManager(IStudentRegristrationRepositorie baseRepositorie) : base(baseRepositorie)
        {
            _baseRepositorie = baseRepositorie;
        }
    }
}
