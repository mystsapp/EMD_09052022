using EMD.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMD.Data
{
    public class EMDDbContext: DbContext
    {
        public EMDDbContext(DbContextOptions<EMDDbContext> options): base(options)
        {

        }
        public DbSet<EMDTbl> EMDs { get; set; }
        public DbSet<SGTCodeModel> SGTCodeModels { get; set; }
    }
}
