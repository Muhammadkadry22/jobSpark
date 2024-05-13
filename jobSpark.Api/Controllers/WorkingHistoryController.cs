using jobSpark.Api.Base;
using jobSpark.core.Features.workingHistory.commands.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace jobSpark.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingHistoryController : AppControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWorkingHistoryCommand command)
        {
            var response=await Mediator.Send(command);
            return NewResult(response);
        }
    }
}
