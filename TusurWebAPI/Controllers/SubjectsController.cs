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
    public class SubjectsController : Controller
    {
        TusurWebAPIContext context;

        public SubjectsController()
        {
            context = new TusurWebAPIContext();
        }

        [HttpGet]
        public IEnumerable<Subjects> GetSubjects()
        {
            IEnumerable<Subjects> allSubjects = context.SubjectDB.GetSubjects();
            return allSubjects;
        }

        [HttpGet("{id}")]
        public IActionResult GetSubject(int id)
        {
            Subjects currentSubject = context.SubjectDB.GetSubjects().FirstOrDefault(x => x.Id == id);
            if(currentSubject == null)
            {
                return NotFound();
            }
            else
            {
                return new ObjectResult(currentSubject);
            }
        }

        [HttpPost]
        public IActionResult CreateSubject([FromBody]Subjects newSubject)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.SubjectDB.AddSubject(newSubject);
            return Ok(newSubject);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSubject(int id)
        {
            if(context.SubjectDB.DeleteSubject(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        public IActionResult ChangeSubjects([FromBody]Subjects changedSubject)
        {
            if (context.SubjectDB.ChangeSubject(changedSubject) && ModelState.IsValid)
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
