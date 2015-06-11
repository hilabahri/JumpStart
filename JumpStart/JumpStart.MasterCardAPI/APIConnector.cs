using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplifyCommerce.Payments;

namespace JumpStart.MasterCardAPI
{

    public static class APIConnector
    {


        private static bool PayFromCreditCard(Card card, int amount, CurrencyType currency, string description = "no description"){
            PaymentsApi.PublicApiKey = "sbpb_NGVlNjNlMjItMmNiZi00ODJlLThkOTEtOWFkN2E4MTMwMDc4";
            PaymentsApi.PrivateApiKey = "NvUHa1W/aHrK2OBmzolPSECXA0CgIBnhpaZMI2t2Bmx5YFFQL0ODSXAOkNtXTToq";

            PaymentsApi api = new PaymentsApi();
            Payment payment = new Payment()
            {
                Amount = amount,
                Card = card,
                Currency = Enum.GetName(typeof(CurrencyType), currency),
                Description = description
            };

            try
            {
                payment = (Payment)api.Create(payment);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            return true;
        }

        public static Card CreateCreditCard(string cvc, int month, int year, string id)
        {
            return new Card()
            {
                Cvc = cvc,
                ExpMonth = month,
                ExpYear = year,
                Number = id
            };
        }

        enum CurrencyType
        {
            USD = 0
        }
    }
}
