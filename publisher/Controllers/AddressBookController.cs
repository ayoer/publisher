using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using publisher.Models;
using publisher.Models.AddressBook;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace publisher.Controllers
{
    [Route("api/[controller]")]
    public class AddressBookController : Controller
    {

        private readonly ApplicationDbContext _context;

        public AddressBookController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public ActionResult<List<AddressBookModel>> GetAll()
        {

            return _context.AddressBookModels.ToList();

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<AddressBookModel> Get(int id)
        {
            var item = _context.AddressBookModels.Find(id);
            if (item == null)
            {
                return NotFound();
            }else
            {
                return item;
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] AddressBookModel value)
        {

             _context.AddressBookModels.Add(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] AddressBookModel value)
        {
            _context.AddressBookModels.Update(value);

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _context.AddressBookModels.Find(id);
            if (item != null)
            {
                _context.AddressBookModels.Remove(item);
            }
        }
    }
}

