﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Exam.Common.DTOs
{
    public abstract class BaseSaveEmployeeDto
    {
        public string FullName { get; set; }
        public string Tin { get; set; }
        public DateTime Birthdate { get; set; }
        public int TypeId { get; set; }
    }
}
