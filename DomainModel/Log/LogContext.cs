using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using LogModel = Models.Log;
namespace DomainModel.Log
{
    public class LogContext
    {
        private readonly IMongoDatabase _database;
        private IMongoCollection<LogModel> _collection;
        public LogContext(string connections, string dbname)
        {
            var client = new MongoClient(connections);

            if (client != null)
                _database = client.GetDatabase(dbname);

            if (_database != null)
                _collection = _database.GetCollection<LogModel>("Log");
        }

        public IMongoCollection<LogModel> LogCollection
        {
            get
            {
                return _collection;
            }
        }
    }
}
