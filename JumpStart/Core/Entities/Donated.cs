using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{

    public class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int Num { get; set; }
        public int Apartment { get; set; }
    }

    public class Donated : User
    {        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string IdentityCardNum { get; set; }

        public Address UserAddress { get; set; }

        public bool WantToBeExposed { get; set; }
       
    }
}
