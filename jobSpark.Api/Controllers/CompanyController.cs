using jobSpark.Api.Base;
using jobSpark.core.Features.Company.Queries.Model;
using Microsoft.AspNetCore.Mvc;

namespace jobSpark.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : AppControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCompanyList()
        {
            var response = await Mediator.Send(new GetCompanytListQuery());
            return NewResult(response);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyByIdAsync(int id)
        {
            var response = await Mediator.Send(new GetCompanyByIdQuery { Id = id });
            return NewResult(response);
        }

    }
}
