using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversitieManagemantSystem.Models.Student
{
    public class StudentCreateMv
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [Required, Display(Name = "Department Name")]
        public int DeptId { get; set; }
        public List<SelectListItem> Departments { get; set; }
    }
}
