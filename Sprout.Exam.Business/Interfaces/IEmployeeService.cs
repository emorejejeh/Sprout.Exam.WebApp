using Sprout.Exam.Common.DTOs;
using Sprout.Exam.Dal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Services.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetAll();
        EmployeeDto GetById(int id);
        Task<bool> Delete(int id);
        Task<int> Insert(CreateEmployeeDto employee);
        Task<EditEmployeeDto> Update(EditEmployeeDto employee);
    }
}