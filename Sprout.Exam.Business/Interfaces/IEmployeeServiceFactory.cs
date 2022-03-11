using Sprout.Exam.Business.Interfaces;
using Sprout.Exam.Common.Enums;

namespace Sprout.Exam.Business.Services.Interfaces
{
    public interface IEmployeeServiceFactory
    {
        IEmployeeFactory Factory(EmployeeType type);
    }
}