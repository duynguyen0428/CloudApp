using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Booking
    {
        [BsonId]
        public ObjectId objectId { get; set; }
        [BsonDateTimeOptions(DateOnly = true)]
        public DateTime Date { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [BsonIgnoreIfNull]
        public string Mobile { get; set; }
        public bool IsConfirmed { get; set; } = false; // customer confirm
        public string Status { get; set; } = "Initialized"; // intialize, re-schedule, accepted
        public bool IsComplete { get; set; } = false;
    }
}
