using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMD.Data.Models;
using EMD.Data.Repository;
using EMD.Models;
using EMD.Utilities;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;

namespace EMD.Controllers
{
    public class EMDsController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public EMDViewModel EMDViewModel { get; set; }

        public EMDsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            EMDViewModel = new EMDViewModel()
            {
                EMDTbl = new Data.Models.EMDTbl()

            };
        }
        public IActionResult Index(int id = 0, string searchString = null, string searchDate = null, int page = 1)
        {
            EMDViewModel.StrUrl = UriHelper.GetDisplayUrl(Request);
            ViewBag.searchString = searchString;
            ViewBag.searchDate = searchDate;

            // for delete or emd click
            if (id != 0)
            {

                var emd = _unitOfWork.emdRepository.GetById(id);
                if (emd == null)
                {

                    var lastId = _unitOfWork.emdRepository
                                              .GetAll().OrderByDescending(x => x.Id)
                                              .FirstOrDefault().Id;
                    id = lastId;

                }
                else
                {
                    //////////////// DS EMD can tru  theo EmD /////////////////
                    EMDViewModel.EMDTbl = emd; // after row click
                    EMDViewModel.EMDCanTrus = _unitOfWork.eMDCanTruRepository.Find(x => x.OldNumber == emd.Number && x.TimThay.Value); // theo emd cu va timthay == true
                    //var abc = _unitOfWork.eMDCanTruRepository.GetAll();
                    //if (EMDViewModel.EMDCanTrus.Count() == 0)
                    //{
                    //    EMDViewModel.EMDCanTrus = null;
                    //}
                    //////////////// DS EMD can tru  theo EmD /////////////////
                }

            }

            EMDViewModel.EMDTbls = _unitOfWork.emdRepository.ListEMD(searchString, searchDate, page);

            // emd click
            //if(id != 0)
            //{
            //    EMDViewModel.EMDTbl = _unitOfWork.emdRepository.GetById(id);
            //}
            // emd click

            return View(EMDViewModel);
        }

        public async Task<IActionResult> Create(string strUrl)
        {

            EMDViewModel.HangHKs = await _unitOfWork.emdRepository.GetHangHKs();
            EMDViewModel.EMDTbl.NgayDC = DateTime.Parse(DateTime.Now.ToShortDateString());
            EMDViewModel.EMDTbl.HetHan = Convert.ToDateTime(EMDViewModel.EMDTbl.NgayDC).AddMonths(9).AddDays(25);
            return View(EMDViewModel);
        }

        // Post: Create Method
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePOST(string strUrl)
        {
            var user = HttpContext.Session.Gets<User>("loginUser").FirstOrDefault();
            if (!ModelState.IsValid)
            {
                return View(EMDViewModel);
            }

            EMDViewModel.EMDTbl.Create = DateTime.Now;
            EMDViewModel.EMDTbl.NguoiNhap = user.Name;
            EMDViewModel.EMDTbl.SGTCode = EMDViewModel.EMDTbl.SGTCode.ToUpper();
            EMDViewModel.EMDTbl.Number = EMDViewModel.Number;
            EMDViewModel.EMDTbl.Xoa = false;
            EMDViewModel.EMDTbl.CanTru = false;
            EMDViewModel.EMDTbl.DaHoanCoc = false;

            string hangHK = EMDViewModel.EMDTbl.HangHK;
            if (!string.IsNullOrEmpty(hangHK))
                EMDViewModel.EMDTbl.HangHK = EMDViewModel.EMDTbl.HangHK.ToUpper();

            try
            {
                // ghi log
                EMDViewModel.EMDTbl.LogFile = EMDViewModel.EMDTbl.LogFile + "-User tạo: " + user.Username + " vào lúc: " + System.DateTime.Now.ToString();

                _unitOfWork.emdRepository.Create(EMDViewModel.EMDTbl);
                await _unitOfWork.Complete();
                SetAlert("Thêm mới thành công.", "success");
                return Redirect(strUrl);
            }
            catch (Exception ex)
            {
                return View(nameof(Create), new { strUrl = strUrl });
            }

        }

        public async Task<IActionResult> GetBySGTCode(string sgtCode)
        {
            var ds = await _unitOfWork.emdRepository.GetBySGTCode(sgtCode);
            if (ds != null)
            {
                var data = ds.sgtcode + "#" + ds.batdau.ToString("dd/MM/yyyy") + "#" + ds.ketthuc.ToString("dd/MM/yyyy") + "#" + ds.diemtq + "#" + ds.tuyentq + "#" + ds.sokhach.ToString("N0");
                return Json(new
                {
                    status = true,
                    data = data
                });
            }
            else
                return Content("");

        }

        public async Task<IActionResult> DienGiaiBySGTCode(string sgtCode, string number1, int soKhach = 0)
        {
            // STSTOB-2017-02306
            // STSTOB-2019-00003

            // ctbanve
            var dsDienGiai = await _unitOfWork.emdRepository.DienGiaiBySGTCode(sgtCode);

            // tourle
            var ds = await _unitOfWork.emdRepository.GetBySGTCode(sgtCode);

            // cthoanve
            var hoanves = await _unitOfWork.emdRepository.GetHoanVes(sgtCode);

            // chi lay nhung ve hoan co emd = emd truyen vao
            hoanves = hoanves.Where(x => x.number == number1);

            // list emd nhung ve hoan
            //var numList = new List<string>();

            var dienGiaiVM = new DienGiaiViewModel();

            if (ds != null)
            {
                if (soKhach == 0)
                {
                    dienGiaiVM.Tour = ds.tuyentq + " " + ds.batdau.ToString("dd/MM/yyyy") + "-" + ds.ketthuc.ToString("dd/MM/yyyy") + " * " + ds.sokhach + "pax"; // ** ///

                }
                else
                {
                    dienGiaiVM.Tour = ds.tuyentq + " " + ds.batdau.ToString("dd/MM/yyyy") + "-" + ds.ketthuc.ToString("dd/MM/yyyy") + " * " + soKhach + "pax"; // ** ///

                }
            }
            else
            {
                dienGiaiVM.Tour = "";
            }

            dienGiaiVM.CacVeTuCTHK = "Các vé đã xuất bên CTHK: \n";
            dienGiaiVM.SLVeDaXuat = "Số lượng vé đã xuất: ";
            dienGiaiVM.SoTienDaXuat = "Số tiền đã xuất: ";
            dienGiaiVM.NguoiNhap = dsDienGiai.Count() == 0 ? "" : dsDienGiai.FirstOrDefault().nguoinhap;

            if (dsDienGiai.Count() != 0)
            {
                string cacVe = "";
                int slVe = 0;
                decimal soTien = 0;


                foreach (var item in dsDienGiai)
                {

                    int lastItem = dsDienGiai.ToList().IndexOf(item);
                    if (lastItem != dsDienGiai.Count() - 1)
                    {
                        // this is the last item
                        cacVe += item.number.ToString() + " - " + item.nguoicapnhat + " - " + item.slve.ToString() + " vé" + "\n";
                    }
                    else
                    {
                        cacVe += item.number.ToString() + " - " + item.nguoicapnhat + " - " + item.slve.ToString() + " vé";
                    }
                    slVe += item.slve;
                    soTien += item.giave + item.lephi + item.thuesb + item.thuevat + item.phidv;


                }

                dienGiaiVM.CacVeTuCTHK += cacVe.ToString();
                dienGiaiVM.SLVeDaXuat += slVe.ToString();
                dienGiaiVM.SoTienDaXuat += soTien.ToString("N0");
                dienGiaiVM.TienXuatVe = soTien;

                //var stringName = dienGiaiVM.Tour + dienGiaiVM.CacVeTuCTHK + dienGiaiVM.SLVeDaXuat + dienGiaiVM.SoTienDaXuat;

            }


            if (hoanves.Count() != 0)
            {
                string cacVeHoan = "";
                int slVeHoan = 0;
                string thanhToan = "";
                string phiHoan = "";
                string thucTra = "";
                //string thucTraNum;


                foreach (var item in hoanves)
                {
                    // numList.Add(item.number);

                    int lastItem = hoanves.ToList().IndexOf(item);
                    if (lastItem != hoanves.Count() - 1)
                    {
                        // this is the last item
                        cacVeHoan += item.number.ToString() + " - " + item.nguoicapnhat + " - " + item.slve.ToString() + " vé" + "\n";
                    }
                    else
                    {
                        cacVeHoan += item.number.ToString() + " - " + item.nguoicapnhat + " - " + item.slve.ToString() + " vé" + "\n";
                    }
                    slVeHoan += item.slve;
                    thanhToan += (item.giave + item.thuesb + item.lephi + item.thuevat + item.phidv).ToString("N0") + "\n";
                    phiHoan += item.phihoan.ToString("N0") + "\n";
                    thucTra += (decimal.Parse(thanhToan) - decimal.Parse(phiHoan)).ToString("N0") + "\n";
                    dienGiaiVM.ThucTraNum = (decimal.Parse(thanhToan) - decimal.Parse(phiHoan)).ToString("N0");
                }

                dienGiaiVM.CacVeHoanBenCTHK = "\n Các vé hoàn bên CTHK: \n" + cacVeHoan.ToString();
                dienGiaiVM.TongThanhToan = "Thanh Toán: " + thanhToan;
                dienGiaiVM.PhiHoan = "Phí Hoàn: " + phiHoan;
                dienGiaiVM.ThucTra = "Thực Trả: " + thucTra;
                dienGiaiVM.SLVeHoan = slVeHoan;


                //foreach(var num in numList)
                //{
                //    if (num.Equals(number1))
                //    {
                //        dienGiaiVM.Number2 = number1;
                //    }
                //}

            }
            if (hoanves.Count() == 0)
            {
                dienGiaiVM.CacVeHoanBenCTHK = "";
                dienGiaiVM.TongThanhToan = "";
                dienGiaiVM.PhiHoan = "";
                dienGiaiVM.ThucTra = "";
            }

            if (string.IsNullOrEmpty(dienGiaiVM.Number2))
            {
                dienGiaiVM.Number2 = "";
            }

            return Json(new
            {
                status = true,
                data = dienGiaiVM
            });
        }

        //public async Task<IActionResult> DienGiaiBySGTCode(string sgtCode)
        //{
        //    var ds = await _unitOfWork.emdRepository.DienGiaiBySGTCode(sgtCode);
        //    if (ds != null)
        //    {
        //        return Json(new
        //        {
        //            status = true,
        //            data = ds
        //        });
        //    }
        //    else
        //        return Content("");
        //}

        // Get: Edit method
        public async Task<IActionResult> Edit(int? id, string strUrl)
        {
            if (id == null)
                return NotFound();

            EMDViewModel.EMDTbl = await _unitOfWork.emdRepository.GetByIdAsync(id);

            EMDViewModel.HangHKs = await _unitOfWork.emdRepository.GetHangHKs();
            EMDViewModel.EMDTbl.NgayDC = DateTime.Parse(DateTime.Now.ToShortDateString());

            if (EMDViewModel.EMDTbl == null)
                return NotFound();

            EMDViewModel.StrUrl = strUrl;
            return View(EMDViewModel);
        }

        // Post: Eidt method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string strUrl)
        {
            var user = HttpContext.Session.Gets<User>("loginUser").FirstOrDefault();
            if (id != EMDViewModel.EMDTbl.Id)
                return NotFound();

            EMDViewModel.EMDTbl.NgaySua = DateTime.Now;
            EMDViewModel.EMDTbl.NguoiSua = user.Name;
            //EMDViewModel.EMDTbl.Tracking = "Not";
            EMDViewModel.EMDTbl.Xoa = false;

            //if (!ModelState.IsValid)
            //{
            //    EMDViewModel.HangHKs = await _unitOfWork.emdRepository.GetHangHKs();
            //    return View(EMDViewModel);
            //}

            // ghi log
            EMDViewModel.EMDTbl.LogFile = EMDViewModel.EMDTbl.LogFile + "-User cập nhật: " + user.Username + " vào lúc: " + System.DateTime.Now.ToString();

            _unitOfWork.emdRepository.Update(EMDViewModel.EMDTbl);
            await _unitOfWork.Complete();

            SetAlert("Cập nhật thành công", "success");
            return Redirect(strUrl);


        }


        // Get: Details method
        public async Task<IActionResult> Details(int? id, string strUrl)
        {
            if (id == null)
                return NotFound();

            EMDViewModel.EMDTbl = await _unitOfWork.emdRepository.GetByIdAsync(id);

            if (EMDViewModel.EMDTbl == null)
                return NotFound();

            EMDViewModel.StrUrl = strUrl;
            return View(EMDViewModel);
        }

        // Get: Details method
        public async Task<IActionResult> DetailById(int? id)
        {
            if (id == null)
                return NotFound();

            EMDViewModel.EMDTbl = await _unitOfWork.emdRepository.GetByIdAsync(id);

            if (EMDViewModel.EMDTbl == null)
                return NotFound();

            return View(EMDViewModel);
        }

        //// Get: Delete method
        //public async Task<IActionResult> Delete(int? id, string strUrl)
        //{
        //    if (id == null)
        //        return NotFound();

        //    EMDViewModel.EMDTbl = await _unitOfWork.emdRepository.GetByIdAsync(id);

        //    if (EMDViewModel.EMDTbl == null)
        //        return NotFound();

        //    return View(EMDViewModel);
        //}

        // Post: Delete method
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id, string strUrl)
        {
            var user = HttpContext.Session.Gets<User>("loginUser").FirstOrDefault();
            var emd = await _unitOfWork.emdRepository.GetByIdAsync(id);

            if (emd == null)
                return NotFound();
            else
            {
                // ghi log
                emd.LogFile = emd.LogFile + System.Environment.NewLine + "===================" + System.Environment.NewLine + "-User: " + user.Username + " xoá EMD: " + emd.Number + " vào lúc: " + System.DateTime.Now.ToString();
                emd.Xoa = true;
                _unitOfWork.emdRepository.Update(emd);
                await _unitOfWork.Complete();
                SetAlert("Xóa thành công.", "success");
                return Redirect(strUrl);
            }
        }

        public JsonResult GetNgayHetHan(string ngayDc)
        {
            var ngayHetHan = Convert.ToDateTime(ngayDc).AddMonths(9).AddDays(25).ToShortDateString();
            return Json(new
            {
                status = true,
                data = ngayHetHan
            });
        }

        public JsonResult IsStringNameAvailable(string Number)
        {
            var boolName = _unitOfWork.emdRepository.Find(x => x.Number.Trim().ToLower() == Number.Trim().ToLower()).FirstOrDefault();
            if (boolName == null)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
    }
}