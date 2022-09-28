using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_Tikets.Models
{
    public class Order
    {
        public int Id { get; set; } 
        public string UserEmail { get; set; }
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicatoinUser User { get; set; }
        public List<OrderItem> OrderItems { get; set; }

    }
}
