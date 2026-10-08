using AspNetCore;

using kirichenko_pr6_11var.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace kirichenko_pr6_11var.Controllers
{
    [Route("api/v11/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private WebApiDatabaseContext db;

        private PetController(WebApiDatabaseContext _db)
        {
            _db = db;
        }

        // GET: api/<PetController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var pet = db.Pets.ToList();
            return Ok(pet);
        }

        // GET api/<PetController>/5
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            Pet? pet = db.Pets.Find(id);
            if (pet == null)
            {
                return NotFound();
            }
            return Ok();
        }

        // POST api/<PetController>
        [HttpPost]
        public void Post([FromBody] Pet pet)
        {
            
        }

        //PUT api/<PetController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PetController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
