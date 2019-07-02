﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookStore.DataAccessLayer.Models
{
    public class Magazine
    {
        public int MagazineId { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
    }
}
