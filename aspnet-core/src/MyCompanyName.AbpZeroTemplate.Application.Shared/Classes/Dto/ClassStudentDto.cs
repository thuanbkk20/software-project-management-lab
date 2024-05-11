using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompanyName.AbpZeroTemplate.Classes.Dto
{
    public class ClassStudentDto: EntityDto
    {
        public string Name { get; set; }

        public string AcademicYear { get; set; }

        public string Address { get; set; }
    }
}
