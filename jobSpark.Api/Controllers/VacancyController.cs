using jobSpark.Api.Base;
using jobSpark.core.Features.vacancy.commands.Model;
using jobSpark.core.Features.vacancy.queries.Model;
using jobSpark.core.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace jobSpark.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class VacancyController : AppControllerBase
    {



        [HttpGet("/GetVacancyPaginated")]
        [Authorize(Roles = SharedResourcesKeys.COMPANYROLE)]
        public async Task<IActionResult> GetVacancyPaginated([FromQuery] GetVacancyPaginatedListQuery query)
        {

            var response = await Mediator.Send(query);
            return NewResult(response);
        }



        [HttpGet]
        // [Authorize(Roles = SharedResourcesKeys.COMPANYROLE)]
        public async Task<IActionResult> GetVacancyList()
        {
            var response = await Mediator.Send(new GetVacancyListQuery());
            return NewResult(response);
        }


        [HttpGet("{id}")]
        [Authorize(Roles = SharedResourcesKeys.APPLICANTROLE)]
        public async Task<IActionResult> GetVacancyById(int id)
        {
            var response = await Mediator.Send(new GetVacancyByIdQuery { Id = id });

            if (!response.Succeeded)
            {
                // Handle the case where the vacancy with the specified ID was not found
                return NotFound(response); // Returning a NotFound result with the response object
            }

            return NewResult(response);
        }


        [HttpPost]
        //  [Authorize(Roles = SharedResourcesKeys.COMPANYROLE)]
        public async Task<IActionResult> Create([FromBody] AddVacancyCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpPost("/apply")]
        [Authorize(Roles = SharedResourcesKeys.APPLICANTROLE)]
        public async Task<IActionResult> Apply([FromBody] ApplyToVacancyCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }


        [HttpGet("/showapplicantsPaginated")]
        [Authorize(Roles = SharedResourcesKeys.COMPANYROLE)]
        public async Task<IActionResult> ShowApplicantsPaginated([FromQuery] GetVacancyApplicantsPaginatedQuery query)
        {
            var response = await Mediator.Send(query);
            Log.Information("Response data: {@Response}", response);
            return NewResult(response);
        }



        [HttpGet("/showapplicants/{id}")]
        [Authorize(Roles = SharedResourcesKeys.COMPANYROLE)]
        public async Task<IActionResult> ShowApplicants(int id)
        {
            return NewResult(await Mediator.Send(new GetVacancyApplicantsQuery { Id = id }));
        }
    }
}
