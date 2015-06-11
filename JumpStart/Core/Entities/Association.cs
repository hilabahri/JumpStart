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
    public class Association
    {
        [BsonElement("name")]
        [JsonProperty("name")]
        public string Name { get; set; }

        [BsonElement("info")]
        [JsonProperty("info")]
        public string Info { get; set; }

        [BsonElement("_id")]
        [JsonProperty("id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }


    }
}
