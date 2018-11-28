using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.API.ViewModel
{
    public class BookingViewModel
    {
        [Required(ErrorMessage = "Please Select Booking Date"), 
        DataType(DataType.Date, ErrorMessage = "Please input valid date"), 
        DisplayFormat(DataFormatString = "mm-dd-yyyy")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Please Enter First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please Enter Email"),
        EmailAddress(ErrorMessage = "Please Enter Valid Email"),
        RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "Please Enter Valid Phone Number")]
        public string Email { get; set; }
        [RegularExpression(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}",ErrorMessage = "Please Enter Valid Phone Number"), 
        Phone(ErrorMessage = "Please Enter Valid Phone Number")]
        public string Mobile { get; set; }
    }
}
