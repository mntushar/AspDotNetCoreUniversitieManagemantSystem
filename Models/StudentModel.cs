using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        [ForeignKey("Department")]
        public int DeptId { get; set; }


        //navigration proprty
        public virtual DepartmentModel Department { get; set; }
        public virtual StudentRegistrationModel StudentRegistration { get; set; }
    }
}
