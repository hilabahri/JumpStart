using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class User
    {
        [BsonElement("_id")]
        [JsonProperty("id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("userName")]
        [JsonProperty("userName")]
        public string UserName { get; set; }

        [BsonElement("password")]
        [JsonProperty("password")]
        public string Password { get; set; }

        [BsonElement("dateOfBirth")]
        [JsonProperty("dateOfBirth")]
        [BsonRepresentation(BsonType.String)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime DateOfBirth { get; set; }

        [BsonElement("description")]
        [JsonProperty("description")]
        public string Desciption { get; set; }

        [BsonElement("gender")]
        [JsonProperty("gender")]
        [BsonRepresentation(BsonType.String)]
        [JsonConverter(typeof(StringEnumConverter))]
        public Gender Gender { get; set; }
    }
}
