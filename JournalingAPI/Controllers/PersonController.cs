using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JournalingAPI.Entities;
using JournalingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JournalingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet("getPersons")]
        public async Task<IActionResult> GetPersons()
        {
            var result = await _personService.GetAsync();
            return Ok(result);
        }

        [HttpGet("getPerson")]
        public async Task<IActionResult> GetPerson([FromQuery] string id)
        {
            return Ok(await _personService.GetAsync(id));
        }

        [HttpPost("createPerson")]
        public async Task<IActionResult> CreatePerson([FromBody] Person person)
        {
            await _personService.CreateAsync(person);
            return Ok(await _personService.GetAsync(person.Id));
        }

        [HttpPost("updatePerson")]
        public async Task<IActionResult> UpdatePerson([FromBody] Person person, [FromQuery] string id)
        {
            await _personService.UpdateAsync(id, person);
            return Ok();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete([FromQuery] string id)
        {
            await _personService.DeleteAsync(id);
            return Ok();
        }
    }
}