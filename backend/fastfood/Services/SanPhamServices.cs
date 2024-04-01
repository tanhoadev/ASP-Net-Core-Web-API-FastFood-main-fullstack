using fastfood.Data;
using fastfood.Model;
using fastfood.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace fastfood.Services
{
    public class SanPhamServices
    {
        private readonly FastFoodDbContext _dbContext;
        public SanPhamServices(FastFoodDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<GetLoai> GetLoai()
        {
            var loai = _dbContext.Loais.ToList().Select(x => new GetLoai()
            {
                TenLoai = x.TenLoai,
                IdLoai = x.id,
            });
            return loai;
        }
        public async Task<SanPhamVM> AddSanPham(SanPhamVM sanpham, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                string path = Path.GetFullPath("D:\\ISPACE\\thiết kế web2\\reactjs-tutorial\\superfood\\src\\Uploads");
                using (var filestream = new FileStream(Path.Combine(path, sanpham.Hinh), FileMode.Create))
                {
                    await file.CopyToAsync(filestream);
                }
            }
            var sanphamx = new SanPham()
            {
                TenSP = sanpham.Ten,
                HinhAnh = sanpham.Hinh,
                Gia = sanpham.GiaBan,
                IdLoai = sanpham.IdLoai,
                HienThi = sanpham.HienThi,
                MoTa = sanpham.MoTa,
            };
            _dbContext.Add(sanphamx);
            await _dbContext.SaveChangesAsync();
            return sanpham;
        }
        public IEnumerable<SanPhamVMDB> GetAll()
        {
            var sp = _dbContext.SanPhams.Include(x => x.Loai).ToList().Select(x => new SanPhamVMDB()
            {
                id = x.id,
                Ten = x.TenSP,
                GiaBan = x.Gia,
                IdLoai = x.IdLoai,
                HienThi = x.HienThi,
                TenLoai = x.Loai.TenLoai,
                Hinh = x.HinhAnh,
                MoTa = x.MoTa
            });
            return sp;
        }
        public SanPham UpdateSP(SanPhamVM sp, int id)
        {
            var sanpham = _dbContext.SanPhams.FirstOrDefault(x => x.id == id);
            if(sanpham != null)
            {
                sanpham.TenSP = sp.Ten;
                sanpham.MoTa = sp.MoTa;
                sanpham.IdLoai = sp.IdLoai;
                sanpham.HienThi = sp.HienThi;
                sanpham.Gia = sp.GiaBan;
                _dbContext.SanPhams.Update(sanpham);
                _dbContext.SaveChanges();
            }
            return sanpham;
        }
        public async Task<SanPham> UpdateSP(SanPhamVM sp, int id, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                string path = Path.GetFullPath("D:\\ISPACE\\thiết kế web2\\reactjs-tutorial\\superfood\\src\\Uploads");
                using (var filestream = new FileStream(Path.Combine(path, sp.Hinh), FileMode.Create))
                {
                    await file.CopyToAsync(filestream);
                }
            }
            var sanpham = _dbContext.SanPhams.FirstOrDefault(x => x.id == id);
            if (sanpham != null)
            {
                sanpham.TenSP = sp.Ten;
                sanpham.MoTa = sp.MoTa;
                sanpham.IdLoai = sp.IdLoai;
                sanpham.HienThi = sp.HienThi;
                sanpham.Gia = sp.GiaBan;
                sanpham.HinhAnh = sp.Hinh;
                _dbContext.SanPhams.Update(sanpham);
                _dbContext.SaveChanges();
            }
            return sanpham;
        }
        public bool DeleteSP(int id)
        {
            var sp = _dbContext.SanPhams.FirstOrDefault(x => x.id == id);
            if (sp != null)
            {
                _dbContext.Remove(sp);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
