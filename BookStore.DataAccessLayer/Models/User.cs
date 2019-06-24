
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookStore.DataAccessLayer.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public int Password { get; set; }
        public string Name { get; set; }
    }
}
