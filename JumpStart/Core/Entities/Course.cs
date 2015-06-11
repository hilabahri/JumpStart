using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Course
    {
        public string CourseName { get; set; }

        public string CourseID { get; set; }

        public string CourseInfo { get; set; }

        public float CoursePrice { get; set; }

        public List<DateTime> Dates { get; set; }

        public int LengthInWeeks { get; set; }

    }
}
