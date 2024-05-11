using Abp.Domain.Entities;
using MyCompanyName.AbpZeroTemplate.Authorization.Users;
using MyCompanyName.AbpZeroTemplate.Students;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCompanyName.AbpZeroTemplate.Classes;

namespace MyCompanyName.AbpZeroTemplate.Classes
{
    public class ClassStudent: Entity
    {
        [Required]
        public int ID_student { get; set; }

        [Required]
        public int ID_class { get; set; }

        public string LearningProgress { get; set; }

        [ForeignKey(nameof(ID_student))]
        public virtual Student Student { get; set; }

        [ForeignKey(nameof(ID_class))]
        public virtual Class Class { get; set; }
    }
}
