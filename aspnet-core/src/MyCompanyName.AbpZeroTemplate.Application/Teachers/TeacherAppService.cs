using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using MyCompanyName.AbpZeroTemplate.Schedules;
using MyCompanyName.AbpZeroTemplate.Schedules.Dto;
using MyCompanyName.AbpZeroTemplate.Teachers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Teachers
{
    public class TeacherAppService: AbpZeroTemplateAppServiceBase, ITeacherAppService
    {
        private readonly IRepository<Teacher> _teacherRepository;

        public TeacherAppService(IRepository<Teacher> teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public ListResultDto<TeacherDto> GetTeacher(GetTeacherInput input)
        {
            var teachers = _teacherRepository.GetAll().WhereIf(!input.Name.IsNullOrEmpty(), t => t.Name.Contains(input.Name)).OrderBy(t=>t.Name).ToList();
            return new ListResultDto<TeacherDto>(ObjectMapper.Map<List<TeacherDto>>(teachers));
        }
    }
}
