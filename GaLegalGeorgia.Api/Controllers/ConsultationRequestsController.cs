using GaLegalGeorgia.Application.Features.ConsultationRequest.Commands.CreateConsultationRequest;
using GaLegalGeorgia.Application.Features.ConsultationRequest.Commands.DeleteConsultationRequest;
using GaLegalGeorgia.Application.Features.ConsultationRequest.Queries.GetAllConsultationRequests;
using GaLegalGeorgia.Application.Features.ConsultationRequest.Queries.GetConsultationRequestDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GaLegalGeorgia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultationRequestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ConsultationRequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<ConsultationRequestsController>
        [HttpGet]
        public async Task<List<ConsultationRequestDto>> Get()
        {
            var consultationRequests = await _mediator.Send(new GetConsultationRequestsQuery());
            return consultationRequests;
        }

        // GET api/<ConsultationRequestsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsultationRequestDetailsDto>> Get(int id)
        {
            var consultationRequestDetails = await _mediator.Send(new GetConsultationRequestDetailsQuery(id));
            return Ok(consultationRequestDetails);
        }

        // POST api/<ConsultationRequestsController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateConsultationRequestCommand consultationRequest)
        {
            var response = await _mediator.Send(consultationRequest);
            return CreatedAtAction(nameof(Get), new { id = response });
        }


        // DELETE api/<ConsultationRequestsController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteConsultationRequestCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
