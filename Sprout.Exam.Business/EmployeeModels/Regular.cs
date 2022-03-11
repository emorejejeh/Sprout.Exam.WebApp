using Sprout.Exam.Business.Interfaces;
using Sprout.Exam.Common.Constants;
using System;

namespace Sprout.Exam.Business.EmployeeModels
{
    public class Regular : IEmployeeFactory
    {
        public decimal CalculateSalary(decimal workedDays, decimal absentDays)
        {
            var tax = Constants.Salary * Convert.ToDecimal(0.12);
            var deductions = Constants.Salary / (Constants.TotalWorkedDays - absentDays);
            return (Constants.Salary - deductions - tax);
        }
    }
}
