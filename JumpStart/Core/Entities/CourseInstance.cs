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
    public class CourseInstance
    {
        [BsonElement("city")]
        [JsonProperty("city")]
        public string City { get; set; }

        [BsonElement("dates")]
        [JsonProperty("dates")]
        [BsonRepresentation(BsonType.String)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public List<DateTime> Dates { get; set; }
    }
}
