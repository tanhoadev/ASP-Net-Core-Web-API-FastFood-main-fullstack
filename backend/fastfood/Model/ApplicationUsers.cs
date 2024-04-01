using Microsoft.AspNetCore.Identity;

namespace fastfood.Model
{
    public class ApplicationUsers: IdentityUser
    {
        public ICollection<DatHang> datHangs { get; set; }
    }
}
