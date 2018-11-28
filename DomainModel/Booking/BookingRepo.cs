using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DomainModel.Booking
{
    public class BookingRepo : IBookingRepo
    {
        private readonly BookingContext _context;

        public BookingRepo(BookingContext context) => this._context = context;
        public async Task AddAsync(Models.Booking booking) => await _context.BookingCollection.InsertOneAsync(booking);

        public async Task<Models.Booking> FindByEmailAndDate(string email, DateTime date) => await _context.BookingCollection.Find<Models.Booking>(b => b.Date == date && b.Email == email).FirstOrDefaultAsync();
 

        public async Task<IEnumerable<Models.Booking>> GetAllAsync() => await _context.BookingCollection.Find<Models.Booking>(_ => true).ToListAsync();

        public async Task<Models.Booking> GetAsync(string id)=> await _context.BookingCollection
                                                                            .Find<Models.Booking>(book => book.objectId == ObjectId.Parse(id))
                                                                            .SingleOrDefaultAsync();

        public async Task<IEnumerable<Models.Booking>> GetByDateAsync(string date) => await _context.BookingCollection
                                                                                                .Find<Models.Booking>(book => book.Date.ToString() == date)
                                                                                                .ToListAsync();

        public async Task RemoveAsync(string id) => await _context.BookingCollection
                                                                  .DeleteOneAsync(book => book.objectId == ObjectId.Parse(id));

        public async Task UpdateAsync(string id, Models.Booking updatebooking) => await _context.BookingCollection
                                                                                                .ReplaceOneAsync<Models.Booking>(b=>b.objectId == ObjectId.Parse(id), updatebooking);
        
    }
}
