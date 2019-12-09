using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMD.Data.Repository;
using EMD.Models;
using Microsoft.AspNetCore.Mvc;
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
                EMDTbls = _unitOfWork.emdRepository.GetAll(),
                EMDTbl = new Data.Models.EMDTbl()
                
            };
        }
        public IActionResult Index()
        {

            return View(EMDViewModel);
        }

        public async Task<IActionResult> Create()
        {

            EMDViewModel.HangHKs = await _unitOfWork.emdRepository.GetHangHKs();
            EMDViewModel.EMDTbl.NgayDC = DateTime.Parse(DateTime.Now.ToShortDateString());
            EMDViewModel.EMDTbl.HetHan = Convert.ToDateTime(EMDViewModel.EMDTbl.NgayDC).AddMonths(9).AddDays(25);
            return View(EMDViewModel);
        }

        // Post: Create Method
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePOST()
        {
            if (!ModelState.IsValid)
            {
                return View(EMDViewModel);
            }

            EMDViewModel.EMDTbl.Create = DateTime.Now;
            EMDViewModel.EMDTbl.SGTCode = EMDViewModel.EMDTbl.SGTCode.ToUpper();

            string hangHK = EMDViewModel.EMDTbl.HangHK;
            if (!string.IsNullOrEmpty(hangHK))
                EMDViewModel.EMDTbl.HangHK = EMDViewModel.EMDTbl.HangHK.ToUpper();

            _unitOfWork.emdRepository.Create(EMDViewModel.EMDTbl);
            await _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
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

        public async Task<IActionResult> DienGiaiBySGTCode(string sgtCode, string number1)
        {
            var dsDienGiai = await _unitOfWork.emdRepository.DienGiaiBySGTCode(sgtCode);
            var ds = await _unitOfWork.emdRepository.GetBySGTCode(sgtCode);

            var hoanves = await _unitOfWork.emdRepository.GetHoanVes(sgtCode);

            var numList = new List<string>();

            var dienGiaiVM = new DienGiaiViewModel()
            {
                Tour = ds.tuyentq + " " + ds.batdau.ToString("dd/MM/yyyy") + "-" + ds.ketthuc.ToString("dd/MM/yyyy") + " * " + ds.sokhach + "pax",
                CacVeTuCTHK = "Các vé đã xuất bên CTHK: \n",
                SLVeDaXuat = "Số lượng vé đã xuất: ",
                SoTienDaXuat = "Số tiền đã xuất: ",

                NguoiNhap = dsDienGiai.FirstOrDefault().nguoinhap

                
            };

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


            if(hoanves.Count() != 0)
            {
                string cacVeHoan = "";
                int slVeHoan = 0;
                string thanhToan = "";
                string phiHoan = "";
                string thucTra = "";
                string thucTraNum;
                

                foreach(var item in hoanves)
                {
                    numList.Add(item.number);

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
                dienGiaiVM.ThucTra = "Thực Trả: " +thucTra;
                dienGiaiVM.SLVeHoan = slVeHoan;
                

                foreach(var num in numList)
                {
                    if (num.Equals(number1))
                    {
                        dienGiaiVM.Number2 = number1;
                    }
                }
                
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
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            EMDViewModel.EMDTbl = await _unitOfWork.emdRepository.GetByIdAsync(id);

            EMDViewModel.HangHKs = await _unitOfWork.emdRepository.GetHangHKs();
            EMDViewModel.EMDTbl.NgayDC = DateTime.Parse(DateTime.Now.ToShortDateString());

            if (EMDViewModel.EMDTbl == null)
                return NotFound();

            return View(EMDViewModel);
        }

        // Post: Eidt method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)
        {
            if (id != EMDViewModel.EMDTbl.Id)
                return NotFound();

            if (ModelState.IsValid)
            {

                EMDViewModel.EMDTbl.NgaySua = DateTime.Now;

                _unitOfWork.emdRepository.Update(EMDViewModel.EMDTbl);
                await _unitOfWork.Complete();

                return RedirectToAction(nameof(Index));
            }

            return View(EMDViewModel);
        }

        // Get: Details method
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            EMDViewModel.EMDTbl = await _unitOfWork.emdRepository.GetByIdAsync(id);

            if (EMDViewModel.EMDTbl == null)
                return NotFound();

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

        // Get: Delete method
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            EMDViewModel.EMDTbl = await _unitOfWork.emdRepository.GetByIdAsync(id);

            if (EMDViewModel.EMDTbl == null)
                return NotFound();

            return View(EMDViewModel);
        }

        // Post: Delete method
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var emd = await _unitOfWork.emdRepository.GetByIdAsync(id);

            if (emd == null)
                return NotFound();
            else
            {
                _unitOfWork.emdRepository.Delete(emd);
                await _unitOfWork.Complete();

                return RedirectToAction(nameof(Index));
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
    }
}