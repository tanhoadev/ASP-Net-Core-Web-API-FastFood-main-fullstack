namespace fastfood.ViewModels
{
    public class CheckOutxVM
    {
        public int id { get; set; }
        public string ten { get; set; }
        public int tongSo { get; set; }
        public decimal tongGia { get; set; }
        public int trangThai { get; set; }
        public DateTime thoiGian { get; set; }
    }
    public class CheckOutVM
    {
        public int maSP {  get; set; }
        public string ten { get; set; }
        public string hinh { get; set; }
        public int quantity { get; set; }
        public decimal giaBan { get; set; }
    }

    public class CheckOutUserVM
    {
        public List<CheckOutVM> lstData { get; set; }
        public string userName { get; set; }
    }
    public class DatHangVM
    {
        public int id { get; set; }
        public string ten { get; set; }
        public string hinh { get; set; }
        public int quantity { get; set; }
        public decimal giaBan { get; set; }
        public DateTime thoiGian { get; set; }
        public int trangThai { get; set; }
    }
}
