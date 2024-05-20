using jobSpark.Api.Base;
using jobSpark.core.Features.ApplicationUser.Commands.Models;
using jobSpark.core.Features.ApplicationUser.Queries.Models;
using jobSpark.Domain.AppMetaData;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace jobSpark.Api.Controllers
{

    public class ApplicationUserController : AppControllerBase
    {


        [HttpPost(Router.ApplicationUserRouting.Create)]
        public async Task<IActionResult> Create([FromForm] AddApplicantCommand command)
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

            //throw new Exception("huihuuhohihoi");
            Log.Information("Serilog بتمسي");
            Log.Error("jiojio");
            Log.Fatal("vgrvgbvgs");
            var response = await Mediator.Send(command);
            return NewResult(response);

        }



    }
}
