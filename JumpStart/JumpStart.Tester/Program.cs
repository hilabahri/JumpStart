using Core.Entities;
using DAL;
using JumpStart.APILogics;
using MongoDB.Bson;
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
            //try
            //{
            //    //getting out of the minus
            //    var course1 = new Course()
            //    {
            //        CourseName = "Rehab",
            //        CourseInfo = "Rehab",
            //        CoursePrice = 217.5,
            //        LengthInWeeks = 7,
            //        Instances = new List<CourseInstance>()
            //    };

            //    //rehab
            //    var course2 = new Course()
            //    {
            //        CourseName = "Getting out of the minus",
            //        CourseInfo = "Getting out of the minus",
            //        CoursePrice = 45.5,
            //        LengthInWeeks = 3,
            //        Instances = new List<CourseInstance>()
            //    };

            //    DataManager.Instance.AddNewCourse(course1);
            //    DataManager.Instance.AddNewCourse(course2);


            //    var courses = new List<string>() { course1.CourseID, course2.CourseID };

            //    string[] firstNames = new string[]
            //{
            //    "Yossi", "Shlomo", "Itamar","Ofir","David","Shimi","Roei","Eran","Yinon","Arie","Itzhak","Liad","Michael","Lev","Omer"
            //};

            //    string[] lastNames = new string[]
            //{
            //    "Mastercard", "Google", "Zachai","Melamed","Tavori","Magal","Shor","Rozenberg","Levi","Gur","Tshuva","Strook","Pruss","Cohen","Teague"
            //};

            //    string[] cities = new string[]
            //{
            //    "Tel Aviv","Ashdod", "Yavne", "Rishon Lezion", "Haifa", "Eilat"
            //};

            //    for (int i = 0; i < 15; i++)
            //    {

            //        string firstName = firstNames[i];
            //        string lastName = lastNames[i];
            //        string city = cities[i % cities.Length];

            //        DataManager.Instance.AddNewDonatedUser(new Donated()
            //            {
            //                Desciption = "donated",
            //                FirstName = firstName,
            //                LastName = lastName,
            //                IdentityCardNum = firstName + "_" + lastName + "_" + "IdenititySheker",
            //                Email = firstName + "_" + lastName + "@gmail.com",
            //                DateOfBirth = GetRandomDate(new DateTime(1980, 1, 1), new DateTime(1990, 1, 1)),
            //                Password = firstName + lastName,
            //                WantToBeExposed = false,
            //                UserName = firstName + "_" + lastName,
            //                UserAddress = new Address() { City = city, Street = "sheker" },
            //                Gender = Gender.Male,
            //                FundRequests = new List<FundRequest>()
            //        {
            //            new FundRequest()
            //            {
            //                CourseID = courses[i%2],
            //                OptionalCourseInstances = new List<CourseInstance>()
            //                {
            //                    new CourseInstance{
            //                        City = city,
            //                        Dates = new List<DateTime>
            //                        {
            //                            GetRandomDate(DateTime.Now, new DateTime(2015, 9, 30)),
            //                            GetRandomDate(DateTime.Now, new DateTime(2015, 9, 30))
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //            });
            //    }
            //}
            //catch(Exception ex)
            //{
            //   Console.WriteLine();
            //}
                //var result = MasterCardAPI.APIConnector.PayFromCreditCard(MasterCardAPI.APIConnector.CreateCreditCard("123",10,16,"5555555555554444"),1000, MasterCardAPI.CurrencyType.USD);
                //MasterCardAPI.APIConnector.CardIsNotLostOrStolen("343434343434343");
                //MasterCardAPI.APIConnector.MakeRepowerTransaction(5184680430000006, 100);
                //DataManager.Instance.AddNewDonor(new Donor() { DateOfBirth = DateTime.Now.AddYears(-21), Desciption = "Super donot", Email = "donot@jumpsta.rt", FirstName="Amir", Gender=Gender.Male, LastName="Matz", OnlineMoney=1000, Password="968", UserName="am1r"});
                //DataManager.Instance.AddNewDonatedUser(new Donated() { DateOfBirth = DateTime.Now.AddYears(-21), Desciption = "Super donot", Email = "donot@jumpsta.rt", FirstName = "Amir", Gender = Gender.Male, LastName = "Matz", Password = "968", UserName = "am1r", IdentityCardNum = "", UserAddress = new Address() { City = "Tel Aviv", Street = "Namir 10" }, WantToBeExposed = true, FundRequests = new List<FundRequest>() { new FundRequest() { CourseID = ObjectId.GenerateNewId().ToString(), OptionalCourseInstances = new List<CourseInstance>() { new CourseInstance() { City = "Tel Aviv", Dates = new List<DateTime>() { DateTime.Now.AddMonths(3) } } } } } });
                //DataManager.Instance.AddNewFundRequestToDonated("5579f9fb0529214ae03e3701", new FundRequest() { CourseID = ObjectId.GenerateNewId().ToString(), OptionalCourseInstances = new List<CourseInstance>() { new CourseInstance() { City = "Tel Aviv", Dates = new List<DateTime>() { DateTime.Now.AddMonths(3) } } } });
                //DataManager.Instance.AddNewTransaction(new Transaction() { Amount = 1000, CourseID = ObjectId.GenerateNewId().ToString(), CreationDate = DateTime.Now, DonatedID = "5579f9fb0529214ae03e3701", DonorID="5579f6d6052921397816ce61", DonorWantToBeExposed = true, EndDate = DateTime.Now.AddMonths(1), Status = TransactionStatus.PENDING});
                //DataManager.Instance.AddNewCourse(new Course() { CourseInfo = "A very very good course", CourseName = "Coursera", CoursePrice = 300.0, Instances = new List<CourseInstance> { new CourseInstance(){ City="Tel Aviv", Dates = new List<DateTime>(){DateTime.Now.AddMonths(4)}}}, LengthInWeeks = 5 });
                //Logics.GetCollectedAmountForDonatedCourse("5579f9fb0529214ae03e3701", "5579f9fa0529214ae03e3700");
                //Logics.GetFundingRequestData("5579f9fb0529214ae03e3701", "5579f9fa0529214ae03e3700");
                //Logics.DonatedSignIn("liad","968");
              //  Logics.GetFundingRequestData("5579f9fb0529214ae03e3701", "5579f9fa0529214ae03e3700");
            Console.ReadKey();
        }

        static readonly Random rnd = new Random();
        public static DateTime GetRandomDate(DateTime from, DateTime to)
        {
            var range = to - from;

            var randTimeSpan = new TimeSpan((long)(rnd.NextDouble() * range.Ticks));

            return from + randTimeSpan;
        }
    }
}
