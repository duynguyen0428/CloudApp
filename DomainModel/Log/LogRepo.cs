using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LogModel = Models.Log;

namespace DomainModel.Log
{
    public class LogRepo : ILogRepo
    {
        private readonly LogContext context;

        public LogRepo(LogContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(LogModel log) => await this.context.LogCollection.InsertOneAsync(log);
    }
}
