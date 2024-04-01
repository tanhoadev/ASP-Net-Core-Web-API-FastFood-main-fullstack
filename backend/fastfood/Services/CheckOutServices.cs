using fastfood.Data;
using fastfood.Model;
using fastfood.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace fastfood.Services
{
    public class CheckOutServices
    {
        private readonly FastFoodDbContext _db;
        private readonly UserManager<IdentityUser> userManager;
        public CheckOutServices(FastFoodDbContext db, UserManager<IdentityUser> manager)
        {
            _db = db;
            userManager = manager;
        }
        public bool CheckOut(CheckOutUserVM data)
        {
            var user = userManager.Users.FirstOrDefault(x => x.UserName == data.userName);
            if (user != null)
            {
                DatHang datHang = new DatHang()
                {
                    iDTaiKhoan = user.Id,
                    trangThai = 0,
                    thoiGian = DateTime.Now,
                    tongSo = data.lstData.Sum(x => x.quantity),
                    tongGia = data.lstData.Sum(x => x.giaBan)
                };
                _db.DatHangs.Add(datHang);
                _db.SaveChanges();
                foreach(var item in data.lstData)
                {
                    ChiTietDatHang x = new ChiTietDatHang()
                    {
                        ten = item.ten,
                        soLuong = item.quantity,
                        gia = item.giaBan,
                        hinh = item.hinh,
                        idDonHang = datHang.id,
                    };
                    _db.ChiTietDatHangs.Add(x);
                    _db.SaveChanges();
                }
                return true;
            }
            return false;
        }
        public IEnumerable<CheckOutxVM> GetAll()
        {
            var data = _db.DatHangs.Select(x => new CheckOutxVM()
            {
                id = x.id,
                thoiGian = x.thoiGian,
                tongSo = x.tongSo,
                tongGia = x.tongGia,
                trangThai = x.trangThai,
                ten = userManager.Users.FirstOrDefault(d => d.Id == x.iDTaiKhoan).UserName
            }).ToList();
            return data;
        }
        public IEnumerable<CheckOutVM> GetDetail(int id)
        {
            var result = _db.ChiTietDatHangs.Where(x => x.idDonHang == id).Select(x =>
                new CheckOutVM() { ten = x.ten, giaBan = x.gia, hinh = x.hinh, quantity = x.soLuong            
            }).ToList();
            return result;
        }
        public bool Delete(int id)
        {
            var item = _db.DatHangs.FirstOrDefault(x => x.id == id);
            try
            {
                _db.DatHangs.Remove(item);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public DatHang UpdateState(int id, int trangThai)
        {
            var item = _db.DatHangs.FirstOrDefault(x => x.id == id);
            if(item != null)
            {
                item.trangThai = trangThai; 
                _db.DatHangs.Update(item);
                _db.SaveChanges();
            }
            return item;
        }
    }
}
