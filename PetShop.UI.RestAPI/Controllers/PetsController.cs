using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationService;
using PetShop.Core.DomainService.Filtering;
using PetShop.Core.Entity;
using PetShop.UI.RestAPI.Dtos;

namespace PetShop.UI.RestAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;
        public PetsController(IPetService petService)
        {
            _petService = petService;
        }
        // GET api/pets
        //[Authorize]
        [HttpGet]
        public ActionResult<FilteringList<Pet>> Get([FromQuery] Filter filter)
        {
            try
            {
                if(filter.CurrentPage == 0 && filter.ItemsPrPage == 0)
                {
                    var list = _petService.GetPets(null);
                    var newList = new List<Pet>();
                    foreach (var pet in list.List)
                    {
                        newList.Add(new Pet()
                        {
                            ID = pet.ID,
                            name = pet.name,
                            type = pet.type,
                            birthday = pet.birthday,
                            soldDate = pet.soldDate,
                            color = pet.color,
                            price = pet.price,
                            ownersHistory = pet.ownersHistory
                        }) ;
                    }
                    var newFilteredList = new FilteringList<Pet>();
                    newFilteredList.List = newList;
                    newFilteredList.count = list.count;
                    return Ok(newFilteredList);
                }

                var fl = _petService.GetPets(filter);

                return Ok(fl);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        // GET api/pets by id
        //[Authorize]
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            if (id < 1) return BadRequest("Id must be greater than 1");

            //var corePet = _petService.FindPetById(id);
            //return new PetDTO()
            //{
            //    ID = corePet.ID,
            //    name = corePet.name
            //};
            return _petService.FindPetById(id);
        }

        // POST api/pets
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            return _petService.Create(pet);
        }

        // PUT api/values/5
        //[Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            if (id<1 || id != pet.ID)
            {
                return BadRequest("Parameter id and pet id must be the same");
            }
            _petService.Update(pet);
            return Ok();
        }

        // DELETE api/values/5
        //[Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public ActionResult<Pet> Delete(int id)
        {
            var pet = _petService.Delete(id);
            if(pet == null)
            {
                return StatusCode(404, $"Did not find the pet with ID: {id}");
            }
            return Ok($"Pet with ID: {id} has been deleted");
        }
    }
}