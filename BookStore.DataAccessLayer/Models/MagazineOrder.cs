using System;

namespace BookStore.DataAccessLayer.Models
{
    public class MagazineOrder
    {
        public int MagazineOrderId { get; set; }
        public Magazine Magazine { get; set; }
        public int MagazineId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; } 
        public int TotalPrice { get; set; }
        public DateTime DataOrder { get; set; }

    }
}
