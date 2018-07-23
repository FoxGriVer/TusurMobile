using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TusurWebAPI.DataBaseCommunication;
using TusurWebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TusurWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class QuestionsController : Controller
    {
        TusurWebAPIContext context;

        public QuestionsController()
        {
            context = new TusurWebAPIContext();
        }

        [HttpGet]
        public IEnumerable<Questions> GetQuestions()
        {
            IEnumerable<Questions> allQuestions = context.QuestionDB.GetQuestions();
            return allQuestions;
        }

        [HttpGet("{id}")]
        public IActionResult GetQuestion(int id)
        {
            Questions currentQuestion = context.QuestionDB.GetQuestions().FirstOrDefault(x => x.Id == id);
            if (currentQuestion == null)
            {
                return NotFound();
            }
            else
            {
                return new ObjectResult(currentQuestion);
            }
        }

        [HttpGet("extended/{id}")]
        public IActionResult GetExtendedQuestion(int id)
        {
            Questions currentQuestion = context.QuestionDB.GetExtendedQuestion(id);
            if (currentQuestion == null)
            {
                return NotFound();
            }
            else
            {
                return new ObjectResult(currentQuestion);
            }
        }

        [HttpPost]
        public IActionResult CreateQuestion([FromBody]Questions newQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.QuestionDB.AddQuestion(newQuestion);
            return Ok(newQuestion);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteQuestion(int id)
        {
            if (context.QuestionDB.DeleteQuestion(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        public IActionResult ChangeQuestion([FromBody]Questions changedQuestion)
        {
            if (context.QuestionDB.ChangeQuestion(changedQuestion) && ModelState.IsValid)
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
