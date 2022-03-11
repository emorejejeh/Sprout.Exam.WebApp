
using Sprout.Exam.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace Sprout.Exam.Common.DTOs
{
    public class CalculateDto
    {
        public EmployeeType Type { get; set; }
        [Range(0, int.MaxValue)]
        public decimal WorkedDays { get; set; }
        [Range(0, int.MaxValue)]
        public decimal AbsentDays { get; set; }
    }
}
