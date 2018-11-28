using AutoMapper;
using Booking.API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingModel = Models.Booking;
namespace Booking.API.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<BookingModel, BookingViewModel>()
                .ReverseMap();
        }
    }
}
