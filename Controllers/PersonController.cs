using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WhiteProject.Services;
using WhiteProject.Models;

namespace WhiteProject.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PersonController : ControllerBase
{
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_personService.GetPersons());
    }

    [HttpGet("{id}")]
    public IActionResult Get(Guid id)
    {
        return Ok(_personService.GetPerson(id));
    }

    [HttpPost]
    public IActionResult Post([FromBody] Person person)
    {
        _personService.Create(person);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Person person)
    {
        _personService.Update(id, person);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        _personService.Delete(id);
        return Ok();
    }

}
