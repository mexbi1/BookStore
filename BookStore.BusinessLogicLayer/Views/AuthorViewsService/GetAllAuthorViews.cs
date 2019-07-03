using System.Collections.Generic;

namespace BookStore.BusinessLogicLayer.Views.AuthorViewsService
{
    public class GetAllAuthorViews
    {
     public List<AuthorGetAllAuthorViewsItem> AllAuthorViews  { get; set; }   
    }
    public class AuthorGetAllAuthorViewsItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
