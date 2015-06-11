using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public enum TransactionStatus
    {
        PENDING, 
        CASHED,
        CANCELED
    }

    public class Transaction
    {
        public string TransactionID { get; set; }

        public string DonorID { get; set; }

        public string DonatedID { get; set; }

        public int Amount { get; set; }

        public string CourseID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public TransactionStatus Status { get; set; }

        public bool DonorWantToBeWxposed { get; set; }
    }
}
