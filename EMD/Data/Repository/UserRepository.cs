using EMD.Data.Interfaces;
using EMD.Data.Models;
using EMD.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMD.Data.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<int> login(string username, string password);
        Task<User> FindIdIncludeChiNhanh(int? id);

        int changepass(string username, string password, string newpass, string confirmpass);
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

        public async Task<int> login(string username, string password)
        {
            //MaHoaSHA1 sha1 = new MaHoaSHA1();
            var result = await _context.Users.Where(x => x.Username == username).FirstOrDefaultAsync();
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.TinhTrang == false)
                {
                    return -1;
                }
                else
                {//sha1.EncodeSHA1
                    if (result.Password == MaHoaSHA1.EncodeSHA1(password))
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }
        }

        public int changepass(string username, string password, string newpass, string confirmpass)
        {
            try
            {
                var result = _context.Users.Where(x => x.Username == username).FirstOrDefault();
                if (string.IsNullOrEmpty(password))
                {
                    return -1;
                }
                if (result.Password != MaHoaSHA1.EncodeSHA1(password))
                {
                    return -2;
                }
                if (string.IsNullOrEmpty(newpass))
                {
                    return -3;
                }
                if (string.IsNullOrEmpty(confirmpass))
                {
                    return -4;
                }
                if (confirmpass != newpass)
                {
                    return -5;
                }
                else
                {
                    result.Password = MaHoaSHA1.EncodeSHA1(newpass);
                    result.Doimk = false;
                    result.Ngaydoimk = DateTime.Now;
                    _context.SaveChanges();
                    return 1;
                }
            }
            catch { return -6; }
        }
    }
}
