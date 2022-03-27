using Models;
using System.Collections.Generic;

namespace UniversitieManagemantSystem.Models.Department
{
    public class DepartmentDetailsMv
    {
        public int Id { get; set; }
        public string DeptName { get; set; }
        public virtual List<StudentModel> Students { get; set; }
    }
}
