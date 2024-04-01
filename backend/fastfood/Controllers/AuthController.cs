﻿using fastfood.Configuration;
using fastfood.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;

namespace fastfood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        public AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        [HttpPost]
        [Route("Register")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Register([FromBody] UserDetails userDetails)
        {

            if(!ModelState.IsValid || userDetails == null)
            {
                return new BadRequestObjectResult(new {Message = "Lỗi đăng kí"});
            }
            var identityUser = new IdentityUser()
            {
                UserName = userDetails.UserName,
                Email = userDetails.Email,
            };
            var result = await userManager.CreateAsync(identityUser, userDetails.Password);
            if (!result.Succeeded)
            {
                var dictionary = new ModelStateDictionary();
                foreach(IdentityError error in result.Errors)
                {
                    dictionary.AddModelError(error.Code, error.Description);
                }
                return new BadRequestObjectResult(new {Message = "Lỗi đăng ký", Errors = dictionary});
            }
            return Ok(new { Message = "Đăng ký thành công" });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginCredentials credentials)
        {
            if(!ModelState.IsValid || credentials == null) 
            {
                return new BadRequestObjectResult(new { Message = "Lỗi đăng nhập" });
            }
            var identityUser = await userManager.FindByNameAsync(credentials.Username);
            if(identityUser == null)
            {
                return new BadRequestObjectResult(new { Message = "Lỗi đăng nhập" });
            }
            var result = userManager.PasswordHasher.VerifyHashedPassword(identityUser, identityUser.PasswordHash, credentials.Password);
            if(result == PasswordVerificationResult.Failed)
            {
                return new BadRequestObjectResult(new { Message = "Lỗi đăng nhập" });
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, identityUser.Email),
                new Claim(ClaimTypes.Name, identityUser.UserName)
            };
            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));
            return Ok(new { Message = "User đã đăng nhập" });
        }
        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok(new { Message = "User đã thoát" });
        }
    }
}
