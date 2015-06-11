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
    public enum TransactionStatus
    {
        PENDING, 
        CASHED,
        CANCELED
    }

    public class Transaction
    {
        [BsonElement("_id")]
        [JsonProperty("id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TransactionID { get; set; }

        [BsonElement("donorId")]
        [JsonProperty("donorId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string DonorID { get; set; }

        [BsonElement("donatedId")]
        [JsonProperty("donatedId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string DonatedID { get; set; }

        [BsonElement("amount")]
        [JsonProperty("amount")]
        [BsonRepresentation(BsonType.Int32)]
        public int Amount { get; set; }

        [BsonElement("courseId")]
        [JsonProperty("courseId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CourseID { get; set; }

        [BsonElement("creationDate")]
        [JsonProperty("cretionDate")]
        [BsonRepresentation(BsonType.String)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreationDate { get; set; }

        [BsonElement("endDate")]
        [JsonProperty("endDate")]
        [BsonRepresentation(BsonType.String)]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime EndDate { get; set; }

        [BsonElement("status")]
        [JsonProperty("status")]
        [BsonRepresentation(BsonType.String)]
        [JsonConverter(typeof(StringEnumConverter))]
        public TransactionStatus Status { get; set; }

        [BsonElement("dononrToBeExposed")]
        [JsonProperty("donorToBeExposed")]
        public bool DonorWantToBeWxposed { get; set; }
    }
}
