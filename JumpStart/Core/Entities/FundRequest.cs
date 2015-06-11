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
    public class FundRequest
    {
        [BsonElement("courseId")]
        [JsonProperty("courseId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CourseID { get; set; }

        [BsonElement("optionalCourseInstances")]
        [JsonProperty("optionalCourseInstances")]
        public List<CourseInstance> OptionalCourseInstances { get; set; }
    }
}
