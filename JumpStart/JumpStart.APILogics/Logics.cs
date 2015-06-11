using Core.Entities;
using DAL;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpStart.APILogics
{
    public static class Logics
    {
        public static JObject GetFundingRequestsMetaData()
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
                        fundRequestMetaData.Add("city", donatedU.UserAddress.City);
                        fundRequestMetaData.Add("collectedAmount", GetCollectedAmountForDonatedCourse(donatedU.Id, fr.CourseID).ToString() + "$");
                        fundRequestMetaData.Add("goalAmount", DataManager.Instance.GetCourseDetails(fr.CourseID).CoursePrice.ToString() + "$");
                        metaDataArr.Add(fundRequestMetaData);
                    }

                }
                metaData.Add("aaData", metaDataArr);
                //JObject metaData = JObject.Parse("{aaData : [{ \"purpose\" : \"liad\", \"age\" : \"something\", \"living_place\" : \"some office\", \"collected\" : \"103$\", \"goal\" : \"105$\" }]}");
            }
            catch (Exception)
            {
                return null;
            }
            return metaData;
        }


        public static double GetCollectedAmountForDonatedCourse(string donatedID, string courseID)
        {
            double sum = 0;
            try
            {
                foreach (Transaction tran in DataManager.Instance.GetTransactionsByDonatedId(donatedID))
                {
                    if (tran.CourseID == courseID)
                    {
                        sum++;
                    }
                }
            }
            catch (Exception)
            {
            }
            return sum;
        }
    }
}
