using fastfood.Data;
using fastfood.Model;
using fastfood.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace fastfood.Services
{
    public class LoaiServices
    {
        private readonly FastFoodDbContext context;
        public LoaiServices(FastFoodDbContext db)
        {
            context = db;
        }
        public async Task<Loai> AddLoai(LoaiVM loai, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                string path = Path.GetFullPath("D:\\ISPACE\\thiết kế web2\\reactjs-tutorial\\superfood\\src\\Uploads");
                using (var filestream = new FileStream(Path.Combine(path, loai.Hinh), FileMode.Create))
                {
                    await file.CopyToAsync(filestream);
                }
            }
            var loaix = new Loai()
            {
                TenLoai = loai.Ten,
                HinhAnh = loai.Hinh,
            };
            context.Loais.Add(loaix);
            await context.SaveChangesAsync();
            return loaix;
        }
        public IEnumerable<LoaiVM> GetAll()
        {
            var loai = context.Loais.ToList().Select(x => new LoaiVM()
            {
                MaLoai = x.id,
                Ten = x.TenLoai,
                Hinh = x.HinhAnh
            });
            return loai;
        }
        public LoaiVM GetLoaiById(int id)
        {
            var loaix = context.Loais.FirstOrDefault(x => x.id == id);
            LoaiVM data = new LoaiVM();
            if (loaix != null)
            {
                data.MaLoai = loaix.id;
                data.Ten = loaix.TenLoai;
                data.Hinh = loaix.HinhAnh;
            }
            return data;
        }
        public async Task<Loai> UpdateLoai(int id, LoaiVM loai, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                string path = Path.GetFullPath("D:\\ISPACE\\thiết kế web2\\reactjs-tutorial\\superfood\\src\\Uploads");
                using (var filestream = new FileStream(Path.Combine(path, loai.Hinh), FileMode.Create))
                {
                    await file.CopyToAsync(filestream);
                }
            }
            var loaix = context.Loais.FirstOrDefault(x => x.id == id);
            if(loai != null && loaix != null)
            {
                loaix.TenLoai = loai.Ten;
                loaix.HinhAnh = loai.Hinh;
                context.Loais.Update(loaix);
                await context.SaveChangesAsync();
            }
            return loaix;
        }
        public Loai UpdateLoai(int id, LoaiVM loai)
        {
            var loaix = context.Loais.FirstOrDefault(x => x.id == id);
            if (loai != null && loaix != null)
            {
                loaix.TenLoai = loai.Ten;
                loaix.HinhAnh = loai.Hinh;
                context.Loais.Update(loaix);
                context.SaveChanges();
            }
            return loaix;
        }
        public bool DeleteLoai(int id)
        {
            var loai = context.Loais.FirstOrDefault(x => x.id == id);
            try
            {
                context.Loais.Remove(loai);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
