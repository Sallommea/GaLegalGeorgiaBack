﻿using GaLegalGeorgia.Application.Features.PracticeArea.Commands.CreatePracticeArea;
using GaLegalGeorgia.Application.Features.PracticeArea.Commands.DeletePracticeArea;
using GaLegalGeorgia.Application.Features.PracticeArea.Commands.UpdatePracticeArea;
using GaLegalGeorgia.Application.Features.PracticeArea.Queries.GetAllPracticeAreas;
using GaLegalGeorgia.Application.Features.PracticeArea.Queries.GetPracticeAreaDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GaLegalGeorgia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PracticeAreasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PracticeAreasController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<PracticeAreasController>
        [HttpGet]
       
        public async Task<List<PracticeAreaDto>> Get()
        {
            // Get the language value from the cookie
            var languageCookie = HttpContext.Request.Cookies["lang"];
           
            // If the language cookie is not set, you can set a default value
            Language language;
            if (Enum.TryParse(languageCookie, out language) == false)
            {
                language = Language.ge; // Set a default value (e.g., English)
            }
            
            var practiceAreas = await _mediator.Send(new GetPracticeAreasQuery(language));
             return practiceAreas;
          
        }

        // GET api/<PracticeAreasController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PracticeAreaDetailDto>> Get(int id)
        {
            // Get the language value from the cookie
            var languageCookie = HttpContext.Request.Cookies["lang"];
            // If the language cookie is not set, you can set a default value
            LanguageDetails language;
            if (Enum.TryParse(languageCookie, out language) == false)
            {
                language = LanguageDetails.ge; // Set a default value (e.g., English)
            }
            var practiceAreaDetails = await _mediator.Send(new GetPracticeAreasDetailsQuery(id, language));
            return Ok(practiceAreaDetails);

        }

        // POST api/<PracticeAreasController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<ActionResult> Post(CreatePracticeAreaCommand practiceArea)
        {
            var response = await _mediator.Send(practiceArea);
            return CreatedAtAction(nameof(Get), new { id = response });
        }

        // PUT api/<PracticeAreasController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Authorize]
        public async Task<ActionResult> Put(UpdatePracticeAreaCommand practiceArea)
        {
            await _mediator.Send(practiceArea);
            return NoContent();
        }

        // DELETE api/<PracticeAreasController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeletePracticeAreaCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
