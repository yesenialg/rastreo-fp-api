using MediatR;
using Microsoft.AspNetCore.Mvc;
using RastreoFirplak.Application.Features.Guias.Commands.UpdateGuia;
using RastreoFirplak.Application.Features.Guias.Queries;
using RastreoFirplak.Application.Features.Guias.Queries.GetGuiaById;
using System.Net;

namespace RastreoFirplak.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuiaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GuiaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{Id}", Name = "GetGuia")]
        [ProducesResponseType(typeof(GuiaModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GuiaModel>> GetGuiaById(string Id)
        {
            var query = new GetGuiaByIdQuery(Id);
            return await _mediator.Send(query);
        }

        [HttpGet("ByNumero/{Numero}", Name = "GetGuiaByNumero")]
        [ProducesResponseType(typeof(GuiaModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GuiaModel>> GetGuiaByNumero(string Numero)
        {
            var query = new GetGuiaByNumeroQuery(Numero);
            return await _mediator.Send(query);
        }

        [HttpPut(Name = "UpdateGuia")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateGuia([FromBody] UpdateGuiaCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
