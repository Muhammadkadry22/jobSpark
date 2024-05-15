using AutoMapper;
using jobSpark.core.Bases;
using jobSpark.core.Features.ApplicationUser.Commands.Models;
using jobSpark.core.Features.ApplicationUser.Queries.Models;
using jobSpark.core.Resources;
using jobSpark.Domain.Entities;
using jobSpark.Domain.Results;
using jobSpark.Service.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace jobSpark.core.Features.ApplicationUser.Commands.Handlers
{
    public class UserCommandHandler : ResponseHandler, IRequestHandler<AddApplicantCommand, Response<string>>
        , IRequestHandler<SignInCommand, Response<JwtAuthResult>>, IRequestHandler<AddCompanyCommand, Response<string>>
    {

        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IApplicationUserService _applicationUserService;
        private readonly SignInManager<User> _signInManager;
        private readonly IApplicantUserService _applicantUserService;
        private readonly ICompanyUserService companyUserService;

        public UserCommandHandler(
                                IMapper mapper,
                                UserManager<User> userManager,
                                IApplicationUserService applicationUserService,
                                SignInManager<User> signInManager,
                                IApplicantUserService applicantUserService,
                                ICompanyUserService companyUserService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _applicationUserService = applicationUserService;
            _signInManager = signInManager;
            _applicantUserService = applicantUserService;
            this.companyUserService = companyUserService;
        }

        public async Task<Response<string>> Handle(AddApplicantCommand request, CancellationToken cancellationToken)
        {
            var identityUser = _mapper.Map<User>(request);
            var applicant = _mapper.Map<jobSpark.Domain.Entities.Applicant>(request);
            //Create
            var createResult = await _applicationUserService.AddUserAsync(identityUser, request.Password, SharedResourcesKeys.APPLICANTROLE);
            await _applicantUserService.AddApplicant(applicant,request.Cv);

            return getResponse(createResult);

        }


        public async Task<Response<JwtAuthResult>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            //Check if user is exist or not
            var user = await _userManager.FindByEmailAsync(request.Email);
            //Return The UserName Not Found
            if (user == null) return BadRequest<JwtAuthResult>(SharedResourcesKeys.EmailIsNotExist);
            //try To Sign in 
            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            //if Failed Return Passord is wrong
            if (!signInResult.Succeeded) return BadRequest<JwtAuthResult>(SharedResourcesKeys.PasswordNotCorrect);
            //Generate Token
            var result = await _applicationUserService.GetJWTToken(user);
            //return Token 
            return Success(result);
        }

        public async Task<Response<string>> Handle(Queries.Models.AddCompanyCommand request, CancellationToken cancellationToken)
        {
            var identityUser = _mapper.Map<User>(request);
            var company = _mapper.Map<Domain.Entities.Company>(request);

            var createResult = await _applicationUserService.AddUserAsync(identityUser, request.Password, SharedResourcesKeys.COMPANYROLE);
            await companyUserService.AddCompany(company);

            return getResponse(createResult);
        }

        public Response<string> getResponse(string createResult)
        {
            switch (createResult)
            {
                case "EmailIsExist": return BadRequest<string>(SharedResourcesKeys.EmailIsExist);
                case "UserNameIsExist": return BadRequest<string>(SharedResourcesKeys.UserNameIsExist);
                case "ErrorInCreateUser": return BadRequest<string>(SharedResourcesKeys.FaildToAddUser);
                case "Failed": return BadRequest<string>(SharedResourcesKeys.TryToRegisterAgain);
                case "Success": return Success(SharedResourcesKeys.Success);
                default: return BadRequest<string>(createResult);
            }
        }


    }
}
