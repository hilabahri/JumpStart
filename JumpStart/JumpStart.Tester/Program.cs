using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpStart.Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            //var result = MasterCardAPI.APIConnector.PayFromCreditCard(MasterCardAPI.APIConnector.CreateCreditCard("123",10,16,"5555555555554444"),1000, MasterCardAPI.CurrencyType.USD);
            //MasterCardAPI.APIConnector.CardIsNotLostOrStolen("343434343434343");
            MasterCardAPI.APIConnector.MakeRepowerTransaction();
            Console.ReadKey();
        }
    }
}
