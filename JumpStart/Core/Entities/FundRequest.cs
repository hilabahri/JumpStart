using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class FundRequest
    {
        public string CourseID { get; set; }

        public string DonatedID { get; set; }

        public List<DateTime> OptionalDates { get; set; }
    }
}
