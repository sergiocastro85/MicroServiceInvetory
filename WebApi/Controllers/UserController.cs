using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.UseCases.Command;
using Application.UseCases.Command.User;



namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddUserCommand command)
        {
            var userId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetUser), new { id = userId }, userId);
        }

        [HttpGet("{id}")]
        public ActionResult GetUser(int id)
        {
            // Este método solo sirve para generar la URL en el CreatedAtAction
            // Implementar cuando se necesite
            return Ok();
        }
    }
}
