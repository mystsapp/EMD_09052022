using Microsoft.EntityFrameworkCore;
using EMD.Data.Interfaces;
using EMD.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using EMD.Models;

namespace EMD.Data.Repository
{
    public interface IEMDRepository : IRepository<EMDTbl>
    {
        Task<SGTCodeModel> GetBySGTCode(string sgtCode);
    }
    public class EMDRepository : Repository<EMDTbl>, IEMDRepository
    {
        public EMDRepository(EMDDbContext context) : base(context)
        {
        }

        public async Task<SGTCodeModel> GetBySGTCode(string sgtCode)
        {
            //var parameters = new SqlParameter[]
            //{
            //    new SqlParameter("@sgtcode", DateTime.Parse(sgtCode))
            //};
            var result = await _context.SGTCodeModels.FromSqlRaw("EXECUTE dbo.spSearchCodeDoan {0}", sgtCode).ToListAsync();

            return result.SingleOrDefault();
        }
    }
}
