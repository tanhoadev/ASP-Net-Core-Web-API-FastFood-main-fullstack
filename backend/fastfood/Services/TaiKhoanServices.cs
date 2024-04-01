using fastfood.Model;
using fastfood.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace fastfood.Services
{
    public class TaiKhoanServices
    {
        private readonly UserManager<IdentityUser> _userManager;
        public TaiKhoanServices(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public IEnumerable<TaiKhoanVm> GetAll()
        {
            var lst = _userManager.Users.ToList().Select(x => new TaiKhoanVm()
            {
                id = x.Id,
                email = x.Email,
                userName = x.UserName,
                password = x.PasswordHash
            });
            return lst;
        }
        public async Task<bool> Delete(string id)
        {
            var ob = _userManager.Users.FirstOrDefault(x => x.Id == id);
            try
            {
                await _userManager.DeleteAsync(ob);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
