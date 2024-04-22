using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web;

namespace MyCompanyName.AbpZeroTemplate.Schedules.Dto
{
    public class GetScheduleInput
    {
        [Required]
        public bool getByCurrentUser { get; set; }

        public int ClassId { get; set; }

        public int TeacherId { get; set; }
    }
}
