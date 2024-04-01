using fastfood.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace fastfood.Data
{
    public class FastFoodDbContext: IdentityDbContext<IdentityUser>
    {
        public FastFoodDbContext(DbContextOptions options): base(options) { }
        public DbSet<Loai> Loais {  get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<DatHang> DatHangs {  get; set; }
        public DbSet<ChiTietDatHang> ChiTietDatHangs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loai>(e =>
            {
                
            });
            modelBuilder.Entity<SanPham>(e =>
            {
                e.HasOne(x => x.Loai)
                    .WithMany(x => x.sanPhams)
                    .HasForeignKey(x => x.IdLoai);
            });
            modelBuilder.Entity<DatHang>(e =>
            {
                e.HasOne(x => x.taikhoan)
                    .WithMany(x => x.datHangs)
                    .HasForeignKey(x => x.iDTaiKhoan);
            });
            modelBuilder.Entity<ChiTietDatHang>(e =>
            {
                e.HasOne(x => x.DatHang)
                    .WithMany(x => x.chiTietDatHangs)
                    .HasForeignKey(x => x.idDonHang);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
