using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

            var addresses = _context.AddressBookModels.ToList();

            if (addresses != null)
            {
                return addresses;
            }

            return NotFound();

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressBookModel>> Get(Guid id)
        {
            var item = await _context.AddressBookModels.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }else
            {
                return item;
            }
        }

        // GET api/values/5
        [HttpGet("details/{id}")]
        public ActionResult<AddressBookModel> Detail(Guid id)
        {
            var item =  _context.AddressBookModels.Where(c => c.Id == id).Include(c => c.ContactInformation).ToList();
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                return item[0];
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<AddressBookModel>> Post([FromBody] AddressBookModel value)
        {

            var address = _context.AddressBookModels.Add(value);

            await _context.SaveChangesAsync();
            
            return await Get(address.Entity.Id);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<AddressBookModel>> Put(Guid id, [FromBody] AddressBookModel value)
        {
            _context.AddressBookModels.Update(value);

            await _context.SaveChangesAsync();

            return await Get(value.Id);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
           
            _context.AddressBookModels.Remove(_context.AddressBookModels.Find(id));
            _context.SaveChangesAsync();
            
        }
    }
}

