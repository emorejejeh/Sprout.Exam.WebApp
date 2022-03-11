using Sprout.Exam.Business.Services.Interfaces;
using Sprout.Exam.Common.DTOs;
using Sprout.Exam.Common.Enums;
using Sprout.Exam.DataAccess.Data;
using Sprout.Exam.DataAccess.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeDbContext _context;
        private readonly IEmployeeServiceFactory _employeeFactory;
        public EmployeeService(EmployeeDbContext context, IEmployeeServiceFactory employeeFactory)
        {
            _context = context;
            _employeeFactory = employeeFactory;
        }
        public IEnumerable<EmployeeDto> GetAll()
        {
            var response = new List<EmployeeDto>();
            var lstEmployee = _context.Employee.ToList();
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
            return response;
        }

        public EmployeeDto GetById(int id)
        {
            var emp = _context.Employee.FirstOrDefault(i => i.Id == id);
            if (emp == null)
                return null;
            return new EmployeeDto
            {
                Birthdate = emp.Birthdate.ToString("yyyy-MM-dd"),
                FullName = emp.FullName,
                Id = emp.Id,
                Tin = emp.TIN,
                TypeId = emp.EmployeeTypeId
            };
        }
        public async Task<int> Insert(CreateEmployeeDto employee)
        {
            var emp = new Employee
            {
                EmployeeTypeId = employee.TypeId,
                Birthdate = employee.Birthdate,
                FullName = employee.FullName,
                TIN = employee.Tin
            };
            _context.Employee.Add(emp);
            await _context.SaveChangesAsync();
            return emp.Id;
        }

        public async Task<EditEmployeeDto> Update(EditEmployeeDto employee)
        {
            var result = _context.Employee.SingleOrDefault(b => b.Id == employee.Id);
            if (result != null)
            {
                result.FullName = employee.FullName;
                result.Birthdate = employee.Birthdate;
                result.EmployeeTypeId = employee.TypeId;
                result.TIN = employee.Tin;
                await _context.SaveChangesAsync();
            }
            return employee;
        }

        public async Task<bool> Delete(int id)
        {
            var isDeleted = true;
            var result = _context.Employee.SingleOrDefault(b => b.Id == id);
            if (result != null)
            {
                _context.Employee.Remove(result);
                await _context.SaveChangesAsync();
            }
            else
                isDeleted = false;
            return isDeleted;
        }

        public decimal CalculateSalary(CalculateDto computeDto)
        {
            return _employeeFactory.Factory(computeDto.Type).CalculateSalary(computeDto.WorkedDays, computeDto.AbsentDays);
        }
    }
}
