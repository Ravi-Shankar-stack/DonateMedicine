using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DonateMedicine.Models
{
    public class Medicine
    {
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "This field can't be empty")]
        [MinLength(4)]

        public string Name { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "This field can't be empty")]
        [MinLength(4)]
        public string Category { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "This field can't be empty")]
        public int Quantity { get; set; }
    }
}
