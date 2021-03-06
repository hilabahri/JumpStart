﻿using System;
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
        private const string TRANSACTIONS_COLLECTION = "transactions";

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

        public bool SignIn(string userName, string password, out Donated donatedUser)
        {
            var donatedCollection = GetCollection<Donated>(DONATED_COLLECTION);
            donatedUser = GetCollection<Donated>(DONATED_COLLECTION).Find<Donated>(Builders<Donated>.Filter.And(
                Builders<Donated>.Filter.Eq(donated => donated.UserName, userName),
                Builders<Donated>.Filter.Eq(donated => donated.Password, password)
                )).FirstOrDefaultAsync().Result;

            return donatedUser == null ? false : true;
        }

        public bool SignIn(string userName, string password, out Donor donatedUser)
        {
            var donatedCollection = GetCollection<Donor>(DONORS_COLLECTION);
            donatedUser = GetCollection<Donor>(DONORS_COLLECTION).Find<Donor>(Builders<Donor>.Filter.And(
                Builders<Donor>.Filter.Eq(donated => donated.UserName, userName),
                Builders<Donor>.Filter.Eq(donated => donated.Password, password)
                )).FirstOrDefaultAsync().Result;

            return donatedUser == null ? false : true;
        }


        public List<Donated> GetAllDonatedUsers()
        {
            return GetCollection<Donated>(DONATED_COLLECTION).Find(_ => true).ToListAsync().Result;
        }

        public List<Course> GetAllCourses()
        {
            return GetCollection<Course>(COURSES_COLLECTION).Find(_ => true).ToListAsync().Result;
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



        public List<FundRequest> GetDonatedFundRequests(string donatedId)
        {
            return GetDonatedDetails(donatedId).FundRequests;
        }

        //public Donated GetDonatedFundRequestByID(string fundId)
        //{
        //    return GetCollection<Donated>(DONATED_COLLECTION).Find(Builders<Donated>.Filter.Eq(donated => donated.FundRequests.Id, id)).FirstOrDefaultAsync().Result;
        //}

        // Courses API

        public List<Course> GetCoursesByFilters(List<Tuple<CourseFilters, List<string>>> filtersAndValues)
        {
            throw new System.NotImplementedException();
        }

        public List<Course> GetCoursesByFilter(CourseFilters filterType, List<string> filterValues)
        {
            throw new System.NotImplementedException();
        }


        public List<Donated> GetDonatedUsersByFilters(List<Tuple<UserFilters, List<string>>> filtersAndValues)
        {
            throw new System.NotImplementedException();
        }

        public List<Donated> GetDonatedUsersByFilter(UserFilters filterType, List<string> filterValues)
        {
            throw new System.NotImplementedException();
        }
       
        public void AddNewDonor(Donor donorUser)
        {
            donorUser.Id = ObjectId.GenerateNewId().ToString();
            GetCollection<Donor>(DONORS_COLLECTION).InsertOneAsync(donorUser).Wait();
        }

        public void AddNewCourse(Course course)
        {
            course.CourseID = ObjectId.GenerateNewId().ToString();
            GetCollection<Course>(COURSES_COLLECTION).InsertOneAsync(course).Wait();
        }

        public void AddNewFundRequestToDonated(string donatedId, FundRequest fundRequest)
        {
            GetCollection<Donated>(DONATED_COLLECTION).UpdateOneAsync(Builders<Donated>.Filter.Eq(donated => donated.Id, donatedId),
                Builders<Donated>.Update.AddToSet(donated => donated.FundRequests, fundRequest)).Wait();
        }

        public void AddNewDonatedUser(Donated donatedUser)
        {
            donatedUser.Id = ObjectId.GenerateNewId().ToString();
            var donatedCollection = GetCollection<Donated>(DONATED_COLLECTION);
            donatedCollection.InsertOneAsync(donatedUser).Wait();
        }

        public void RemoveFundsFromDonor(string donorId, int fundsToRemove)
        {
            //TODO remove funds
            //return GetCollection<Donor>(DONORS_COLLECTION).UpdateOneAsync<Donor>(Builders<Transaction>.Filter.Eq(tr => tr.DonorID, donorId),Builders<Transaction>.Update. );
        }

        public int GetNeededMoney(string courseid)
        {
            return (int)GetCourseDetails(courseid).CoursePrice;
        }

        public void AddNewTransaction(Transaction transaction)
        {
            transaction.TransactionID = ObjectId.GenerateNewId().ToString();
            GetCollection<Transaction>(TRANSACTIONS_COLLECTION).InsertOneAsync(transaction).Wait();
        }

        public List<Transaction> GetTransactionsByDonorId(string donorId)
        {
            return GetCollection<Transaction>(TRANSACTIONS_COLLECTION).
                Find<Transaction>(Builders<Transaction>.Filter.Eq(transaction => transaction.DonorID, donorId)).ToListAsync().Result;
        }

        public List<Transaction> GetTransactionsByDonatedId(string donatedId)
        {
            return GetCollection<Transaction>(TRANSACTIONS_COLLECTION).
                Find<Transaction>(Builders<Transaction>.Filter.Eq(transaction => transaction.DonatedID, donatedId)).ToListAsync().Result;
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
        START_DATE
    }
}
