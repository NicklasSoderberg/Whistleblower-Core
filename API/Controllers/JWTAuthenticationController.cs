using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Areas.Identity.Data;
using API.Authentication;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using API.Data.Entities;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;

namespace JWTAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticateController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
               
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    role = userRoles[0],
                    userId = user.Id
            });
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("registerUser")]
        public async Task<IActionResult> registerUser()
        {
            var username = await AutoGenerateID(false);
            var password = await AutoGenerateID(true);

            var userExists = await userManager.FindByNameAsync(username.Value);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            AppUser user = new AppUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = username.Value
            };
            var result = await userManager.CreateAsync(user, password.Value);

            if (!await roleManager.RoleExistsAsync("User"))
                await roleManager.CreateAsync(new IdentityRole("User"));

            if (await roleManager.RoleExistsAsync("User"))
                await userManager.AddToRoleAsync(user, "User");

            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            var returnUserId = await userManager.FindByNameAsync(username.Value);

            return Ok(new {userId = returnUserId.Id  });
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> register([FromBody] RegisterLawyerModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            AppUser user = new AppUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
                Email = model.Email,
                PhoneNumber = model.Phone,
                FirstName = model.FirstName,
                LastName = model.LastName,
                FirstLogin = true,
            };
            var result = await userManager.CreateAsync(user, model.Password);

            if (!await roleManager.RoleExistsAsync("Lawyer"))
                await roleManager.CreateAsync(new IdentityRole("Lawyer"));

            if (await roleManager.RoleExistsAsync("Lawyer"))
                await userManager.AddToRoleAsync(user, "Lawyer");
            

            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("lawyers")]
        public async Task<IActionResult> lawyers()
        {
            var lawyers = await userManager.GetUsersInRoleAsync("Lawyer");
            List<Lawyer> AllLawyers = new List<Lawyer>();
            foreach (AppUser l in lawyers)
                AllLawyers.Add(new Lawyer
                {
                    Id = l.Id,
                    Email = l.Email,
                    FirstName = l.FirstName,
                    LastName = l.LastName,
                    PhoneNumber = l.PhoneNumber
                });
            return Ok(AllLawyers);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult<string>> AutoGenerateID(bool isPassword)
        {
            Random r = new Random();
            string generatedID = "";
            for (int i = 0; i < 9; i++)
            {
                if (i == 3 || i == 4 || i == 8)
                {
                    char c = Convert.ToChar(r.Next(65, 90));
                    generatedID += c;
                }
                else
                {
                    generatedID += r.Next(0, 9).ToString();
                }
            }

            if (!isPassword)
            {
                var userExists = await userManager.FindByNameAsync(generatedID);
                    if (userExists != null)
                    {
                        await AutoGenerateID(false);
                    }
            }

            return new ActionResult<string>(generatedID);            
        }
    }
}
