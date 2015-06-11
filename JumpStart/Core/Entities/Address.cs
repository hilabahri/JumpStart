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
    public class Address
    {
        [BsonElement("city")]
        [JsonProperty("city")]
        public string City { get; set; }

        [BsonElement("street")]
        [JsonProperty("street")]
        public string Street { get; set; }

    }
}
