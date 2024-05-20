using jobSpark.Api.Base;
using jobSpark.core.Features.skills.commands.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace jobSpark.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SkillController : AppControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddSkillCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}
