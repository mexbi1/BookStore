using System;

namespace BookStore.DataAccessLayer.Models
{
    public class BookOrder
    {


        public int BookOrderId { get; set; }

        public Book Book { get; set; }
        public int BookId { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }

        public int TotalPrice { get; set; }
        public DateTime DataOrder { get; set; }


    }
}
