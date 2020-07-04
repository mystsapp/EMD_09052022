using EMD.Data.Interfaces;
using EMD.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMD.Data.Repository
{
    public interface IEMDCanTruRepository : IRepository<EMDCanTru>
    {

    }
    public class EMDCanTruRepository : Repository<EMDCanTru>, IEMDCanTruRepository
    {
        public EMDCanTruRepository(EMDDbContext context) : base(context)
        {
        }
    }
}
