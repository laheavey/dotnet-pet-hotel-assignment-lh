using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetsController(ApplicationContext context) {
            _context = context;
        }

        // GET /api/pets/
        [HttpGet]
        public IEnumerable<Pet> GetPets() {
            return _context.Pets
            .Include(pet => pet.petOwner);
        }

        // GET /api/pets/:id
        [HttpGet("{id}")]
        public ActionResult<Pet> GetById(int id) {
            Pet pet =  _context.Pets
                .Include(pet => pet.petOwner)
                .SingleOrDefault(pet => pet.id == id);
                if(pet is null) {
                    return NotFound();
                }

                return pet;
        }
        
        // POST /api/pets/
        [HttpPost]
        public IActionResult CreatePet(Pet pet)
        {
            _context.Add(pet);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = pet.id }, pet);
        }

        // PUT /api/pets/:id
        [HttpPut("{id}")]
        public Pet Put(int id, Pet pet)
        {
            // Our DB context needs to know the id of the pet to update
            pet.id = id;
            // Tell the DB context about our updated pet object
            _context.Update(pet);
            // ...and save the pet object to the database
            _context.SaveChanges();
            // Respond back with the created pet object
            return pet;
        }

        // DELETE /api/pets/:id
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Pet pet = _context.Pets.Find(id);
            _context.Pets.Remove(pet);
            _context.SaveChanges();
        }
    }
}


