using System;

namespace BookStore.DataAccessLayer.Models
{
   public class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public BaseModel()
        {
            CreationDate = DateTime.UtcNow;
        }
    }
}
