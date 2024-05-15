﻿using jobSpark.Api.Base;
using jobSpark.core.Features.vacancy.commands.Model;
using jobSpark.core.Features.vacancy.queries.Model;
using jobSpark.core.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace jobSpark.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class VacancyController : AppControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "Company")]
        public async Task<IActionResult> GetVacancyList()
        {
            var response = await Mediator.Send(new GetVacancyListQuery());
            return NewResult(response);
        }


        [HttpGet("{id}")]
        [Authorize(Roles ="Applicant")]
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
        [Authorize(Roles =SharedResourcesKeys.COMPANYROLE)]
        public async Task<IActionResult> Create([FromBody] AddVacancyCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpPost("/apply")]
        [Authorize(Roles =SharedResourcesKeys.APPLICANTROLE)]
        public async Task<IActionResult> Apply([FromBody] ApplyToVacancyCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }

        [HttpGet("/showapplicants/{id}")]
        [Authorize(Roles =SharedResourcesKeys.COMPANYROLE)]
        public async Task<IActionResult> ShowApplicants(int id)
        {
            return NewResult(await Mediator.Send(new GetVacancyApplicantsQuery { Id = id }));
        }
    }
}
