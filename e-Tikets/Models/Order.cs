using System.Collections.Generic;

namespace e_Tikets.Models
{
    public class Order
    {
        public int Id { get; set; } 
        public string UserEmail { get; set; }
        public string UserId { get; set; }

        public List<OrderItem> OrderItems { get; set; }

    }
}
