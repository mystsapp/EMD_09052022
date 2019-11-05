using EMD.Data.Interfaces;
using EMD.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMD.Data.Repository
{
    public interface IDMDaiLyRepository : IRepository<DMDaiLy>
    {
        Task<IEnumerable<DMDaiLy>> VanPhongIncludeChiNhanh();
        Task<DMDaiLy> FindIdIncludeChiNhanh(int? id);
    }
    public class DMDaiLyRepository : Repository<DMDaiLy>, IDMDaiLyRepository
    {
        public DMDaiLyRepository(EMDDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<DMDaiLy>> VanPhongIncludeChiNhanh()
        {

            return await _context.DMDaiLies.Include(x => x.ChiNhanh).ToListAsync();
        }

        public async Task<DMDaiLy> FindIdIncludeChiNhanh(int? id)
        {
            return await _context.DMDaiLies.Include(x => x.ChiNhanh).SingleAsync(x => x.Id == id);
        }
    }
}
