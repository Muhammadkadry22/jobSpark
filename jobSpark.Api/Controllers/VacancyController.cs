using jobSpark.Api.Base;
using jobSpark.core.Features.vacancy.queries.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace jobSpark.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacancyController : AppControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetVacancyList()
        {
            var response = await Mediator.Send(new GetVacancyListQuery());
            return NewResult(response);
        }

        [HttpGet("{id}")]
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

    }
}
