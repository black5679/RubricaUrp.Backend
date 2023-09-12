using MediatR;
using Microsoft.AspNetCore.Mvc;
using RubricaUrp.Backend.Application.Commands.Curso.Insert;
using RubricaUrp.Backend.Application.Queries.Curso.Get;
using RubricaUrp.Backend.Application.Queries.Curso.GetById;

namespace RubricaUrp.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly IMediator mediator;
        public CursoController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await mediator.Send(new GetCursoQuery());
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCursoQuery query)
        {
            var response = await mediator.Send(query);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] InsertCursoCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}