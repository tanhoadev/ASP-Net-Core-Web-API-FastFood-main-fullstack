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
    public class SanPhamController : ControllerBase
    {
        private SanPhamServices SanPhamServices;
        public SanPhamController(SanPhamServices services)
        {
            SanPhamServices = services;
        }
        [HttpGet("get-all-loai")]
        public IActionResult GetAllLoai()
        {
            var result = SanPhamServices.GetLoai();
            return Ok(result);
        }
        [HttpGet("get-all-loais")]
        [Authorize(Roles =UserRoles.Admin)]
        public IActionResult GetAllLoaiAd()
        {
            var result = SanPhamServices.GetLoai();
            return Ok(result);
        }
        [HttpPost("add-sanpham")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> AddSanPham([FromForm] SanPhamVM sanpham, [FromForm] IFormFile file)
        {
            var sp = await SanPhamServices.AddSanPham(sanpham, file);
            return Ok(sp);
        }
        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var result = SanPhamServices.GetAll();
            return Ok(result);
        }
        [HttpGet("get-alls")]
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult GetAllAd()
        {
            var result = SanPhamServices.GetAll();
            return Ok(result);
        }
        [HttpPut("update-sanpham-no-file/{id}")]
        //[Authorize(Roles = UserRoles.Admin)]
        public IActionResult UpdateSP([FromForm] SanPhamVM sanpham, int id)
        {
            var sesuolt = SanPhamServices.UpdateSP(sanpham, id);
            return Ok(sesuolt);
        }
        [HttpPut("update-sanpham-has-file/{id}")]
        //[Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> UpdateSP([FromForm] SanPhamVM sanpham, int id, [FromForm] IFormFile file)
        {
            var result = await SanPhamServices.UpdateSP(sanpham, id, file);
            return Ok(result);
        }
        [HttpDelete("delete-sp/{id}")]
        //[Authorize(Roles = UserRoles.Admin)]
        public IActionResult DeleteSP(int id)
        {
            bool st = SanPhamServices.DeleteSP(id);
            if(st) return Ok();
            return BadRequest();
        }
    }
}
