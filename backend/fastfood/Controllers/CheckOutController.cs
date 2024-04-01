using fastfood.Configuration;
using fastfood.Services;
using fastfood.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fastfood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckOutController : ControllerBase
    {
        private readonly CheckOutServices services;
        private readonly ILogger<CheckOutController> _logger;
        public CheckOutController(CheckOutServices services, ILogger<CheckOutController> logger)
        {
            this.services = services;
            _logger = logger;
        }
        [HttpPost("Checkout")]
        public IActionResult CheckOut([FromBody] CheckOutUserVM data)
        {
            _logger.LogInformation($"Fetching to Checkout from {data.userName}");
            var result = services.CheckOut(data);
            _logger.LogInformation($"Returning: {result}");
            if (result) return Ok(data.lstData);
            return BadRequest();
        }
        [HttpGet("get/all")]
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Fetching all Checkout");
            var res = services.GetAll();
            _logger.LogInformation("Returning: " + res.Count() + " bill");
            return Ok(res);
        }
        [HttpGet("get-detail/{id}")]
        public IActionResult GetDetails(int id) 
        {
            var result = services.GetDetail(id);
            return Ok(result);
        }
        [HttpDelete("delete-hoadon/{id}")]
        public IActionResult Delete(int id)
        {
            var x = services.Delete(id);
            if(x) return Ok();
            return BadRequest();
        }
        [HttpPut("Update-State-Status/{id}")]
        public IActionResult Update(int id, int trangThai)
        {
            var result = services.UpdateState(id, trangThai);
            return Ok(result);
        }
    }
}
