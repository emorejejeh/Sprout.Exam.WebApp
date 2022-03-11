using Sprout.Exam.Business.Interfaces;
using Sprout.Exam.Common.Constants;

namespace Sprout.Exam.Business.EmployeeModels
{
    public class Contractual : IEmployeeFactory
    {
        public decimal CalculateSalary(decimal workedDays, decimal absentDays)
        {
            return (Constants.RatePerDay * workedDays);
        }
    }
}
