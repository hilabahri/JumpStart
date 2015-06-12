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
using System.Xml.Serialization;

namespace JumpStart.MasterCardAPI
{

    public static class APIConnector
    {
        private static string publicKey = ConfigurationManager.AppSettings.Get("PublicKey") ?? "sbpb_NGVlNjNlMjItMmNiZi00ODJlLThkOTEtOWFkN2E4MTMwMDc4";
        private static string privateKey = ConfigurationManager.AppSettings.Get("PrivateKey") ?? "NvUHa1W/aHrK2OBmzolPSECXA0CgIBnhpaZMI2t2Bmx5YFFQL0ODSXAOkNtXTToq";

        private static System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();

        public static bool PayFromCreditCard(Card card, int amount, CurrencyType currency, string description = "no description", string extPublicKey = "", string extPrivateKey = "")
        {
            PaymentsApi.PublicApiKey = String.IsNullOrEmpty(extPublicKey) ? publicKey : extPublicKey;
            PaymentsApi.PrivateApiKey = String.IsNullOrEmpty(extPrivateKey) ? privateKey : extPrivateKey;

            if (!CardIsNotLostOrStolen(card.Number))
                return false;

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

        public static bool MakeRepowerTransaction(long cardNumber, long value, string currency = "840")
        {
            RepowerRequest repowerRequest = new RepowerRequest();
            repowerRequest.TransactionReference = getRepowerReferenceNumber();
            repowerRequest.CardNumber = 5184680430000006;
            repowerRequest.TransactionAmount.Value = 30000;
            repowerRequest.TransactionAmount.Currency = "840";
            repowerRequest.LocalDate = DateTime.Now.ToString("HHMMSS");
            repowerRequest.LocalTime = DateTime.Now.ToString("MMDD");
            repowerRequest.Channel = "W";
            repowerRequest.ICA = "009674";
            repowerRequest.ProcessorId = 9000000442;
            repowerRequest.RoutingAndTransitNumber = 990442082;
            repowerRequest.MerchantType = 6533;
            repowerRequest.CardAcceptor.Name = "Prepaid Load Store";
            repowerRequest.CardAcceptor.City = "St Charles";
            repowerRequest.CardAcceptor.State = "MO";
            repowerRequest.CardAcceptor.PostalCode = "63301";
            repowerRequest.CardAcceptor.Country = "USA";
            return getRepower(repowerRequest);
        }

            
        private static bool getRepower(RepowerRequest reData)
        {
            string data = Serializer<RepowerRequest>.Serialize(reData).InnerXml;
            byte[] arr = encoding.GetBytes(data);

            var request = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings.Get("RepowerApi") ?? "http://dmartin.org:8018/repower/v1/repower");
            request.Method = "POST";
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
                var result = Serializer<Repower>.Deserialize(sResponse);
                if (result.TransactionHistory.Transaction.Response.Code != "00")
                    return false;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            return true;
        }

        private static string getRepowerReferenceNumber()
        {
            long referenceNumber = 1000000000000000000;
            long staticNumber = 8999999999999999999;
            referenceNumber += (long)Math.Abs(((long)new Random().Next()) % staticNumber);
            return referenceNumber.ToString();
        }
    }
}
