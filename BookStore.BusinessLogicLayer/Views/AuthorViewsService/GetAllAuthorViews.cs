using System.Collections.Generic;

namespace BookStore.BusinessLogicLayer.Views.AuthorViewsService
{
    public class GetAllAuthorViews
    {
        public List<AuthorGetAllAuthorViewsItem> Authors { get; set; }
        public GetAllAuthorViews()
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
