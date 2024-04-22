using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using MyCompanyName.AbpZeroTemplate.Classes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Classes
{
    public class ClassAppService : AbpZeroTemplateAppServiceBase, IClassAppService
    {
        private readonly IRepository<Class> _classRepository;

        public ClassAppService(IRepository<Class> classRepository)
        {
            _classRepository = classRepository;
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
        
    }
}
