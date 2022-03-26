using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class DepartmentModel
    {
        public int Id { get; set; }

        [Required, Display(Name = "Department Name")]
        public string DeptName { get; set; }


        //navigration proprty
        public virtual List<StudentModel> Students { get; set; }
    }
}
