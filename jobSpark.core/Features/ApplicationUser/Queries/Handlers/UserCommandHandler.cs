using AutoMapper;
using jobSpark.core.Bases;
using jobSpark.core.Features.ApplicationUser.Queries.Models;
using jobSpark.core.Resources;
using jobSpark.Domain.Entities;
using jobSpark.Domain.Results;
using jobSpark.Service.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.core.Features.ApplicationUser.Queries.Handlers
{
    public class UserCommandHandler : ResponseHandler, IRequestHandler<AddUserCommand, Response<string>>
        ,IRequestHandler<SignInCommand, Response<JwtAuthResult>>
    {

        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IApplicationUserService _applicationUserService;
        private readonly SignInManager<User> _signInManager;


        public UserCommandHandler(
                                IMapper mapper,
                                UserManager<User> userManager,
                                IApplicationUserService applicationUserService,
                                SignInManager<User> signInManager) 
        {
            _mapper = mapper;
            _userManager = userManager;
            _applicationUserService = applicationUserService;
            _signInManager = signInManager;
        }

        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var identityUser = _mapper.Map<User>(request);
            //Create
            var createResult = await _applicationUserService.AddUserAsync(identityUser, request.Password ,request.Role );
            switch (createResult)
            {
                case "EmailIsExist": return BadRequest<string>(SharedResourcesKeys.EmailIsExist);
                case "UserNameIsExist": return BadRequest<string>(SharedResourcesKeys.UserNameIsExist);
                case "ErrorInCreateUser": return BadRequest<string>(SharedResourcesKeys.FaildToAddUser);
                case "Failed": return BadRequest<string>(SharedResourcesKeys.TryToRegisterAgain);
                case "Success": return Success<string>(SharedResourcesKeys.Success);
                default: return BadRequest<string>(createResult);
            }
        }


        public async Task<Response<JwtAuthResult>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            //Check if user is exist or not
            var user = await _userManager.FindByNameAsync(request.UserName);
            //Return The UserName Not Found
            if (user == null) return BadRequest<JwtAuthResult>(SharedResourcesKeys.UserNameIsNotExist);
            //try To Sign in 
            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            //if Failed Return Passord is wrong
            if (!signInResult.Succeeded) return BadRequest<JwtAuthResult>(SharedResourcesKeys.PasswordNotCorrect);
            //Generate Token
            var result = await _applicationUserService.GetJWTToken(user);
            //return Token 
            return Success(result);
        }



    }
}
