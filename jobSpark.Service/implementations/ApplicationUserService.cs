using jobSpark.Domain.Entities;
using jobSpark.Domain.Helpers;
using jobSpark.Domain.Results;
using jobSpark.Infrastructure.Context;
using jobSpark.Service.Abstracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace jobSpark.Service.implementations
{
    internal class ApplicationUserService : IApplicationUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _applicationDBContext;
        private readonly JwtSettings _jwtSettings;


        public ApplicationUserService(UserManager<User> userManager ,
            ApplicationDbContext applicationDBContext , 
            RoleManager<IdentityRole> roleManager ,
            JwtSettings jwtSettings)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtSettings = jwtSettings;
            _applicationDBContext = applicationDBContext;


        }

        public async Task<string> AddUserAsync(User user, string password , string role)
        {
            var trans = await _applicationDBContext.Database.BeginTransactionAsync();
            try
            {
                //if Email is Exist
                var existUser = await _userManager.FindByEmailAsync(user.Email);
                //email is Exist
                if (existUser != null) return "EmailIsExist";

                //if username is Exist
                var userByUserName = await _userManager.FindByNameAsync(user.UserName);
                //username is Exist
               if (userByUserName != null) return "UserNameIsExist";
                //Create
                var createResult = await _userManager.CreateAsync(user, password);
                //Failed
                if (!createResult.Succeeded)
                    return string.Join(",", createResult.Errors.Select(x => x.Description).ToList());


                //assign User To Role
                await assignUserRole(role , user);

                await trans.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                return "Failed";
            }
        }

        

        private async Task assignUserRole(string role , User user)
        {
            IdentityRole? userRole = new IdentityRole("User");
            IdentityRole? companyRole = new IdentityRole("Company");
            if (role == "User")
            {
                if (!await _roleManager.RoleExistsAsync("User"))
                {
                    // Create the role
                    userRole = new IdentityRole("User");
                    await _roleManager.CreateAsync(userRole);
                }
                    await _userManager.AddToRoleAsync(user, userRole.Name);
            }
            else if(role == "Company")
            {
                if (!await _roleManager.RoleExistsAsync("Company"))
                {
                    // Create the role
                    companyRole = new IdentityRole("Company");
                    await _roleManager.CreateAsync(companyRole);
                }
               await _userManager.AddToRoleAsync(user, companyRole.Name);
            }

        }




        public async Task<JwtAuthResult> GetJWTToken(User user)
        {
            var (jwtToken, accessToken) = await GenerateJWTToken(user);

            var response = new JwtAuthResult();
            response.AccessToken = accessToken;

            return response;
        }


        private async Task<(JwtSecurityToken, string)> GenerateJWTToken(User user)
        {
            var claims = await GetClaims(user);
            var jwtToken = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                expires: DateTime.Now.AddDays(_jwtSettings.AccessTokenExpireDate),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature));
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return (jwtToken, accessToken);
        }

        public async Task<List<Claim>> GetClaims(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(nameof(UserClaimModel.Id), user.Id.ToString()),
            };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var userClaims = await _userManager.GetClaimsAsync(user);
            claims.AddRange(userClaims);
            return claims;
        }



    }
}
