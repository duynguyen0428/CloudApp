using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Log
    {
        [BsonId]
        public ObjectId objectId { get; set; }
        [BsonDateTimeOptions(DateOnly = true)]
        public DateTime Created { get; set; }
        public string Message { get; set; }
        public string Context { get; set; }
    }
}
