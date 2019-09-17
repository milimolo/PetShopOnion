using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationService;
using PetShop.Core.Entity;

namespace PetShop.UI.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;
        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }
        // GET api/owners
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            return _ownerService.GetOwners();
        }

        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            return _ownerService.FindOwnerById(id);
        }

        // POST api/pets
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            return _ownerService.Create(owner);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {
            if (id < 1 || id != owner.id)
            {
                return BadRequest("Parameter id and pet id must be the same");
            }
            _ownerService.Update(owner);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<Owner> Delete(int id)
        {
            var owner = _ownerService.FindOwnerById(id);
            var deletedOwner = _ownerService.Delete(owner);
            if (deletedOwner == null)
            {
                return StatusCode(404, $"Did not find the owner with ID: {id}");
            }
            return Ok($"Owner with ID: {id} has been deleted");
        }
    }
}