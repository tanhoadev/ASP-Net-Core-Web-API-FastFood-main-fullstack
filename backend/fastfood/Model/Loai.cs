namespace fastfood.Model
{
    public class Loai
    {
        public int id {  get; set; }
        public string TenLoai { get; set; }
        public string HinhAnh { get; set; }
        public ICollection<SanPham> sanPhams { get; set; }
    }
}
