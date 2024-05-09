using jobSpark.Api.Base;
using jobSpark.core.Features.category.queries.Model;
using jobSpark.core.Features.vacancy.queries.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace jobSpark.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : AppControllerBase
    {
        //[HttpGet]
        //public async Task<IActionResult> GetVacancyList()
        //{
        //    var response = await Mediator.Send(new GetVacancyListQuery());
        //    return NewResult(response);
        //}
        [HttpGet]
        public async Task<IActionResult> GetCategorylist()
        {
            var response = await Mediator.Send(new GetCategoryListQuery());
            return NewResult(response);

        }
    }
}
