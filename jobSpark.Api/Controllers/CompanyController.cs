using jobSpark.Api.Base;
using jobSpark.core.Features.Company.Queries.Model;
using Microsoft.AspNetCore.Http;
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
            var response=await Mediator.Send(new GetCompanytListQuery());
            return NewResult(response);
        }
    }
}
