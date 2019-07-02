using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels.ViewModels
{
  public  class GetAllAuthorViewModel
    {
        public List<AuthorGetAllAuthorViewModelItem> authorGetAllAuthor;
    }

   public class AuthorGetAllAuthorViewModelItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
