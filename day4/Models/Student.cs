using System;
using System.ComponentModel.DataAnnotations;

namespace day4.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }
    }
}