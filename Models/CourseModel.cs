using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class CourseModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int SeatCount { get; set; }

        [Required]
        public int Fee { get; set; }


        //navigration proprty
        public virtual List<StudentRegistrationModel> StudentRegistration { get; set; }
    }
}
