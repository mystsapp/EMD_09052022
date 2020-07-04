using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMD.Data.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IEMDRepository emdRepository { get; }

        IUserRepository userRepository { get; }
        IChiNhanhRepository chiNhanhRepository { get; }
        IDMDaiLyRepository dMDaiLyRepository { get; }
        IRoleRepository roleRepository { get; }
        IEMDCanTruRepository eMDCanTruRepository { get; }
        Task<int> Complete();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EMDDbContext _context;

        public UnitOfWork(EMDDbContext context)
        {
            _context = context;
            emdRepository = new EMDRepository(_context);
            userRepository = new UserRepository(_context);
            chiNhanhRepository = new ChiNhanhRepository(_context);
            dMDaiLyRepository = new DMDaiLyRepository(_context);
            roleRepository = new RoleRepository(_context);
            eMDCanTruRepository = new EMDCanTruRepository(_context);

        }
        public IEMDRepository emdRepository { get; }

        public IUserRepository userRepository { get; }

        public IChiNhanhRepository chiNhanhRepository { get; }

        public IDMDaiLyRepository dMDaiLyRepository { get; }

        public IRoleRepository roleRepository { get; }

        public IEMDCanTruRepository eMDCanTruRepository { get; }

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
