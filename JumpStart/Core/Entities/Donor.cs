using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Donor : User
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int OnlineMoney { get; set; }
    }
}
