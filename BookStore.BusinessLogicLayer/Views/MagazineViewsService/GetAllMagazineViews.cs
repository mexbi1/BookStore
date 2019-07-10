﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.BusinessLogicLayer.Views.MagazineViewsService
{
    public class GetAllMagazineViews
    {
        public List<MagazineGetAllMagazineViewItem> MagazineItem;
    }
    public class MagazineGetAllMagazineViewItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
    }
}
