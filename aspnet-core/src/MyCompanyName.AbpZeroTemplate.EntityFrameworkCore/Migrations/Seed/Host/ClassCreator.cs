using MyCompanyName.AbpZeroTemplate.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Migrations.Seed.Host
{
    public class ClassCreator
    {
        private readonly AbpZeroTemplateDbContext _context;

        public ClassCreator(AbpZeroTemplateDbContext context)
        {
            this._context = context;
        }

        public void Create()
        {
            string[] classNames = new string[] {
                "Mầm 01",
                "Chồi 01",
                "Lá 01",
                "Mầm 02",
                "Chồi 02",
                "Lá 02",
                "Mầm 03",
                "Chồi 03",
                "Lá 03",
            };

            string[] academicYear = new string[] { "Mầm",  "Chồi", "Lá" };
            var i = 0;
            foreach (string className in classNames)
            {
                bool existed = _context.Classes.Any(c => c.Name == className);
                if (!existed)
                {
                    var newClass = new Classes.Class
                    {
                        Name = className,
                        AcademicYear = academicYear[i%3]
                    };
                    _context.Classes.Add(newClass);
                    _context.SaveChanges();
                }
                i++;
            }
        }
    }
}
