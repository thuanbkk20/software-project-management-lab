using Abp.Domain.Entities;
using MyCompanyName.AbpZeroTemplate.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Students
{
    public class Student: Entity
    {
        [Required]
        public string Name {  get; set; }

        [Required]
        public string AcademicYear { get; set; }

        public virtual StudentUser StudentUser { get; set; }

        public virtual ICollection<ClassStudent> ClassStudents { get; set; }
    }
}
