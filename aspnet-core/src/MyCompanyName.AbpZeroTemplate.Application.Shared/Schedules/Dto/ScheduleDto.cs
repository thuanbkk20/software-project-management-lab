using MyCompanyName.AbpZeroTemplate.Classes.Dto;
using MyCompanyName.AbpZeroTemplate.Teachers.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompanyName.AbpZeroTemplate.Schedules.Dto
{
    public class ScheduleDto
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public ClassRefDto Class { get; set; }

        public TeacherRefDto Teacher { get; set; }
    }
}
