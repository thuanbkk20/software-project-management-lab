using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.Classes;
using MyCompanyName.AbpZeroTemplate.Classes.Dto;
using MyCompanyName.AbpZeroTemplate.Schedules.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Schedules
{
    public interface IScheduleAppService
    {
        ListResultDto<ScheduleDto> GetSchedule (GetScheduleInput input);

        ScheduleDto CreateSchedule(CreateScheduleInput input);
    }
}
