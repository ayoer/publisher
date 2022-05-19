using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using publisher.Models;
using publisher.Models.ContactInformation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace publisher.Controllers
{
    [Route("api/[controller]")]
    public class ContectInformationController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ContectInformationController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public ActionResult<List<ContactInformationModel>> GetAll()
        {
            var info = _context.ContactInformationModels.ToList();

            if (info != null)
            {
                return info;
            }

            return NotFound();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactInformationModel>> Get(int id)
        {
            var item = await _context.ContactInformationModels.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                return item;
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<ContactInformationModel>> Post([FromBody]ContactInformationModel value)
        {

            var info = _context.ContactInformationModels.Add(value);

            await _context.SaveChangesAsync();

            return await Get(info.Entity.Id);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ContactInformationModel>> Put(int id, [FromBody]ContactInformationModel value)
        {
            _context.ContactInformationModels.Update(value);

            await _context.SaveChangesAsync();

            return await Get(value.Id);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _context.ContactInformationModels.Remove(_context.ContactInformationModels.Find(id));
            _context.SaveChangesAsync();
        }
    }
}

