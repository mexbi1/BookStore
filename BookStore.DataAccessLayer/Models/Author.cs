using System;
using System.Collections.Generic;

namespace BookStore.DataAccessLayer.Models
{
    public class Author:BaseModel
    {
        public string Name { get; set; }

        public ICollection<BookAuthor> AuthorBooks { get; set; }
    }
}
