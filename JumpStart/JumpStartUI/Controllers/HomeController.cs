using Core.Entities;
using DAL;
using JumpStart.APILogics;
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
            return Logics.GetCollectedAmountForDonatedCourse(donatedID, courseID);
        }

        public JObject GetFundingRequestsMetaData()
        {
            return Logics.GetFundingRequestsMetaData();
        }

        public JObject GetFundingRequestData(string donatedID, string courseID)
        {
            return Logics.GetFundingRequestData(donatedID, courseID);
        }

        public JObject DonatedSignIn(string userName, string password)
        {
            return Logics.DonatedSignIn(userName, password);
        }

        public JObject DonorSignIn(string userName, string password)
        {
            return Logics.DonorSignIn( userName, password);
        }

        public JObject GetDonatedDetails(string donatedID)
        {
            return Logics.GetDonatedDetails(donatedID);
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
         }

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
        }*/

        public JObject GetDonorDetails(string donorID)
        {
            return Logics.GetDonorDetails(donorID);
        }

        public JObject GetDonorTransactions(string donorID)
        {
            return Logics.GetDonorTransactions(donorID);
        }

        public void NewFundRequest(string donatedId, string courseId)
        {
           Logics.NewFundRequest(donatedId, courseId);

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
            return Logics.GetCoursesDetails(courseID);
        }
    }
}
