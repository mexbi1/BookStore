using System.Collections.Generic;

namespace BookStore.BusinessLogicLayer.Views.BookViews
{
    public class GetAllBookView
    {
        public List<BookGetAllBookItemView> books;
    }
    public class BookGetAllBookItemView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
    }
}
