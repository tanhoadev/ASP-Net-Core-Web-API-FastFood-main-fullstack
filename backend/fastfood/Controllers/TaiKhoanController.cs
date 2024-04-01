using fastfood.Configuration;
using fastfood.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fastfood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanController : ControllerBase
    {
        private readonly TaiKhoanServices services;
        public TaiKhoanController(TaiKhoanServices services)
        {
            this.services = services;
        }
        [HttpGet("get-all")]
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult Getall() 
        {
            var result = services.GetAll();
            return Ok(result);
        }
        [HttpDelete("delete-Account/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await services.Delete(id);
            if(result) return Ok(result);
            return BadRequest();
        }
    }
}
