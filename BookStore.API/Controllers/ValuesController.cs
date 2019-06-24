using BookStore.DataAccessLayer.EntityFramework;
using BookStore.DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]

    public class ValuesController : ControllerBase
    {
        public ApplicationContext ApplicationContext;
        public ValuesController()
        {
            ApplicationContext = new ApplicationContext();

        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok();
        }

        // POST api/values
       
        [HttpPost]
        public void Post([FromBody] string value)
         {
            try
            {
                Book Book1 = new Book {BookId = 4, Title = "KingLion", Price = 10 };
                using (ApplicationContext db = new ApplicationContext())
                {
                    db.Books.Remove(Book1);
                    db.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {

                throw;
            }
           
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
