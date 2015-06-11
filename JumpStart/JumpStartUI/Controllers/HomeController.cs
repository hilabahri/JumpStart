﻿using Core.Entities;
using DAL;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JumpStartUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public double GetCollectedAmountForDonatedCourse(string donatedID, string courseID)
        {
            double sum = 0;
            try{
                foreach( Transaction tran in DataManager.Instance.GetTransactionsByDonatedId(donatedID))
               {
                   if (tran.CourseID == courseID) {
                       sum++;
                   }
               }
            }
            catch(Exception)
            {
            }           
           return sum;
        }

        public JObject GetFundingRequestsMetaData()
        {
            List<Donated> donated_list = DataManager.Instance.GetAllDonatedUsers();
            JObject metaData = new JObject();
            JArray metaDataArr = new JArray();
            try
            {
                foreach (Donated donatedU in donated_list)
            {
                foreach (FundRequest fr in donatedU.FundRequests)
                {
                    JObject fundRequestMetaData = new JObject();
                    fundRequestMetaData.Add("donaterID", donatedU.Id);
                    fundRequestMetaData.Add("courseID", fr.CourseID);
                    fundRequestMetaData.Add("course", DataManager.Instance.GetCourseDetails(fr.CourseID).CourseName);
                    fundRequestMetaData.Add("age", (DateTime.Now.Year - donatedU.DateOfBirth.Year).ToString());
                    fundRequestMetaData.Add("city",donatedU.UserAddress.City);
                    fundRequestMetaData.Add("collectedAmount", GetCollectedAmountForDonatedCourse(donatedU.Id, fr.CourseID).ToString() + "$");
                    fundRequestMetaData.Add("goalAmount", DataManager.Instance.GetCourseDetails(fr.CourseID).CoursePrice.ToString() + "$" );
                    metaDataArr.Add(fundRequestMetaData);
                }
                
            }
            metaData.Add("aaData", metaDataArr);
            //JObject metaData = JObject.Parse("{aaData : [{ \"purpose\" : \"liad\", \"age\" : \"something\", \"living_place\" : \"some office\", \"collected\" : \"103$\", \"goal\" : \"105$\" }]}");
            }
            catch(Exception)
            {
                return null;
            }
            
            return metaData;
        }

        private List<CourseInstance> GetFundRequestCourseOptionalDates(string donatedID, string courseID)
        {
            List<FundRequest> funds;
            try
            {
                funds = DataManager.Instance.GetDonatedFundRequests(donatedID);
                foreach (FundRequest fr in funds)
                {
                    if (fr.CourseID == courseID)
                    {
                        return fr.OptionalCourseInstances;
                    }
                }
            }
            catch (Exception)
            {}
            
            return null;
        }

        public JObject GetFundingRequestData(string donatedID, string courseID)
        {
            JObject donatedAndFundDetails = new JObject();

            try
            {
                Donated donated = DataManager.Instance.GetDonatedDetails(donatedID);
                donatedAndFundDetails = new JObject(JsonConvert.SerializeObject(donated));

                if (!donated.WantToBeExposed)
                {
                    donatedAndFundDetails.Remove("firstName");
                    donatedAndFundDetails.Remove("lastName");
                }

                donatedAndFundDetails.Add("age", (DateTime.Now.Year - donated.DateOfBirth.Year).ToString());
                donatedAndFundDetails.Add("course", DataManager.Instance.GetCourseDetails(courseID).CourseName);
                JObject funds = new JObject(JsonConvert.SerializeObject(donatedAndFundDetails.GetValue("fundRequests")));

                donatedAndFundDetails.Add("");
                donatedAndFundDetails.Add("collectedAmount", GetCollectedAmountForDonatedCourse(donatedID, courseID).ToString() + "$");
                donatedAndFundDetails.Add("goalAmount", DataManager.Instance.GetCourseDetails(courseID).CoursePrice.ToString() + "$");

                // Remove the unneccasery details
                donatedAndFundDetails.Remove("userName");
                donatedAndFundDetails.Remove("password");
                donatedAndFundDetails.Remove("email");
                donatedAndFundDetails.Remove("identityCardNumber");
                donatedAndFundDetails.Remove("dateOfBirth");
                donatedAndFundDetails.Remove("fundRequests");
            }
            catch(Exception)
            {
                return null;
            }
            
            return donatedAndFundDetails;
        }

        public JObject DonatedSignIn(string userName, string password)
        {
            Donated donated = new Donated();
            try
            {
                if (DataManager.Instance.SignIn(userName, password, out donated))
                {
                    return new JObject(JsonConvert.SerializeObject(donated));
                }
            }
            catch (Exception) { }          
            return null;
        }

        public JObject DonorSignIn(string userName, string password)
        {
            Donor donor = new Donor();
            try
            {
                if (DataManager.Instance.SignIn(userName, password, out donor))
                {
                    return new JObject(JsonConvert.SerializeObject(donor));
                }
            }
            catch (Exception) { }
            return null;
        }

        public JObject GetDonatedDetails(string donatedID)
        {
            JObject donatedAndFundDetails = new JObject();

            try
            {
                Donated donated = DataManager.Instance.GetDonatedDetails(donatedID);
                donatedAndFundDetails = new JObject(JsonConvert.SerializeObject(donated));
                donatedAndFundDetails.Remove("userName");
                donatedAndFundDetails.Remove("password");

            }
            catch (Exception)
            {
                return null;
            }
            return donatedAndFundDetails;
        }


        /* public bool DonatedSignUp()
         {
             //TODO
             return false;
         }

         public bool DonorSignUp()
         {
             //TODO
             return false;
         }*/

        public JObject GetDonatedPendingCourseRequests(string donatedID)
        {
            JObject pendingCourses = new JObject();
           try
            {
                JArray coursesArr = new JArray();
                foreach (FundRequest fr in DataManager.Instance.GetDonatedFundRequests(donatedID))
                {
                    double payedAmount = GetCollectedAmountForDonatedCourse(donatedID, fr.CourseID);
                    double courseAmount = DataManager.Instance.GetCourseDetails(fr.CourseID).CoursePrice;

                    if (payedAmount < courseAmount)
                    {
                        JObject course = new JObject();
                        coursesArr.Add(course);
                    }
                    
                }
                pendingCourses.Add("pending", coursesArr);

            }
            catch (Exception)
            {
                return null;
            }
            return pendingCourses;
        }

        public JObject GetDonatedPayedCourseRequests(string donatedID)
        {
            JObject pendingCourses = new JObject();
            try
            {
                JArray coursesArr = new JArray();
                foreach (FundRequest fr in DataManager.Instance.GetDonatedFundRequests(donatedID))
                {
                    double payedAmount = GetCollectedAmountForDonatedCourse(donatedID, fr.CourseID);
                    double courseAmount = DataManager.Instance.GetCourseDetails(fr.CourseID).CoursePrice;

                    if (payedAmount == courseAmount)
                    {
                        JObject course = new JObject();

                        coursesArr.Add(course);
                    }

                }
                pendingCourses.Add("pending", coursesArr);

            }
            catch (Exception)
            {
                return null;
            }
            return pendingCourses;
        }

        public JObject GetDonorDetails(string donorID)
        {
            return null;
        }

        public JObject GetDonorTransactions(string donorID)
        {
            return null;
        }

        public void NewFundRequest()
        {
        }

        public void NewTransaction()
        {
            // Use the mastercard API 
        }

        public void DonatedTransactionForItsFundRequest()
        {
            // Use the mastercard API
        }

        public JObject GetCoursesDetails(string courseID)
        {
            return null;
        }
    }
}
