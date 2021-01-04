using EMD.Data.Interfaces;
using EMD.Data.Models_QLTaiKhoan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMD.Data.Repository
{
    public interface IApplicationUserQLTaiKhoanRepository : IRepository<ApplicationUser>
    {
        Task<ApplicationUser> GetByIdTwoKeyAsync(string username, string mct);
    }
    public class ApplicationUserQLTaiKhoanRepository : Repository_QLTaiKhoan<ApplicationUser>, IApplicationUserQLTaiKhoanRepository
    {
        public ApplicationUserQLTaiKhoanRepository(qltaikhoanContext context) : base(context)
        {
        }

        public async Task<ApplicationUser> GetByIdTwoKeyAsync(string username, string mct)
        {
            return await _context.ApplicationUser.FindAsync(username, mct);
        }
    }
}
