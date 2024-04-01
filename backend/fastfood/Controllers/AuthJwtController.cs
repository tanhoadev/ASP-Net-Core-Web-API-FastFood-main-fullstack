using fastfood.Configuration;
using fastfood.Model;
using fastfood.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace fastfood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthJwtController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly TokenService _tokenService;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthJwtController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, TokenService tokenService, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _roleManager = roleManager;
        }
        [HttpPost]
        [Route("register-admin")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> RegisterAdmin([FromBody] UserDetails userDetails)
        {
            var userExists = await _userManager.FindByNameAsync(userDetails.UserName);
            if (userExists != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Model.Response { Status = "Error", Message = "User đã có trong hệ thống" });
            }

            var identityUser = new IdentityUser()
            {
                UserName = userDetails.UserName,
                Email = userDetails.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var result = await _userManager.CreateAsync(identityUser, userDetails.Password);

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Model.Response { Status = "Error", Message = "Có lỗi khi tạo User! Kiểm tra và thử lại" });
            }
            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
            
            if(await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(identityUser, UserRoles.Admin);
            }
            if(await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(identityUser, UserRoles.User);
            }

            return Ok(new Model.Response { Status = "Success", Message = "User được tạo thành công" });
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginCredentials credentials)
        {
            var user = await _userManager.FindByNameAsync(credentials.Username);
            if(user != null && await _userManager.CheckPasswordAsync(user, credentials.Password))
            {
                var roles = await _userManager.GetRolesAsync(user);
                var token = _tokenService.GenerateToken(user, roles);

                return Ok(new { Token = token, userName = credentials.Username});
            }
            
            return Unauthorized();
        }
    }
}
