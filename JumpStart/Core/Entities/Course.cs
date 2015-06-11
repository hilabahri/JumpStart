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
    public class Course
    {
        [BsonElement("name")]
        [JsonProperty("name")]
        public string CourseName { get; set; }

        [BsonElement("_id")]
        [JsonProperty("id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CourseID { get; set; }

        [BsonElement("info")]
        [JsonProperty("name")]
        public string CourseInfo { get; set; }

        [BsonElement("price")]
        [JsonProperty("price")]
        [BsonRepresentation(BsonType.Double)]
        public double CoursePrice { get; set; }

        [BsonElement("dates")]
        [JsonProperty("dates")]
        [BsonRepresentation(BsonType.String)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public List<DateTime> Dates { get; set; }

        [BsonElement("lengthInWeeks")]
        [JsonProperty("lengthInWeeks")]
        [BsonRepresentation(BsonType.Int32)]
        public int LengthInWeeks { get; set; }

    }
}
