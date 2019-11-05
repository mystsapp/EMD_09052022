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
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ChiNhanh> ChiNhanhs { get; set; }
        public DbSet<DMDaiLy> DMDaiLies { get; set; }
    }
}
