using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMD.Data.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IEMDRepository emdRepository { get; }

        Task<int> Complete();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EMDDbContext _context;

        public UnitOfWork(EMDDbContext context)
        {
            _context = context;
            emdRepository = new EMDRepository(_context);

        }
        public IEMDRepository emdRepository { get; }



        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();

        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
