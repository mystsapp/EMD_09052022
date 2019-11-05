using EMD.Data.Interfaces;
using EMD.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMD.Data.Repository
{
    public interface IChiNhanhRepository : IRepository<ChiNhanh>
    {

    }
    public class ChiNhanhRepository : Repository<ChiNhanh>, IChiNhanhRepository
    {
        public ChiNhanhRepository(EMDDbContext context) : base(context)
        {
        }
    }
}
