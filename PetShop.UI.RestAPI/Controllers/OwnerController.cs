using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationService;
using PetShop.Core.DomainService.Filtering;
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
        public ActionResult<FilteringList<Owner>> Get([FromQuery] Filter filter)
        {
            try
            {
                if (filter.CurrentPage == 0 && filter.ItemsPrPage == 0)
                {
                    var list = _ownerService.GetOwners(null);
                    var newList = new List<Owner>();
                    foreach (var owner in list.List)
                    {
                        newList.Add(new Owner()
                        {
                            id = owner.id,
                            firstName = owner.firstName,
                            lastName = owner.lastName,
                            Address = owner.Address,
                            petHistory = owner.petHistory
                        });
                    }
                    var newFilteredList = new FilteringList<Owner>();
                    newFilteredList.List = newList;
                    newFilteredList.count = list.count;
                    return Ok(newFilteredList);
                }

                var fl = _ownerService.GetOwners(filter);

                return Ok(fl);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            if (id < 1) return BadRequest("Id must be greater than 1");
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
            var deletedOwner = _ownerService.Delete(id);
            if (deletedOwner == null)
            {
                return StatusCode(404, $"Did not find the owner with ID: {id}");
            }
            return Ok($"Owner with ID: {id} has been deleted");
        }
    }
}