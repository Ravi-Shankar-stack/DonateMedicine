using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonateMedicine.Models;

namespace DonateMedicine.Models
{
    public class Request
    {
        public int Id { get; set; }
        public string MedicineCategory { get; set; }
        public string MedicineName { get; set; }
        public int RequestedQuantity { get; set; }
        public string RequesterName { get; set; }
        public string DeliveryAddress { get; set; }
        public DateTime RequestedDate { get; set; }
    }
}
