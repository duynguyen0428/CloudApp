using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using BookingModel = Models.Booking;
namespace DomainModel.Booking {
    public class BookingContext {
        private readonly IMongoDatabase _database;
        private IMongoCollection<BookingModel> _collection;
        public BookingContext (string connections, string dbname) {
            // var client = new MongoClient (connections);

            // if (client != null)
            //     _database = client.GetDatabase (dbname);

            var credential = MongoCredential.CreateCredential ("BookingDB", "duynguyen0428", "cuongduy0428");
            var mongoClientSettings = new MongoClientSettings {
                Server = new MongoServerAddress ("172.18.10.1", 13942),
                Credentials = new List<MongoCredential> { credential }
            };
            var client = new MongoClient (mongoClientSettings);
            _database = client.GetDatabase (dbname);

            if (_database != null)
                _collection = _database.GetCollection<BookingModel> ("Booking");
        }

        public IMongoCollection<BookingModel> BookingCollection {
            get {
                return _collection;
            }
        }
    }
}