using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace LibeyTechnicalTestAPI.Controllers.LibeyUser
{
    [ApiController]
    [Route("[controller]")]
    public class LibeyUserController : Controller
    {
        private readonly ILibeyUserAggregate _aggregate;
        public LibeyUserController(ILibeyUserAggregate aggregate)
        {
            _aggregate = aggregate;
        }
        [HttpGet]
        [Route("{documentNumber}")]
        public IActionResult FindResponse(string documentNumber)
        {
            var row = _aggregate.FindResponse(documentNumber);
            return Ok(row);
        }
        [HttpGet]
        [Route("users")]
        public IActionResult Users(string filter = "")
        {
            var row = _aggregate.FindAll(filter);
            return Ok(row);
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserUpdateorCreateCommand command)
        {
            _aggregate.CreateOrUpdate(command);
            return Ok(true);
        }

        [HttpDelete]
        [Route("{documentNumber}")]
        public IActionResult Delete(string documentNumber)
        {
            _aggregate.Delete(documentNumber);
            return Ok(true);
        }
    }
}