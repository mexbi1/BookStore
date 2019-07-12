using System;

namespace BookStore.DataAccessLayer.Models
{
    public class MainOrder
    {
        public int MainOrderId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

        public decimal TotalPrice { get; set; }
        public DateTime DataOrder { get; set; }
    }
}
