using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Booking.API.ViewModel;
using DomainModel.Booking;
using Microsoft.AspNetCore.Mvc;
using Models;
using BookingModel = Models.Booking;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Booking.API.Controllers
{
    [Route("api/[controller]")]
    public class BookingController : Controller
    {
        private readonly IBookingRepo repo;

        public readonly IMapper _mapper;

        public BookingController(IBookingRepo repo, IMapper mapper)
        {
            this.repo = repo;
            _mapper = mapper;
        }
        // GET: api/<controller>
        [HttpGet]
        [ProducesResponseType(200,Type = typeof(IEnumerable<BookingModel>))]
        public async Task<IEnumerable<BookingViewModel>> Get()
        {
            try
            {
                var bookings =  _mapper.Map< IEnumerable<BookingModel>, IEnumerable< BookingViewModel>>( await repo.GetAllAsync());
                return bookings;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                // Log error
                throw;
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(BookingViewModel))]
        public async Task<BookingViewModel> Get(string id)
        {
            try
            {
                return _mapper.Map<BookingModel,BookingViewModel>(await repo.GetAsync(id));
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET api/<controller>/5
        [HttpGet("{email}")]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(BookingViewModel))]
        public async Task<BookingViewModel> GetByEmailAndDate(string email,string date)
        {
            try
            {
                var book_date = Convert.ToDateTime(date);
                return _mapper.Map<BookingModel, BookingViewModel>(await repo.FindByEmailAndDate(email, book_date));
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST api/<controller>
        [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult> Post([FromBody]BookingViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values.Select(v=>v.Errors.Select(d=>d.ErrorMessage)));
            }

            var new_booking = _mapper.Map<BookingViewModel, BookingModel>(data);

            await repo.AddAsync(new_booking);

            return Created("/",data);
        }

        // PUT api/<controller>/5
        [HttpPut("confirm/{email}")]
        [Produces("application/json")]
        public async Task<IActionResult> Put(string email, string date)
        {
            var book_date = Convert.ToDateTime(date);
            var booking = await repo.FindByEmailAndDate(email, book_date);
            if (booking == null)
                return NotFound(new { ErrorMessage = "Can't find the booking date"});
            booking.IsConfirmed = true;
            booking.Status = BookingStatus.Accepted;
            await repo.UpdateAsync($"{booking.objectId}", booking);
            return Ok();
        }

        // PUT api/<controller>/5
        [HttpPut("complete/{email}")]
        [Produces("application/json")]
        public async Task<IActionResult> Complete(string email, string date)
        {
            var book_date = Convert.ToDateTime(date);
            var booking = await repo.FindByEmailAndDate(email, book_date);
            if (booking == null)
                return NotFound(new { ErrorMessage = "Can't find the booking date" });
            booking.IsComplete = true;
            await repo.UpdateAsync($"{booking.objectId}", booking);
            return Ok();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
