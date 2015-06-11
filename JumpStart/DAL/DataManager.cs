using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace DAL
{
    public class DataManager
    {
        public enum UserFilters
        {
            CITY,
            AGE,
            GENDER
        }

        public enum CourseFilters
        {
            CITY,
            PRICE,
            TYPE,
            START_DATE // In month.year
        }

        // Donated API

        public bool SignIn(string userName, string Password, out Donated donatedUser)
        {
            throw new System.NotImplementedException();
        }

        public void AddNewDonatedUser(Donated donatedUser)
        {
            throw new System.NotImplementedException();
        }

        public List<Donated> GetDonatedUsersByFilters(List<Tuple<UserFilters,List<string>>> filtersAndValues)
        {
            throw new System.NotImplementedException();
        }

        public List<Donated> GetDonatedUsersByFilter(UserFilters filterType, List<string> filterValues)
        {
            throw new System.NotImplementedException();
        }

        public List<Donated> GetAllDonatedUsers()
        {
            throw new System.NotImplementedException();
        }

        public Donated GetDonatedDetails(string id)
        {
            throw new System.NotImplementedException();
        }

        public void DonatedAddNewFundRequest(string donatedId, string courseId, List<DateTime> dateTimes)
        {
            throw new System.NotImplementedException();
        }

        public List<FundRequest> GetDonatedFundRequests(string donatedId)
        {
            throw new System.NotImplementedException();
        }

        // Courses API

        public List<Course> GetCoursesByFilters(List<Tuple<CourseFilters, List<string>>> filtersAndValues)
        {
            throw new System.NotImplementedException();
        }

        public List<Course> GetCoursesByFilter(CourseFilters filterType, List<string> filterValues)
        {
            throw new System.NotImplementedException();
        }

        public List<Course> GetAllCourses()
        {
            throw new System.NotImplementedException();
        }

        // DonorAPI

        public bool SignIn(string userName, string Password, out Donor donatedUser)
        {
            throw new System.NotImplementedException();
        }

        public void AddNewDonor(Donor donorUser)
        {
            throw new System.NotImplementedException();
        }

        public void DonorNewTransaction(Transaction transaction)
        {
            throw new System.NotImplementedException();
        }

        public void GetDonorTransactions(string donorId)
        {
            throw new System.NotImplementedException();
        }

        public Donor GetDonorDetails(string id)
        {
            throw new System.NotImplementedException();
        }

        // Global API

        /// <summary>
        /// Update all the PENDING transactions that are expired to CANCELD
        /// </summary>
        public void SyncTransactions()
        {
            throw new System.NotImplementedException();
            // TODO: return the money to the donor
        }

    }
}
