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
        [Required(ErrorMessage = "Username is Required.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Address must be between 3 and 30 characters.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Passowrd is Required.")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Minimum length should be 5")]
        public string Password { get; set; }


        [Range(18, 100, ErrorMessage = "Age must be between 18 and 100.")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Age must be a number.")]
        public int Age { get; set; }


        [Required(ErrorMessage = "Gender is Required.")]
        public string Gender { get; set; }

        [RegularExpression(@"^.*$", ErrorMessage = "Name can contain any characters.")]
        [Required(ErrorMessage = "Address is Required.")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Minimum length should be 6")]
        public string  Address { get; set; }
    }
}
