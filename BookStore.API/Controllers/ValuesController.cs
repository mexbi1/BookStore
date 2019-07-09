using BookStore.DataAccessLayer.EntityFramework;
using BookStore.DataAccessLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BookStore.DataAccessLayer.Repository.Interfaces;

namespace BookStore.API.Controllers
{

    [Route("api/[controller]/[action]")]

    public class ValuesController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public ValuesController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // POST api/values

        [HttpPost]
        public void  Post([FromBody] string value)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Book book1 = new Book { Title = "King Lion", Price = 10 };
                Book book2 = new Book { Title = "Shrek", Price = 20 };
                Book book3 = new Book { Title = "Mafia", Price = 30 };
                db.Add(book1);
                db.Add(book2);
                db.Add(book3);
                db.SaveChanges();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        //  [HttpDelete("{id}")]
        //public void Delete(int id)


        [HttpGet]
        public List<Book> GetAll()
        {
            return _bookRepository.GetAll().ToList();
        }
    }

}



