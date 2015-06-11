using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{

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

        [BsonElement("identityCardNumber")]
        [JsonProperty("identityCardNumber")]
        public string IdentityCardNum { get; set; }

        [BsonElement("wantToBeExposed")]
        [JsonProperty("wantToBeExposed")]
        public bool WantToBeExposed { get; set; }

        [BsonElement("fundRequests")]
        [JsonProperty("fundRequests")]
        public List<FundRequest> FundRequests { get; set; }
       
    }
}
