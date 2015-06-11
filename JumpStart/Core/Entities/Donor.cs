using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Donor : User
    {
        [BsonElement("firstName")]
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [BsonElement("lastName")]
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [BsonElement("onlineMoney")]
        [JsonProperty("onlineMoney")]
        [BsonRepresentation(BsonType.Int32)]
        public int OnlineMoney { get; set; }
    }
}
