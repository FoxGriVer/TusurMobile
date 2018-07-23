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
    public class ProfilesController : Controller
    {
        TusurWebAPIContext context;

        public ProfilesController()
        {
            context = new TusurWebAPIContext();
        }

        [HttpGet]
        public IEnumerable<Object> GetProfiles()
        {
            IEnumerable<Object> allProfiles = context.ProfileDB.GetExtendedProfiles();
            return allProfiles;
        }

        [HttpGet("{id}")]
        public IActionResult GetProfile(int id)
        {
            Profiles currentProfile = context.ProfileDB.GetProfiles().FirstOrDefault(x => x.Id == id);
            if (currentProfile == null)
            {
                return NotFound();
            }
            else
            {
                return new ObjectResult(currentProfile);
            }
        }

        [HttpPost]
        public IActionResult CreateProfile([FromBody]Profiles newProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                context.ProfileDB.AddProfile(newProfile);
                return Ok(newProfile);
            }
        }

        [HttpPut]
        public IActionResult ChangeProfile([FromBody]Profiles changedProfile)
        {
            if (context.ProfileDB.ChangeProfile(changedProfile) && ModelState.IsValid)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProfile(int id)
        {
            if (context.ProfileDB.DeleteProfile(id))
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
