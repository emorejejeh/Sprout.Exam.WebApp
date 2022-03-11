using System.ComponentModel.DataAnnotations;

namespace Sprout.Exam.Common.DTOs
{
    public class EditEmployeeDto: BaseSaveEmployeeDto
    {
        [Required]
        public int Id { get; set; }
    }
}
