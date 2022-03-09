using Sprout.Exam.Business.Services.Interfaces;
using Sprout.Exam.Common.DTOs;
using Sprout.Exam.Dal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        public IEnumerable<EmployeeDto> GetAll()
        {
            var response = new List<EmployeeDto>();
            using (var context = new SproutExamDbEntities())
            {
                var lstEmployee = context.Employees.ToList();
                foreach (var emp in lstEmployee)
                {
                    var employee = new EmployeeDto
                    {
                        Birthdate = emp.Birthdate.ToString("yyyy-MM-dd"),
                        FullName = emp.FullName,
                        Id = emp.Id,
                        Tin = emp.TIN,
                        TypeId = emp.EmployeeTypeId
                    };
                    response.Add(employee);
                }
            }
            return response;
        }

        public EmployeeDto GetById(int id)
        {
            using (var context = new SproutExamDbEntities())
            {
                var emp = context.Employees.FirstOrDefault(i => i.Id == id);
                return new EmployeeDto
                {
                    Birthdate = emp.Birthdate.ToString("yyyy-MM-dd"),
                    FullName = emp.FullName,
                    Id = emp.Id,
                    Tin = emp.TIN,
                    TypeId = emp.EmployeeTypeId
                };
            }
        }
        public async Task<int> Insert(CreateEmployeeDto employee)
        {
            using (var context = new SproutExamDbEntities())
            {
                var emp = new Employee
                {
                    EmployeeTypeId = employee.TypeId,
                    Birthdate = employee.Birthdate,
                    FullName = employee.FullName,
                    TIN = employee.Tin
                };
                context.Employees.Add(emp);
                await context.SaveChangesAsync();
                return emp.Id;
            }
        }

        public async Task<EditEmployeeDto> Update(EditEmployeeDto employee)
        {
            using (var context = new SproutExamDbEntities())
            {
                var result = context.Employees.SingleOrDefault(b => b.Id == employee.Id);
                if (result != null)
                {
                    result.FullName = employee.FullName;
                    result.Birthdate = employee.Birthdate;
                    result.EmployeeTypeId = employee.TypeId;
                    result.TIN = employee.Tin;
                    await context.SaveChangesAsync();
                }
                return employee;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var isDeleted = true;
            using (var context = new SproutExamDbEntities())
            {
                var result = context.Employees.SingleOrDefault(b => b.Id == id);
                if (result != null)
                {
                    context.Employees.Remove(result);
                    await context.SaveChangesAsync();
                }
                else
                    isDeleted = false;
            }
            return isDeleted;
        }
    }
}
