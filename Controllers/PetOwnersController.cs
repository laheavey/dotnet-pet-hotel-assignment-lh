using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context) {
            _context = context;
        }

        // GET /api/petowners/
        [HttpGet]
        public IEnumerable<PetOwner> GetPets() {
            return _context.PetOwners;
        }

        // GET /api/petowners/:id
        [HttpGet("{id}")]
        public ActionResult<PetOwner> GetById(int id) {
            PetOwner petowner =  _context.PetOwners
            .SingleOrDefault(petowner => petowner.id == id);
        if( petowner is null) {
            return NotFound();
        }
        return petowner;
        }

        // POST /api/petowners/
        [HttpPost]
        public PetOwner Post(PetOwner petowner)
        {
            _context.Add(petowner);
            _context.SaveChanges();
            return petowner;
        }

        // PUT /api/petowners/:id
        [HttpPut("{id}")]
        public PetOwner Put(int id, PetOwner petowner)
        {
            petowner.id = id;

            _context.Update(petowner);
            _context.SaveChanges();
            return petowner;
        }

        // DELETE /api/petowners/:id
        [HttpDelete("{id}")]
        public void Delete(int id) 
        {
            PetOwner petowner = _context.PetOwners.Find(id);
            _context.PetOwners.Remove(petowner);
            _context.SaveChanges();
        }
    }
}
