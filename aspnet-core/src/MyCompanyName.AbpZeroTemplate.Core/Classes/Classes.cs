using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Classes
{
    public class Class: Entity
    {
        public const int MaxLength = 255;

        [Required]
        [MaxLength(MaxLength)]
        public string Name { get; set; }

        [Required]
        public string AcademicYear { get; set; }

        public virtual ICollection<ClassStudent> ClassStudents { get; set; }
    }
}
