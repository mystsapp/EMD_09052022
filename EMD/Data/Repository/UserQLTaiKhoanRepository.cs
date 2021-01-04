using EMD.Data.Interfaces;
using EMD.Data.Models_QLTaiKhoan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMD.Data.Repository
{
    public interface IUserQLTaiKhoanRepository : IRepository<Users>
    {

    }
    public class UserQLTaiKhoanRepository : Repository_QLTaiKhoan<Users>, IUserQLTaiKhoanRepository
    {
        public UserQLTaiKhoanRepository(qltaikhoanContext context) : base(context)
        {
        }
    }
}
