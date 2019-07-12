using System.Collections.Generic;

namespace BookStore.BusinessLogicLayer.Views.AuthorViews
{
    public class GetAllAuthorView
    {
        public List<AuthorGetAllAuthorViewsItem> Authors { get; set; }
        public GetAllAuthorView()
        {
            Authors = new List<AuthorGetAllAuthorViewsItem>();
        }
    }
    public class AuthorGetAllAuthorViewsItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
