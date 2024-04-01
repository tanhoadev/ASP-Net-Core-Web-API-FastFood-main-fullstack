namespace fastfood.Model
{
    public class DatHang
    {
        public int id {  get; set; }
        public string iDTaiKhoan { get; set; }
        public int tongSo {  get; set; }
        public decimal tongGia { get; set; }
        public int trangThai { get; set; }
        public DateTime thoiGian { get; set; }
        public ApplicationUsers taikhoan { get; set; }
        public ICollection<ChiTietDatHang> chiTietDatHangs { get; set; }
    }
}
