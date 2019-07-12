using System.Collections.Generic;

namespace BookStore.DataAccessLayer.Models
{
    public class Book:BaseModel
    {
        public string Title { get; set; }
        public decimal Price { get; set; }

        public List<BookAuthor> BookAuthors { get; set; }
    }
}
