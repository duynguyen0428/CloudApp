using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Log.API.ViewModel
{
    public class LogViewModel
    {
        [Required]
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public string Message { get; set; } = string.Empty;
        public string Context { get; set; }
    }
}
