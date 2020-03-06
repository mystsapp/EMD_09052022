using EMD.Data.Interfaces;
using EMD.Data.Models;
using EMD.Models;
using EMD.Utilities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMD.Data.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        //Task<int> login(string username, string password);
        Task<User> FindIdIncludeChiNhanh(int? id);
        LoginViewModel Login(string username, string mact);

        int Changepass(string username, string newpass);
    }
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(EMDDbContext context) : base(context)
        {
        }

        public async Task<User> FindIdIncludeChiNhanh(int? id)
        {
            return await _context.Users.Include(x => x.ChiNhanh).SingleAsync(x => x.Id == id);
        }

        //public async Task<int> login(string username, string password)
        //{
        //    //MaHoaSHA1 sha1 = new MaHoaSHA1();
        //    var result = await _context.Users.Where(x => x.Username == username).FirstOrDefaultAsync();
        //    if (result == null)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        if (result.TrangThai == false)
        //        {
        //            return -1;
        //        }
        //        else
        //        {//sha1.EncodeSHA1
        //            if (result.Password == MaHoaSHA1.EncodeSHA1(password))
        //            {'Data is Null. This method or property cannot be called on Null values.'

        //                return 1;
        //            }
        //            else
        //            {
        //                return -2;
        //            }
        //        }
        //    }
        //}

        public LoginViewModel Login(string username, string mact)
        {
            var parammeter = new SqlParameter[]
           {
                new SqlParameter("@username",username),
                new SqlParameter("@mact",mact)
           };

            var result = _context.LoginViewModels.FromSqlRaw("dbo.spLogin @username, @mact", parammeter).ToList();
            
            if (result == null)
            {
                return null;
            }
            else
            {
                return result.SingleOrDefault();
            }
        }

        public int Changepass(string username, string newpass)
        {
            try
            {
                var result = Find(x => x.Username == username).FirstOrDefault();
                
                result.Password = newpass;
                result.Doimk = false;
                result.Ngaydoimk = DateTime.Now;
                _context.SaveChanges();
                return 1;
            }
            catch { throw; }
        }
    }
}
