using Abp.Domain.Entities;
using MyCompanyName.AbpZeroTemplate.Classes;
using MyCompanyName.AbpZeroTemplate.Students;
using MyCompanyName.AbpZeroTemplate.Teachers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Schedules
{
    public class Schedule: Entity
    {
        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public int ID_class { get; set; }

        [ForeignKey(nameof(ID_class))]
        public virtual Class Class { get; set; }

        [Required]
        public int ID_teacher { get; set; }

        [ForeignKey(nameof(ID_teacher))]
        public virtual Teacher Teacher { get; set; }
    }
}
