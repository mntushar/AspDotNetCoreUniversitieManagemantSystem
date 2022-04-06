using Manager.BaseManager;
using Manager.Contacts;
using Models;
using Repositories.Contacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager
{
    public class CourseManager : BaseManager<CourseModel>, ICourseManager
    {
        private ICourseRepositorie _courseRepositore;

        public CourseManager(ICourseRepositorie courseRepositore) : base(courseRepositore)
        {
            _courseRepositore = courseRepositore;
        }
    }
}
