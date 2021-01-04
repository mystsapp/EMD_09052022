using EMD.Data.Models_QLTaiKhoan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMD.Data.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        // EMD
        IEMDRepository emdRepository { get; }

        IUserRepository userRepository { get; }
        IChiNhanhRepository chiNhanhRepository { get; }
        IDMDaiLyRepository dMDaiLyRepository { get; }
        IRoleRepository roleRepository { get; }
        IEMDCanTruRepository eMDCanTruRepository { get; }

        // qltaikhoan
        IUserQLTaiKhoanRepository userQLTaiKhoanRepository { get; }
        IApplicationUserQLTaiKhoanRepository applicationUserQLTaiKhoanRepository { get; }
        IApplicationQLTaiKhoanRepository applicationQLTaiKhoanRepository { get; }
        Task<int> Complete();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EMDDbContext _context;
        private readonly qltaikhoanContext _qltaikhoanContext;

        public UnitOfWork(EMDDbContext context, qltaikhoanContext qltaikhoanContext)
        {
            _context = context;
            _qltaikhoanContext = qltaikhoanContext;
            emdRepository = new EMDRepository(_context);
            userRepository = new UserRepository(_context);
            chiNhanhRepository = new ChiNhanhRepository(_context);
            dMDaiLyRepository = new DMDaiLyRepository(_context);
            roleRepository = new RoleRepository(_context);
            eMDCanTruRepository = new EMDCanTruRepository(_context);

            // qltaikhoan
            userQLTaiKhoanRepository = new UserQLTaiKhoanRepository(_qltaikhoanContext);
            applicationUserQLTaiKhoanRepository = new ApplicationUserQLTaiKhoanRepository(_qltaikhoanContext);
            applicationQLTaiKhoanRepository = new ApplicationQLTaiKhoanRepository(_qltaikhoanContext);

        }
        public IEMDRepository emdRepository { get; }

        public IUserRepository userRepository { get; }

        public IChiNhanhRepository chiNhanhRepository { get; }

        public IDMDaiLyRepository dMDaiLyRepository { get; }

        public IRoleRepository roleRepository { get; }

        public IEMDCanTruRepository eMDCanTruRepository { get; }

        // qltaikhoan
        public IUserQLTaiKhoanRepository userQLTaiKhoanRepository { get; }
        public IApplicationUserQLTaiKhoanRepository applicationUserQLTaiKhoanRepository { get; }

        public IApplicationQLTaiKhoanRepository applicationQLTaiKhoanRepository { get; }

        public async Task<int> Complete()
        {
            await _qltaikhoanContext.SaveChangesAsync();
            await _context.SaveChangesAsync();
            return 1;

        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
