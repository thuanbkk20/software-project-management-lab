using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using AutoMapper;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using MyCompanyName.AbpZeroTemplate.Classes.Dto;
using MyCompanyName.AbpZeroTemplate.Schedules.Dto;
using MyCompanyName.AbpZeroTemplate.Students;
using MyCompanyName.AbpZeroTemplate.Teachers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MyCompanyName.AbpZeroTemplate.Classes
{
    public class ClassAppService : AbpZeroTemplateAppServiceBase, IClassAppService
    {
        private readonly IRepository<Class> _classRepository;
        private readonly IRepository<TeacherUser> _teacherUserReposioty;
        private readonly IRepository<Teacher> _teacherRepository;
        private readonly IRepository<ClassStudent> _classStudentReposioty;
        private readonly IRepository<Student> _studentRepository;

        public ClassAppService(IRepository<Class> classRepository,
            IRepository<Teacher> teacherRepository,
            IRepository<TeacherUser> teacherUserReposioty,
            IRepository<ClassStudent> classStudentRepository,
            IRepository<Student> studentRepository)
        {
            _classRepository = classRepository;
            _teacherRepository = teacherRepository;
            _teacherUserReposioty = teacherUserReposioty;
            _classStudentReposioty = classStudentRepository;
            _studentRepository = studentRepository;
        }

        public ListResultDto<ClassListDto> GetClass(GetClassInput input)
        {
            var classes = _classRepository.GetAll()
                .WhereIf(!input.Filter.IsNullOrEmpty(),
                c=>c.Name.Contains(input.Filter) ||
                   c.AcademicYear.Contains(input.Filter))
                .OrderBy(p=>p.Name)
                .ToList();

            return new ListResultDto<ClassListDto>(ObjectMapper.Map<List<ClassListDto>>(classes));
        }

        public ClassListDto GetClassDetail(GetClassStudentInput input)
        {
            var classes = _classRepository.GetAll()
                .Where(c => c.Id.Equals(input.ClassId))
                .FirstOrDefault();
            return ObjectMapper.Map<ClassListDto>(classes);
        }

        public ListResultDto<ClassStudentDto> GetClassStudent(GetClassStudentInput input)
        {
            var studentIds = _classStudentReposioty.GetAll().Where(
                s => s.ID_class.Equals(input.ClassId))
                .Select(s => s.ID_student)
                .ToList();
            var students = _studentRepository.GetAll().Where(
                s => studentIds.Contains(s.Id))
                .OrderBy(s=> s.Name)
                .ToList();
            return new ListResultDto<ClassStudentDto>(ObjectMapper.Map<List<ClassStudentDto>>(students));
        }
    }
}
