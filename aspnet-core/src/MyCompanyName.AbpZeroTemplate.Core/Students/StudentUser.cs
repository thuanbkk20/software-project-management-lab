using Abp.Domain.Entities;
using MyCompanyName.AbpZeroTemplate.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Students
{
    public class StudentUser: Entity
    {
        [Required]
        public int ID_student { get; set; }

        [Required]
        public long ID_user { get; set; }

        [ForeignKey(nameof(ID_student))]
        public virtual Student Student { get; set; }

        [ForeignKey(nameof(ID_user))]
        public virtual User User {  get; set; }
    }
}
