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
    public class VariantsController : Controller
    {
        TusurWebAPIContext context;

        public VariantsController()
        {
            context = new TusurWebAPIContext();
        }

        [HttpGet("extendedVariants")]
        public IEnumerable<Object> GetExtendedVariants()
        {
            IEnumerable<Object> allVariants = context.VariantDB.GetExtendedVariants();
            return allVariants;
        }

        [HttpGet]
        public IEnumerable<Object> GetVariants()
        {
            IEnumerable<Object> allVariants = context.VariantDB.GetVariants();
            return allVariants;
        }

        [HttpGet("{id}")]
        public IActionResult GetVariant(int id)
        {
            Variants currentVariant = context.VariantDB.GetVariants().FirstOrDefault(x => x.Id == id);
            if (currentVariant == null)
            {
                return NotFound();
            }
            else
            {
                return new ObjectResult(currentVariant);
            }
        }

        [HttpPost]
        public IActionResult CreateVariant([FromBody]Variants newVariant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(context.VariantDB.AddVariant(newVariant))
            {
                return Ok(newVariant);
            } else 
            {
                return NotFound();
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVariant(int id)
        {
            if (context.VariantDB.DeleteVariant(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        public IActionResult ChangeVariant([FromBody]Variants changedVariant)
        {
            if (context.VariantDB.ChangeVariant(changedVariant) && ModelState.IsValid)
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
