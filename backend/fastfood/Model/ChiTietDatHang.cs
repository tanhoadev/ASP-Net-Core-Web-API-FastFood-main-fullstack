namespace fastfood.Model
{
    public class ChiTietDatHang
    {
        public int id {  get; set; }
        public int idDonHang { get; set; }
        public string ten { get; set; }
        public int soLuong { get; set; }
        public decimal gia { get; set; }
        public string hinh { get; set; }
        public DatHang DatHang { get; set; }
    }
}
