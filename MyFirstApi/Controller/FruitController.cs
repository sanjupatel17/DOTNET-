using Microsoft.AspNetCore.Mvc;
using FruitApi.Models;

namespace FruitApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FruitController : ControllerBase
    {
        private static List<Fruit> fruits = new List<Fruit>
        {
            new Fruit { Id = 1, Name = "Apple", Color = "Red", Price = 120 },
            new Fruit { Id = 2, Name = "Banana", Color = "Yellow", Price = 40 }
            
        };

        // GET: api/fruit
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(fruits);
        }

        // GET: api/fruit/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var fruit = fruits.FirstOrDefault(f => f.Id == id);
            if (fruit == null)
                return NotFound();

            return Ok(fruit);
        }

        // POST: api/fruit
        [HttpPost]
        public IActionResult Create(Fruit fruit)
        {
            fruit.Id = fruits.Max(f => f.Id) + 1;
            fruits.Add(fruit);
            return Ok(fruit);
        }

        // PUT: api/fruit/1
        [HttpPut("{id}")]
        public IActionResult Update(int id, Fruit updatedFruit)
        {
            var fruit = fruits.FirstOrDefault(f => f.Id == id);
            if (fruit == null)
                return NotFound();

            fruit.Name = updatedFruit.Name;
            fruit.Color = updatedFruit.Color;
            fruit.Price = updatedFruit.Price;

            return Ok(fruit);
        }

        // DELETE: api/fruit/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var fruit = fruits.FirstOrDefault(f => f.Id == id);
            if (fruit == null)
                return NotFound();

            fruits.Remove(fruit);
            return Ok();
        }
    }
}
