using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookStore.DataAccessLayer.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }

        public ICollection<BookAuthor> AuthorBooks { get; set; }
    }
}
