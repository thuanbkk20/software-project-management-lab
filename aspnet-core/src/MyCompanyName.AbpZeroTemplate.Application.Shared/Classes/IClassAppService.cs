using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.Classes.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCompanyName.AbpZeroTemplate.Classes
{
    public interface IClassAppService
    {
        ListResultDto<ClassListDto> GetClass(GetClassInput input);

        ClassListDto GetClassDetail(GetClassStudentInput input);

        ListResultDto<ClassStudentDto> GetClassStudent(GetClassStudentInput input);
    }
}
