using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BookingModel = Models.Booking;
namespace DomainModel.Booking
{
    public interface IBookingRepo
    {
        Task AddAsync(BookingModel booking);
        Task<IEnumerable<BookingModel>> GetAllAsync();
        Task<BookingModel> GetAsync(string id);
        Task<IEnumerable<BookingModel>> GetByDateAsync(string date);
        Task UpdateAsync(string id, BookingModel updatebooking);
        Task RemoveAsync(string id);
        Task<BookingModel> FindByEmailAndDate(string email, DateTime date);

    }
}
