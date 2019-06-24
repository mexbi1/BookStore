using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookStore.DataAccessLayer.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }

        public List<BookAuthor> BookAuthors { get; set; }
    }
}
