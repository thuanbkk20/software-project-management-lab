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

namespace MyCompanyName.AbpZeroTemplate.Teachers
{
    public class TeacherUser: Entity
    {
        [Required]
        public int ID_teacher { get; set; }

        [Required]
        public long ID_user { get; set; }

        [ForeignKey(nameof(ID_teacher))]
        public virtual Teacher Teacher { get; set; }

        [ForeignKey(nameof(ID_user))]
        public virtual User User { get; set; }
    }
}
