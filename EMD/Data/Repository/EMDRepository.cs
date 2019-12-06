using Microsoft.EntityFrameworkCore;
using EMD.Data.Interfaces;
using EMD.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using EMD.Models;
using System.Data;
using EMD.Utilities;

namespace EMD.Data.Repository
{
    public interface IEMDRepository : IRepository<EMDTbl>
    {
        Task<SGTCodeModel> GetBySGTCode(string sgtCode);
        Task<IEnumerable<DienGiaiModel>> DienGiaiBySGTCode(string sgtCode);
        Task<IEnumerable<HangHK>> GetHangHKs();
        Task<IEnumerable<HoanVeModel>> GetHoanVes(string sgtCode);

        DataTable TheoNgayBay_Report(string tuNgay, string denNgay);
        DataTable TheoNgayDC_Report(string tuNgay, string denNgay);
        DataTable TheoNgayHetHan_Report(string tuNgay, string denNgay);
        DataTable TheoDoiTuongBK_NgayBay_Report(string tuNgay, string denNgay);

        DataTable TheoDoanChuaHoanCoc_Report(string tuNgay, string denNgay);
    }
    public class EMDRepository : Repository<EMDTbl>, IEMDRepository
    {
        public EMDRepository(EMDDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<DienGiaiModel>> DienGiaiBySGTCode(string sgtCode)
        {
            var result = await _context.DienGiaiModels.FromSqlRaw("EXECUTE dbo.spSearchCodeDoan_DienGiai {0}", sgtCode).ToListAsync();

            return result;
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

        public DataTable TheoNgayBay_Report(string tuNgay, string denNgay)
        {
            DateTime tu = Convert.ToDateTime(tuNgay);
            DateTime den = Convert.ToDateTime(denNgay);

            try
            {
                DataTable dt = new DataTable();
                var result = _context.EMDs.Where(x => x.BatDau >= tu && x.BatDau < den.AddDays(1)).Select(p => new
                {
                    p.Id,
                    p.SGTCode,
                    p.BatDau,
                    p.KetThuc,
                    p.SLVeDatCoc,
                    p.NgayDC,
                    p.HetHan,
                    p.Number,
                    p.STDatCoc,
                    p.LoaiBK,
                    p.SLVeDaXuat,
                    p.TienPhat,
                    p.PNR,
                    p.HoanCoc,
                    p.GhiChu
                });
                var count = result.Count();

                dt = EntityToTable.ToDataTable(result);
                if (dt.Rows.Count > 0)
                    return dt;
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }
        
        public DataTable TheoNgayDC_Report(string tuNgay, string denNgay)
        {
            DateTime tu = Convert.ToDateTime(tuNgay);
            DateTime den = Convert.ToDateTime(denNgay);

            try
            {
                DataTable dt = new DataTable();
                var result = _context.EMDs.Where(x => x.NgayDC >= tu && x.NgayDC < den.AddDays(1)).Select(p => new
                {
                    p.Id,
                    p.SGTCode,
                    p.BatDau,
                    p.KetThuc,
                    p.SLVeDatCoc,
                    p.NgayDC,
                    p.HetHan,
                    p.Number,
                    p.STDatCoc,
                    p.LoaiBK,
                    p.SLVeDaXuat,
                    p.TienPhat,
                    p.PNR,
                    p.HoanCoc,
                    p.GhiChu
                });
                var count = result.Count();

                dt = EntityToTable.ToDataTable(result);
                if (dt.Rows.Count > 0)
                    return dt;
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }
        
        public DataTable TheoNgayHetHan_Report(string tuNgay, string denNgay)
        {
            DateTime tu = Convert.ToDateTime(tuNgay);
            DateTime den = Convert.ToDateTime(denNgay);

            try
            {
                DataTable dt = new DataTable();
                var result = _context.EMDs.Where(x => x.HetHan >= tu && x.HetHan < den.AddDays(1)).Select(p => new
                {
                    p.Id,
                    p.SGTCode,
                    p.BatDau,
                    p.KetThuc,
                    p.SLVeDatCoc,
                    p.NgayDC,
                    p.HetHan,
                    p.Number,
                    p.STDatCoc,
                    p.LoaiBK,
                    p.SLVeDaXuat,
                    p.TienPhat,
                    p.PNR,
                    p.HoanCoc,
                    p.GhiChu
                });
                var count = result.Count();

                dt = EntityToTable.ToDataTable(result);
                if (dt.Rows.Count > 0)
                    return dt;
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        public DataTable TheoDoiTuongBK_NgayBay_Report(string tuNgay, string denNgay)
        {
            DateTime tu = Convert.ToDateTime(tuNgay);
            DateTime den = Convert.ToDateTime(denNgay);

            try
            {
                DataTable dt = new DataTable();
                var result = _context.EMDs.Where(x => x.BatDau >= tu && x.BatDau < den.AddDays(1) && string.IsNullOrEmpty(x.LoaiBK)).Select(p => new
                {
                    p.Id,
                    p.SGTCode,
                    p.BatDau,
                    p.KetThuc,
                    p.SLVeDatCoc,
                    p.NgayDC,
                    p.HetHan,
                    p.Number,
                    p.STDatCoc,
                    p.LoaiBK,
                    p.SLVeDaXuat,
                    p.TienPhat,
                    p.PNR,
                    p.HoanCoc,
                    p.GhiChu
                });
                var count = result.Count();

                dt = EntityToTable.ToDataTable(result);
                if (dt.Rows.Count > 0)
                    return dt;
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        public DataTable TheoDoanChuaHoanCoc_Report(string tuNgay, string denNgay)
        {
            DateTime tu = Convert.ToDateTime(tuNgay);
            DateTime den = Convert.ToDateTime(denNgay);

            try
            {
                DataTable dt = new DataTable();
                var result = _context.EMDs.Where(x => x.BatDau >= tu && x.BatDau < den && string.IsNullOrEmpty(x.HoanCoc.ToString())).Select(p => new
                {
                    p.Id,
                    p.SGTCode,
                    p.BatDau,
                    p.KetThuc,
                    p.SLVeDatCoc,
                    p.NgayDC,
                    p.HetHan,
                    p.Number,
                    p.STDatCoc,
                    p.LoaiBK,
                    p.SLVeDaXuat,
                    p.TienPhat,
                    p.PNR,
                    p.HoanCoc,
                    p.GhiChu
                });
                var count = result.Count();

                dt = EntityToTable.ToDataTable(result);
                if (dt.Rows.Count > 0)
                    return dt;
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<HangHK>> GetHangHKs()
        {
            var result = await _context.HangHKs.FromSqlRaw("SELECT * FROM dbo.V_HangHK").ToListAsync();

            return result;
        }
        
        public async Task<IEnumerable<HoanVeModel>> GetHoanVes(string sgtCode)
        {
            var result = await _context.HoanVeModels.FromSqlRaw("EXECUTE dbo.spHoanVe {0}", sgtCode).ToListAsync();

            return result;
        }
    }
}
