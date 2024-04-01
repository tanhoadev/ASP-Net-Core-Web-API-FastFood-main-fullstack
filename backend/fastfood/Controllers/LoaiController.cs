using fastfood.Configuration;
using fastfood.Model;
using fastfood.Services;
using fastfood.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace fastfood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiController : ControllerBase
    {
        private LoaiServices LoaiServices { get; set; }
        private readonly ILogger<LoaiController> _logger;
        //private IloggerManager x 
        public LoaiController(LoaiServices loaiServices, ILogger<LoaiController> logger)
        {
            this.LoaiServices = loaiServices;
            _logger = logger;
        }
        [HttpPost("add-cate")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> AddLoai([FromForm]LoaiVM model, [FromForm] IFormFile file)
        {
            try
            {
                _logger.LogInformation("Fetching Add Loai");
                _logger.LogInformation("Data: " + model + "-file: " + file);
                var loai = await LoaiServices.AddLoai(model, file);
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Something went wrong {ex}");
                return BadRequest();
            }
            
        }
        [HttpGet("get-all")]
        //[Authorize(Roles =UserRoles.Admin)]
        public IActionResult GetAll()
        {
            _logger.LogInformation("Fetching All Loai from the storage ");
            var sesult = LoaiServices.GetAll();
            _logger.LogInformation($"Returning {sesult.Count()} loai");
            return Ok(sesult);
        }
        [HttpGet("get-alls")]
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult GetAllLoai()
        {
            _logger.LogInformation("Fetching All Loai from the storage to Dashboard");
            var sesult = LoaiServices.GetAll();
            _logger.LogInformation($"Returning {sesult.Count()} loai");
            return Ok(sesult);
        }
        [HttpGet("get-loai-by-id")]
        public IActionResult GetLoaiById(int id)
        {
            _logger.LogInformation("Fetching loai byid: " + id);
            var serult = LoaiServices.GetLoaiById(id);
            return Ok(serult);
        }
        [HttpPut("update-loai/{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> UpdateLoai(int id, [FromForm] LoaiVM modal, [FromForm] IFormFile file)
        {
            _logger.LogInformation("Fetching Update Loai from Dashboard");
            var loai = await LoaiServices.UpdateLoai(id, modal, file);
            _logger.LogInformation("Returning result: " + loai);
            return Ok(loai);
        }
        [HttpDelete("delete-loai/{id}")]
        [Authorize(Roles =UserRoles.Admin)]
        public IActionResult DeleteLoai(int id)
        {
            _logger.LogInformation("Fetching Delete Loai from Dashboard");
            bool result = LoaiServices.DeleteLoai(id);
            _logger.LogInformation("Returning: " + result);
            if(result) return Ok();
            return BadRequest();
        }
        [HttpPut("update-loai-no-file/{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult UpdateLoai(int id, [FromForm] LoaiVM modal)
        {
            _logger.LogInformation("Fetching Update Loai from Dashboard");
            var loai = LoaiServices.UpdateLoai(id, modal);
            return Ok();
        }
    }
}
