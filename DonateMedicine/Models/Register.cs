using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DonateMedicine.Models
{
    public class Register
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string  Address { get; set; }
    }
}
