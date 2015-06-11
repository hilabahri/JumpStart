using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using MongoDB.Driver;
using MongoDB.Bson;

namespace DAL
{
    public class DataManager
    {

        private static DataManager _instance;
        private static object _lock;


        private const string DONATED_COLLECTION = "donated";
        private const string COURSES_COLLECTION = "courses";
        private const string DONORS_COLLECTION = "donors";

        static DataManager()
        {
            _lock = new object();
        }

        private DataManager()
        {

        }

        public static DataManager Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;

                lock (_lock)
                {
                    return _instance ?? (_instance = new DataManager());
                }
            }
        }

        // Donated API

        public bool SignIn(string userName, string password, out Donated donatedUser)
        {
            bool success = false;
            var donatedCollection = GetCollection<Donated>(DONATED_COLLECTION);
            donatedUser = GetCollection<Donated>(DONATED_COLLECTION).Find<Donated>(Builders<Donated>.Filter.And(
                Builders<Donated>.Filter.Eq(donated => donated.UserName, userName),
                Builders<Donated>.Filter.Eq(donated => donated.Password, password)
                )).FirstOrDefaultAsync().Result;

            return donatedUser == null ? false : true;
        }

        public void AddNewDonatedUser(Donated donatedUser)
        {
            donatedUser.Id = ObjectId.GenerateNewId().ToString();
            var donatedCollection = GetCollection<Donated>(DONATED_COLLECTION);
            donatedCollection.InsertOneAsync(donatedUser).Wait();
        }

        public List<Donated> GetDonatedUsersByFilters(List<Tuple<UserFilters, List<string>>> filtersAndValues)
        {
            throw new System.NotImplementedException();
        }

        public List<Donated> GetDonatedUsersByFilter(UserFilters filterType, List<string> filterValues)
        {
            throw new System.NotImplementedException();
        }

        public List<Donated> GetAllDonatedUsers()
        {
            return GetCollection<Donated>(DONATED_COLLECTION).Find(null).ToListAsync().Result;
        }

        public List<Course> GetAllCourses()
        {
            return GetCollection<Course>(COURSES_COLLECTION).Find(null).ToListAsync().Result;
        }

        public Donated GetDonatedDetails(string id)
        {
            return GetCollection<Donated>(DONATED_COLLECTION).Find(Builders<Donated>.Filter.Eq(donated => donated.Id, id)).FirstOrDefaultAsync().Result;
        }

        public Donor GetDonorDetails(string id)
        {
            return GetCollection<Donor>(DONORS_COLLECTION).Find(Builders<Donor>.Filter.Eq(donor => donor.Id, id)).FirstOrDefaultAsync().Result;
        }

        public Course GetCourseDetails(string id)
        {
            return GetCollection<Course>(COURSES_COLLECTION).Find(Builders<Course>.Filter.Eq(course => course.CourseID, id)).FirstOrDefaultAsync().Result;
        }

        public void DonatedAddNewFundRequest(string donatedId, FundRequest fundRequest)
        {
            GetCollection<Donated>(DONATED_COLLECTION).UpdateOneAsync(Builders<Donated>.Filter.Eq(donated => donated.Id, donatedId),
                Builders<Donated>.Update.AddToSet(donated => donated.FundRequests, fundRequest)).Wait();
        }

        public List<FundRequest> GetDonatedFundRequests(string donatedId)
        {
            return GetAllDonatedUsers().SelectMany(donated => donated.FundRequests).ToList();
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

        

        // DonorAPI

        public bool SignIn(string userName, string password, out Donor donatedUser)
        {
            bool success = false;
            var donatedCollection = GetCollection<Donor>(DONORS_COLLECTION);
            donatedUser = GetCollection<Donor>(DONORS_COLLECTION).Find<Donor>(Builders<Donor>.Filter.And(
                Builders<Donor>.Filter.Eq(donated => donated.UserName, userName),
                Builders<Donor>.Filter.Eq(donated => donated.Password, password)
                )).FirstOrDefaultAsync().Result;

            return donatedUser == null ? false : true;
        }

        public void AddNewDonor(Donor donorUser)
        {
            donorUser.Id = ObjectId.GenerateNewId().ToString();
            GetCollection<Donor>(DONORS_COLLECTION).InsertOneAsync(donorUser).Wait();
        }

        public void DonorNewTransaction(Transaction transaction)
        {
            throw new System.NotImplementedException();
        }

        public void GetDonorTransactions(string donorId)
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


        private IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            var client = new MongoClient();
            var db = client.GetDatabase("mastercard");
            return db.GetCollection<T>(collectionName);
        }
    }


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
}
