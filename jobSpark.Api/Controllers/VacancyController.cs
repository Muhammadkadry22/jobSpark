using jobSpark.Api.Base;
using jobSpark.core.Features.vacancy.commands.Model;
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
        public async Task<IActionResult>GetVacancyList()
        {
            var response = await Mediator.Send(new GetVacancyListQuery());
            return NewResult(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddVacancyCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}
