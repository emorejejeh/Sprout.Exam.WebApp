
using Sprout.Exam.Business.EmployeeModels;
using Sprout.Exam.Business.Factory;
using Sprout.Exam.Business.Interfaces;
using Sprout.Exam.Business.Services.Interfaces;
using Sprout.Exam.Common.Enums;
using System;

namespace Sprout.Exam.Business.Services
{
    public class EmployeeServiceFactory : EmployeeFactory, IEmployeeServiceFactory
    {
        public override IEmployeeFactory Factory(EmployeeType type)
        {
            switch (type)
            {
                case EmployeeType.Contractual:
                    return new Contractual();
                case EmployeeType.Regular:
                    return new Regular();
                default:
                    throw new ApplicationException(string.Format("This type of employee can not be created"));
            }
        }
    }
}
