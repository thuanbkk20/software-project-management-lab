using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompanyName.AbpZeroTemplate.Teachers.Dto
{
    public class TeacherRefDto: EntityDto
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }
    }
}
