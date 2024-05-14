using jobSpark.Api.Base;
using jobSpark.core.Features.achievement.commands.Model;
using jobSpark.core.Features.skills.commands.Model;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace jobSpark.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchievementController : AppControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]AddAchievementCommand command)
        {
            var response=await Mediator.Send(command);
            return NewResult(response);
        }
    }
}