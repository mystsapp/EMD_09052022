using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMD.Data.Repository;
using EMD.Models;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Create()
        {
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

        public async Task<IActionResult> DienGiaiBySGTCode(string sgtCode)
        {
            var dsDienGiai = await _unitOfWork.emdRepository.DienGiaiBySGTCode(sgtCode);
            var ds = await _unitOfWork.emdRepository.GetBySGTCode(sgtCode);

            var dienGiaiVM = new DienGiaiViewModel()
            {
                Tour = ds.tuyentq + " " + ds.batdau.ToString("dd/MM/yyyy") + "-" + ds.ketthuc.ToString("dd/MM/yyyy") + " * " + ds.sokhach + "pax",
                CacVeTuCTHK = "Các vé đã xuất bên CTHK: \n",
                SLVeDaXuat = "Số lượng vé đã xuất: ",
                SoTienDaXuat = "Số tiền đã xuất: "
            };

            if (dsDienGiai != null)
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
                      cacVe += item.number.ToString() + "-" + item.nguoicapnhat + "\n";
                    }
                    else
                    {
                        cacVe += item.number.ToString() + "-" + item.nguoicapnhat;
                    }
                    slVe += item.slve;
                    soTien += item.giave + item.lephi + item.thuesb + item.thuevat + item.phidv;
                }

                dienGiaiVM.CacVeTuCTHK += cacVe.ToString();
                dienGiaiVM.SLVeDaXuat += slVe.ToString();
                dienGiaiVM.SoTienDaXuat += soTien.ToString("N0");

                //var stringName = dienGiaiVM.Tour + dienGiaiVM.CacVeTuCTHK + dienGiaiVM.SLVeDaXuat + dienGiaiVM.SoTienDaXuat;
                return Json(new
                {
                    status = true,
                    data = dienGiaiVM
                });
            }
            else
                return Content("");
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
        public async Task<IActionResult> DetailById(int id)
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
    }
}