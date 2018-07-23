using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TusurWebAPI.Models;
using TusurWebAPI.DataBaseCommunication;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TusurWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class SpecialtiesController : Controller
    {
        TusurWebAPIContext context;

        public SpecialtiesController()
        {
            context = new TusurWebAPIContext();
        }

        [HttpGet]
        public IEnumerable<Object> GetSpecialties()
        {
            IEnumerable<Object> allSpecialties = context.SpecialityDB.GetSpecialties();
            return allSpecialties;
        }

        [HttpGet("extended")]
        public IEnumerable<Object> GetExtendedSpecialties()
        {
            IEnumerable<Object> allSpecialties = context.SpecialityDB.GetExtendedSpecialties();
            return allSpecialties;
        }

        [HttpGet("{id}")]
        public IActionResult GetExtendedSpecialties(int id)
        {
            Specialties currentSpeciality = context.SpecialityDB.GetExtendedSpecialties().FirstOrDefault(x => x.Id == id);
            if (currentSpeciality == null)
            {
                return NotFound();
            }
            else
            {
                return new ObjectResult(currentSpeciality);
            }
        }

        [HttpPost]
        public IActionResult CreateSpeciality([FromBody]Specialties newSpeciality)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                context.SpecialityDB.AddSpeciality(newSpeciality);
                return Ok(newSpeciality);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSpeciality(int id)
        {
            if (context.SpecialityDB.DeleteSpeciality(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        public IActionResult ChangeSpeciality([FromBody]Specialties changedSpeciality)
        {
            if (context.SpecialityDB.ChangeSpeciality(changedSpeciality) && ModelState.IsValid)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

    }
}
