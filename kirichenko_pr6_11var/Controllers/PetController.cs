//using AspNetCore;

using kirichenko_pr6_11var.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace kirichenko_pr6_11var.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private WebApiDatabaseContext _db;

        public PetController(WebApiDatabaseContext db)
        {
            _db = db;
        }

        // GET: api/<PetController>
        [HttpGet]
        public IActionResult GetAll([FromQuery] string? species, [FromQuery] bool? adopted)
        {
            var pets = _db.Pets.AsQueryable();
            if (!string.IsNullOrEmpty(species) )
            {
                pets = pets.Where(p => p.Species == species);
            }
            if (adopted.HasValue)
            {
                pets = pets.Where(p => p.IsAdopted == adopted.Value);
            }
            return Ok(pets.ToList());
        }

        // GET api/<PetController>/5
        [HttpGet("{id:int}")]
        public IActionResult Get([FromRoute] int id)
        {
            var pet = _db.Pets.Find(id);
            if (pet == null)
            {
                return NotFound();
            }
            return Ok(pet);
        }

        // POST api/<PetController>
        [HttpPost]
        public IActionResult Post([FromBody] Pet pet)
        {
            if (pet == null)
            {
                return BadRequest();
            }
            _db.Pets.Add(pet);
            _db.SaveChanges();

            return CreatedAtAction(nameof(Get), new {id = pet.Id}, pet);
        }

        //PUT api/<PetController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Pet pet)
        {
            if(pet == null || id != pet.Id)
            {
                return BadRequest();
            }
            var exisPet = _db.Pets.Find(id);
            if (exisPet == null)
            {
                return NotFound();
            }

            exisPet.Name = pet.Name;
            exisPet.Species = pet.Species;
            exisPet.Weight = pet.Weight;
            exisPet.Age = pet.Age;
            exisPet.IsAdopted = pet.IsAdopted;

            _db.SaveChanges();

            return NoContent();
        }

        //PATCH api/<PetController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch([FromRoute] int id, [FromBody] Pet petUpdades)
        {
            var exisPet = _db.Pets.Find(id);
            if(exisPet == null)
            {
                return NotFound();
            }

            if(!string.IsNullOrEmpty(petUpdades.Name) && petUpdades.Name != "string") exisPet.Name = petUpdades.Name;
            if(!string.IsNullOrEmpty(petUpdades.Species) && petUpdades.Species != "string") exisPet.Species = petUpdades.Species;
            if (petUpdades.Weight != 0) exisPet.Weight = petUpdades.Weight;
            if (petUpdades.Age != 0) exisPet.Age = petUpdades.Age;
            if (petUpdades.IsAdopted != true) exisPet.IsAdopted = petUpdades.IsAdopted;
            _db.SaveChanges();

            return NoContent();
        }

        // DELETE api/<PetController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var pet = _db.Pets.Find(id);
            if(pet == null)
            {
                return NotFound();
            }
            _db.Pets.Remove(pet);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
