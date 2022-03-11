namespace Sprout.Exam.Business.Interfaces
{
    public interface IEmployeeFactory
    {
        decimal CalculateSalary(decimal workedDays, decimal absentDays);
    }
}
