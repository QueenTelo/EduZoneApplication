using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduZoneAPI3.DbContexts;
using EduZoneAPI3.Model.Users;
using AutoMapper;
//using EduZoneAPI3.Helpers;
using EduZoneAPI3.Interfaces.IServices;
using EduZoneAPI3.Model.Authentication;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using EduZoneAPI3.Model.Authentication;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Authorization;
using EduZoneAPI3.Services;
//using EduZoneAPI2.Authorization;
using System.Data;

namespace EduZoneAPI3.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
       
        private readonly UserManager<Users> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<Users> _signInManager;
        private IUserService _userService;
        public UsersController(
            ITokenService tokenService,
            IUserService userService,
            UserManager<Users> userManager, 
            SignInManager<Users> signInManager
            )
        {
            _tokenService = tokenService;
              _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
        }

        //[AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateDTO authenticateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == authenticateDTO.Email.ToLower());

            if(user == null) return Unauthorized("Username not found and/or password incorrect");

            var result = await _signInManager.CheckPasswordSignInAsync(user, authenticateDTO.Password, false);
                //_userService.Authenticate(model);

            if(!result.Succeeded) return Unauthorized("Username not found and/or password incorrect");

           /* // Store authenticated user in HttpContext.Items
            HttpContext.Items["User"] = user;*/

            return Ok(new AuthenticateResponse
            {
                Email = authenticateDTO.Email,
                Name = user.Name,
                Token = _tokenService.CreateToken(user)
            });
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            // validate
            try
            {
                if(!ModelState.IsValid)
                    return BadRequest(ModelState);

                var user = new Users
                {
                    UserName = registerDTO.Email,
                    Email = registerDTO.Email,
                    Name = registerDTO.Name,
                    Surname = registerDTO.Surname,
                    PassportNumber = registerDTO.PassportNumber,
                    IdentityNumber = registerDTO.IdentityNumber,
                    PhoneNumber = registerDTO.PhoneNumber, 
                    
                };

                var createdUser = await _userManager.CreateAsync(user, registerDTO.Password);

                if (createdUser.Succeeded)
                {
                    var roleresult = await _userManager.AddToRoleAsync(user, "User");
                    if (roleresult.Succeeded)
                    {
                        return Ok(
                            new RegisterResponse {

                                Email = user.Email,
                                Name = user.Name,
                                Token = _tokenService.CreateToken(user)
                            });
                    }
                    else
                    {
                        return StatusCode(500, roleresult.Errors);
                    }

                }
                else
                {
                    return StatusCode(500, createdUser.Errors);

                }
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetById(string id)
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }

        /*[HttpPut("{id}")]
        public IActionResult Update(int id, UpdateRequest model)
        {
            _userService.Update(id, model);
            return Ok(new { message = "User updated successfully" });
        }*/


        [HttpDelete("{id}")]
        [Authorize(Roles="Admin")]
        public IActionResult Delete(string id)
        {
            _userService.Delete(id);
            return Ok(new { message = "User deleted successfully" });
        }
    }
}
