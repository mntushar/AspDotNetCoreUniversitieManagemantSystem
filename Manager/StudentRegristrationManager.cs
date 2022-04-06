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
        private IStudentRegristration _baseRepositorie;

        public StudentRegristrationManager(IStudentRegristration baseRepositorie) : base(baseRepositorie)
        {
            _baseRepositorie = baseRepositorie;
        }
    }
}
