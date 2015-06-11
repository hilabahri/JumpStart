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
            //var result = MasterCardAPI.APIConnector.PayFromCreditCard(MasterCardAPI.APIConnector.CreateCreditCard("123",10,16,"5555555555554444"),1000, MasterCardAPI.CurrencyType.USD);
            //MasterCardAPI.APIConnector.CardIsNotLostOrStolen("343434343434343");
            //MasterCardAPI.APIConnector.MakeRepowerTransaction(5184680430000006, 100);
            //DataManager.Instance.AddNewDonor(new Donor() { DateOfBirth = DateTime.Now.AddYears(-21), Desciption = "Super donot", Email = "donot@jumpsta.rt", FirstName="Amir", Gender=Gender.Male, LastName="Matz", OnlineMoney=1000, Password="968", UserName="am1r"});
            //DataManager.Instance.AddNewDonatedUser(new Donated() { DateOfBirth = DateTime.Now.AddYears(-21), Desciption = "Super donot", Email = "donot@jumpsta.rt", FirstName = "Amir", Gender = Gender.Male, LastName = "Matz", Password = "968", UserName = "am1r", IdentityCardNum = "", UserAddress = new Address() { City = "Tel Aviv", Street = "Namir 10" }, WantToBeExposed = true, FundRequests = new List<FundRequest>() { new FundRequest() { CourseID = ObjectId.GenerateNewId().ToString(), OptionalCourseInstances = new List<CourseInstance>() { new CourseInstance() { City = "Tel Aviv", Dates = new List<DateTime>() { DateTime.Now.AddMonths(3) } } } } } });
            //DataManager.Instance.AddNewFundRequestToDonated("5579f9fb0529214ae03e3701", new FundRequest() { CourseID = ObjectId.GenerateNewId().ToString(), OptionalCourseInstances = new List<CourseInstance>() { new CourseInstance() { City = "Tel Aviv", Dates = new List<DateTime>() { DateTime.Now.AddMonths(3) } } } });
            //DataManager.Instance.AddNewTransaction(new Transaction() { Amount = 1000, CourseID = ObjectId.GenerateNewId().ToString(), CreationDate = DateTime.Now, DonatedID = "5579f9fb0529214ae03e3701", DonorID="5579f6d6052921397816ce61", DonorWantToBeExposed = true, EndDate = DateTime.Now.AddMonths(1), Status = TransactionStatus.PENDING});
            //DataManager.Instance.AddNewCourse(new Course() { CourseInfo = "A very very good course", CourseName = "Coursera", CoursePrice = 300.0, Instances = new List<CourseInstance> { new CourseInstance(){ City="Tel Aviv", Dates = new List<DateTime>(){DateTime.Now.AddMonths(4)}}}, LengthInWeeks = 5 });
            //Logics.GetCollectedAmountForDonatedCourse("5579f9fb0529214ae03e3701", "5579f9fa0529214ae03e3700");
            Logics.GetFundingRequestData("5579f9fb0529214ae03e3701", "5579f9fa0529214ae03e3700");
            Console.ReadKey();
        }
    }
}
