using jobSpark.Api.Base;
using jobSpark.core.Features.ApplicationUser.Commands.Models;
using jobSpark.core.Features.ApplicationUser.Queries.Models;
using jobSpark.Domain.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace jobSpark.Api.Controllers
{

    public class ApplicationUserController: AppControllerBase
    {
        [HttpPost(Router.ApplicationUserRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddApplicantCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpPost(Router.ApplicationUserRouting.CreateCompany)]
        public async Task<IActionResult> Create([FromBody] AddCompanyCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }



        [HttpPost(Router.Authentication.SignIn)]
        public async Task<IActionResult> SignIn([FromBody] SignInCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);

        }



    }
}
