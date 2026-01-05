using Microsoft.AspNetCore.Mvc;
using ProductWebAPI.Entities;
using ProductWebAPI.Services;

namespace ProductWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlowerController : ControllerBase
    {
        private readonly IFlowerService _service;

        public FlowerController(IFlowerService service)
        {
            _service = service;
        }

        // GET: api/flower
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAllFlowers());
        }

        // GET: api/flower/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var flower = _service.GetFlowerById(id);
            return flower == null ? NotFound() : Ok(flower);
        }

        // POST: api/flower
        [HttpPost]
        public IActionResult Create(Flower flower)
        {
            _service.AddFlower(flower);
            return CreatedAtAction(nameof(GetById), new { id = flower.Id }, flower);
        }

        // PUT: api/flower/1
        [HttpPut("{id}")]
        public IActionResult Update(int id, Flower flower)
        {
            var updated = _service.UpdateFlower(id, flower);
            return updated ? NoContent() : NotFound();
        }

        // DELETE: api/flower/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _service.DeleteFlower(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
