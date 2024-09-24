using CrazyMusicians.Database;
using CrazyMusicians.Entities.Concrete;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CrazyMusicians.WebAPI.Controllers
{
    [Route("api/musicians")]
    [ApiController]
    public class MusiciansController : ControllerBase
    {
        // Gets all musicians
        [HttpGet]
        public IActionResult GetAllMusicians()
        {
            var musicians = InMemoryDatabase.Musicians.ToList();

            if (musicians is null)
                return NotFound();

            return Ok(musicians);
        }

        // Gets one musician by id
        [HttpGet("{id:int}")]
        public IActionResult GetOneMusician([FromRoute] int id)
        {
            var musician = InMemoryDatabase.Musicians.FirstOrDefault(x => x.Id == id);

            if (musician is null)
                return NotFound();

            return Ok(musician);
        }

        // Create one musician
        [HttpPost]
        public IActionResult CreateOneMusician([FromBody] Musician musician)
        {
            if (musician is null)
                return BadRequest();

            try
            {
                musician.Id = InMemoryDatabase.Musicians.Count + 1;

                InMemoryDatabase.Musicians.Add(musician);

                return StatusCode(201, musician);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        // Update one musician by id
        [HttpPut("{id:int}")]
        public IActionResult UpdateOneMusician([FromRoute(Name = "id")] int id, [FromBody] Musician musician)
        {
            var existingMusician = InMemoryDatabase.Musicians.FirstOrDefault(m => m.Id == musician.Id);

            if (existingMusician is null)
                return NotFound();

            if (existingMusician.Id != musician.Id)
                return BadRequest();

            musician.Id = existingMusician.Id;

            InMemoryDatabase.Musicians.Remove(existingMusician);
            InMemoryDatabase.Musicians.Add(musician);

            return Ok(musician);
        }

        // Partially updates musician
        [HttpPatch]
        public IActionResult PartiallyUpdateOneMusician([FromQuery(Name = "id")] int id, [FromBody] JsonPatchDocument<Musician> musicianPatchDocument)
        {
            var musician = InMemoryDatabase.Musicians.FirstOrDefault(m => m.Id.Equals(id));

            if (musician is null)
                return NotFound();

            musicianPatchDocument.ApplyTo(musician);

            return NoContent();
        }

        // Delete one musician by id
        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneMusician([FromRoute(Name = "id")] int id)
        {
            var musician = InMemoryDatabase.Musicians.FirstOrDefault(m => m.Id.Equals(id));

            if (musician is null)
                return NotFound();

            InMemoryDatabase.Musicians.Remove(musician);

            return NoContent();
        }
    }
}
