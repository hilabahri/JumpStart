using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplifyCommerce.Payments;
using System.Net;
using System.IO;
using System.Runtime.Serialization;
using System.Configuration;

namespace JumpStart.MasterCardAPI
{

    public static class APIConnector
    {


        public static bool PayFromCreditCard(Card card, int amount, CurrencyType currency, string description = "no description"){
            PaymentsApi.PublicApiKey = ConfigurationManager.AppSettings.Get("PublicKey") ?? "sbpb_NGVlNjNlMjItMmNiZi00ODJlLThkOTEtOWFkN2E4MTMwMDc4";
            PaymentsApi.PrivateApiKey = ConfigurationManager.AppSettings.Get("PrivateKey") ?? "NvUHa1W/aHrK2OBmzolPSECXA0CgIBnhpaZMI2t2Bmx5YFFQL0ODSXAOkNtXTToq";

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

        public static bool CardIsNotLostOrStolen(string cardNumber)
        {
            var request = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings.Get("LostApi") ?? "http://dmartin.org:8018/fraud/loststolen/v1/account-inquiry?Format=XML");

            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            if (String.IsNullOrEmpty(cardNumber))
                return false;
            string data = "<AccountInquiry><AccountNumber>"+cardNumber+"</AccountNumber></AccountInquiry>";
            byte[] arr = encoding.GetBytes(data);
            request.Method = "PUT";
            request.ContentType = "application/xml";
            try
            {
                    request.ContentLength = arr.Length;
                    Stream dataStream = request.GetRequestStream();
                    dataStream.Write(arr, 0, arr.Length);
                    dataStream.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream respStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(respStream);
                var sResponse = reader.ReadToEnd();
                if (sResponse.Contains("<Listed>true</Listed>"))
                    return false;

            }
            catch(Exception ex){
                Console.WriteLine(ex.StackTrace);
                return true;
            }
            return true;
        }


    }
}
