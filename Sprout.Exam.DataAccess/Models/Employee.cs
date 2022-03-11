using System;
using System.ComponentModel.DataAnnotations;

namespace Sprout.Exam.DataAccess.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime Birthdate { get; set; }
        public string TIN { get; set; }
        public int EmployeeTypeId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
