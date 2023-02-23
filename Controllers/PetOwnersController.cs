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

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<PetOwner> GetPets() {
            return new List<PetOwner>();
        }

        [HttpGet("{id}")]
        public ActionResult<PetOwner> GetById(int id) {
            PetOwner petowner =  _context.PetOwners
            .SingleOrDefault(petowner => petowner.id == id);
        if( petowner is null) {
            return NotFound();
        }
        return petowner;
        }

        [HttpDelete("{id}")]
        public void Delete(int id) 
        {
            // Find the bread, by ID
            PetOwner petowner = _context.PetOwners.Find(id);

            // Tell the DB that we want to remove this bread
            _context.PetOwners.Remove(petowner);

            // ...and save the changes to the database
            _context.SaveChanges();
        }
    }
}
