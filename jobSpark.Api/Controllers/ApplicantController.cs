using jobSpark.Api.Base;
using jobSpark.core.Features.Applicant.Queries.Model;
using Microsoft.AspNetCore.Mvc;

namespace jobSpark.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : AppControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetApplicantById(int id)
        {
            var response = await Mediator.Send(new GetApplicantByIdQuery { Id = id });

            if (!response.Succeeded)
            {
                return NotFound(response);
            }

            return NewResult(response);
        }
    }
}
