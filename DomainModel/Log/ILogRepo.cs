using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using model = Models;
namespace DomainModel.Log
{
    public interface ILogRepo
    {
        Task AddAsync(model.Log log);

    }
}
