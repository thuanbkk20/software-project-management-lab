using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.Schedules.Dto;
using MyCompanyName.AbpZeroTemplate.Teachers.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompanyName.AbpZeroTemplate.Teachers
{
    public interface ITeacherAppService
    {
        ListResultDto<TeacherDto> GetTeacher(GetTeacherInput input);
    }
}
