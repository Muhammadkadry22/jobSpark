using jobSpark.Api.Base;
using jobSpark.core.Features.project.commands.Model;
using jobSpark.core.Features.skills.commands.Model;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace jobSpark.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : AppControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]AddProjectCommand command)
        {
            var response=await Mediator.Send(command);
            return NewResult(response);
        }
          
    }
}