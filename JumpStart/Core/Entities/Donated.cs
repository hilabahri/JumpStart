using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{

    public class Address
    {
        [BsonElement("city")]
        [JsonProperty("city")]
        public string City { get; set; }

        [BsonElement("street")]
        [JsonProperty("street")]
        public string Street { get; set; }

    }

    public class Donated : User
    {        
        [BsonElement("firstName")]
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [BsonElement("lastName")]
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [BsonElement("address")]
        [JsonProperty("address")]
        public Address UserAddress { get; set; }

        public string IdentityCardNum { get; set; }

        [BsonElement("shouldBeExposed")]
        [JsonProperty("shouldBeExposed")]
        public bool WantToBeExposed { get; set; }
       
    }
}
