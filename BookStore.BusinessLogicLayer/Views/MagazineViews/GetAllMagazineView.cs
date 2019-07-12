using System.Collections.Generic;

namespace BookStore.BusinessLogicLayer.Views.MagazineViews
{
    public class GetAllMagazineView
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
