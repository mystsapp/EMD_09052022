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
using X.PagedList;

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
        IPagedList<EMDTbl> ListEMD(string searchString,string searchDate, int? page);
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

            //var sgtcodeArray = sgtCode.Split('-');
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

        public IPagedList<EMDTbl> ListEMD(string searchString,string searchDate, int? page)
        {
            // return a 404 if user browses to before the first page
            if (page.HasValue && page < 1)
                return null;

            // retrieve list from database/whereverand

            var list = GetAll().Where(x => x.Xoa == false).AsQueryable();
            
            if (!string.IsNullOrEmpty(searchString))
            {
                list = list.Where(x => x.Number.ToLower().Contains(searchString.ToLower()) ||
                                       x.SGTCode.ToLower().Contains(searchString.ToLower()) ||
                                       x.SoCTPhat.ToLower().Contains(searchString.ToLower())||
                                       x.NguoiNhap.ToLower().Contains(searchString.ToLower())||
                                       x.HangHK.ToLower().Contains(searchString.ToLower()));
            }

            var count = list.Count();

            
            if (!string.IsNullOrEmpty(searchDate))
            {
                DateTime bgDate = Convert.ToDateTime(searchDate);
                list = list.Where(x => x.NgayDC.Value.ToShortDateString().Equals(bgDate.ToShortDateString()));
            }

            // page the list
            const int pageSize = 10;
            decimal aa = (decimal)list.Count() / (decimal)pageSize;
            var bb = Math.Ceiling(aa);
            if (page > bb)
            {
                page--;
            }
            page = (page == 0) ? 1 : page;
            var listPaged = list.OrderByDescending(x => x.NgayDC).ToPagedList(page ?? 1, pageSize);
            //if (page > listPaged.PageCount)
            //    page--;
            // return a 404 if user browses to pages beyond last page. special case first page if no items exist
            if (listPaged.PageNumber != 1 && page.HasValue && page > listPaged.PageCount)
                return null;


            return listPaged;
        }
    }
}
