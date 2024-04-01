namespace fastfood.Model
{
    public class SanPham
    {
        public int id { get; set; }
        public string TenSP { get; set; }
        public string HinhAnh { get; set; }
        public decimal Gia { get; set; }
        public int IdLoai { get; set; }
        public int HienThi { get; set; }
        public string MoTa { get; set; }
        public Loai Loai { get; set; }
    }
}
