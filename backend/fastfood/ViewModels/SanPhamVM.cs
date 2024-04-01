namespace fastfood.ViewModels
{
    public class SanPhamVM
    {
        public int id { get; set; }
        public string Ten { get; set; }
        public int GiaBan { get; set; }
        public string Hinh { get; set; }
        public int IdLoai { get; set; }
        public int HienThi { get; set; }
        public string MoTa { get; set; }
    }
    public class SanPhamVMDB
    {
        public int id { get; set; }
        public string Ten { get; set; }
        public decimal GiaBan { get; set; }
        public string Hinh { get; set; }
        public int IdLoai { get; set; }
        public string TenLoai { get; set; }
        public int HienThi { get; set; }
        public string MoTa { get; set; }
    }
    public class GetLoai { 
        public string TenLoai { get; set; }
        public int IdLoai { get; set;}
    }

}
