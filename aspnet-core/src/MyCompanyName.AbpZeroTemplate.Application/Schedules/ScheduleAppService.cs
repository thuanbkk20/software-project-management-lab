using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Castle.MicroKernel.Registration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCompanyName.AbpZeroTemplate.Authorization.Users;
using MyCompanyName.AbpZeroTemplate.Classes;
using MyCompanyName.AbpZeroTemplate.Classes.Dto;
using MyCompanyName.AbpZeroTemplate.Schedules.Dto;
using MyCompanyName.AbpZeroTemplate.Students;
using MyCompanyName.AbpZeroTemplate.Teachers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Schedules
{
    public class ScheduleAppService : AbpZeroTemplateAppServiceBase, IScheduleAppService
    {
        private readonly IRepository<Schedule> _scheduleRepository;
        private readonly IRepository<Class> _classRepository;
        private readonly IRepository<Teacher> _teacherRepository;
        private readonly IRepository<TeacherUser> _teacherUserReposioty;

        public ScheduleAppService(
            IRepository<Schedule> scheduleRepository,
            IRepository<Class> classRepository,
            IRepository<Teacher> teacherRepository,
            IRepository<TeacherUser> teacherUserReposioty
        )
        {
            _scheduleRepository = scheduleRepository;
            _classRepository = classRepository;
            _teacherRepository = teacherRepository;
            _teacherUserReposioty = teacherUserReposioty;
        }

        [AbpAuthorize]
        public ListResultDto<ScheduleDto> GetSchedule(GetScheduleInput input)
        {
            var query = _scheduleRepository.GetAll().Include(s => s.Teacher).Include(s => s.Class);

            if(input.getByCurrentUser == true)
            {
                var userId = AbpSession.UserId.Value;
                Console.WriteLine(userId);
                var teacherUser = _teacherUserReposioty.GetAll().Where(t => t.ID_user == userId).First();
                Console.Write(teacherUser);
                if(teacherUser == null)
                {
                    throw new Exception("User is not teacher");
                }
                query.Where(s => s.ID_teacher == teacherUser.ID_teacher);
            }
            else if(input.TeacherId != null)
            {
                query.Where(s=> s.ID_teacher == input.TeacherId);
            }

            if(input.ClassId!=null)
            {
                query.Where(s=>s.ID_class == input.ClassId);
            }
            query.OrderBy(s => s.StartTime);
            var chedules = query.ToList();

            return new ListResultDto<ScheduleDto>(ObjectMapper.Map<List<ScheduleDto>>(chedules));
        }

        [HttpPost]
        [AbpAuthorize]
        public ScheduleDto CreateSchedule(CreateScheduleInput input)
        {
            var teacher = _teacherRepository
                .GetAll().Where(s => s.Id == input.TeacherId).FirstOrDefault();
            if (teacher == null)
            {
                throw new Exception("Can not find teacher");
            }

            var inputedClass = _classRepository
                .GetAll().Where(c => c.Id == input.ClassId).FirstOrDefault();
            if (inputedClass == null)
            {
                throw new Exception("Can not find class");
            }
            var schedule = new Schedule();
            schedule.StartTime = input.StartTime;
            schedule.EndTime = input.EndTime;
            schedule.Teacher = teacher;
            schedule.Class = inputedClass;
            var result = _scheduleRepository.Insert(schedule);
            return ObjectMapper.Map<ScheduleDto>(result);
        }
    }
}
