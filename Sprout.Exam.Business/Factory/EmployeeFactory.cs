using Sprout.Exam.Business.Interfaces;
using Sprout.Exam.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Factory
{
    public abstract class EmployeeFactory
    {
        public abstract IEmployeeFactory Factory(EmployeeType type);
    }
}
