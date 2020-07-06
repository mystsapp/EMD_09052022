using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMD.Data.Models;
using EMD.Data.Repository;
using EMD.Models;
using EMD.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace EMD.Controllers
{

    public class EMDCanTrusController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public EMDCanTruViewModel EMDCanTruVM { get; set; }
        public EMDCanTrusController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            EMDCanTruVM = new EMDCanTruViewModel()
            {
                EMDTbl = new Data.Models.EMDTbl(),
                EMDCanTru = new Data.Models.EMDCanTru(),
                StrUrl = ""
            };
        }

        // them emd can tru
        public async Task<IActionResult> EMDPlus(int emdOldId, string strUrl)
        {
            
            // emd cha
            var emd = await _unitOfWork.emdRepository.GetByIdAsync(emdOldId);
            if (emd == null)
            {
                return NotFound();
            }
            // kiem tra emd da can tru chua
            //var emdCanTrubyEMDOld = _unitOfWork.eMDCanTruRepository.Find(x => x.OldNumber == emd.Number);
            //if(emdCanTrubyEMDOld != null)
            //{
            //    if (emdCanTrubyEMDOld.Sum(x => x.STDatCoc) > emd.STDatCoc)
            //}
            
            // kiem tra emd da can tru chua

            EMDCanTruVM.EMDTbl = emd;
            EMDCanTruVM.StrUrl = strUrl;

            return View(EMDCanTruVM);
        }

        [HttpPost, ActionName("EMDPlus")]
        public async Task<IActionResult> EMDPlusPost(int emdOldId, string strUrl)
        {
            var user = HttpContext.Session.Gets<User>("loginUser").FirstOrDefault();

            // emd cha
            var oldEMD = await _unitOfWork.emdRepository.GetByIdAsync(emdOldId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // cap nhat log user tao
            EMDCanTruVM.EMDCanTru.UserNhap = user.Username;
            EMDCanTruVM.EMDCanTru.NgayNhap = DateTime.Now;
            EMDCanTruVM.EMDCanTru.TimThay = true;

            _unitOfWork.eMDCanTruRepository.Create(EMDCanTruVM.EMDCanTru);
            /////////////// cap nhat EMD  co can tru ///////////////////
            oldEMD.CanTru = true;
            _unitOfWork.emdRepository.Update(oldEMD);
            /////////////// cap nhat EMD  co can tru ///////////////////
            await _unitOfWork.Complete();
            SetAlert("Thêm mới thành công.", "success");

            return Redirect(strUrl);
        }

        public async Task<IActionResult> Update(int id, string strUrl)
        {
            var emdCanTru = await _unitOfWork.eMDCanTruRepository.GetByIdAsync(id);
            if (emdCanTru == null)
                return NotFound();

            EMDCanTruVM.EMDCanTru = emdCanTru;
            EMDCanTruVM.StrUrl = strUrl;
            //EMDCanTruVM.EMDTbl = _unitOfWork.emdRepository.Find(x => x.Number == emdCanTru.OldNumber).FirstOrDefault();

            return View(EMDCanTruVM);
        }

        [HttpPost, ActionName("Update")]
        public async Task<IActionResult> UpdatePost(int id, string strUrl)
        {
            var user = HttpContext.Session.Gets<User>("loginUser").FirstOrDefault();

            if (id != EMDCanTruVM.EMDCanTru.Id)
                return NotFound();

            EMDCanTruVM.EMDCanTru.UserSua = user.Username;
            EMDCanTruVM.EMDCanTru.NgaySua = DateTime.Now;

            if (!ModelState.IsValid)
                return View(EMDCanTruVM);

            _unitOfWork.eMDCanTruRepository.Update(EMDCanTruVM.EMDCanTru);
            await _unitOfWork.Complete();
            SetAlert("Cập nhật thành công.", "success");

            return Redirect(strUrl);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, string strUrl)
        {
            var user = HttpContext.Session.Gets<User>("loginUser").FirstOrDefault();
            var emdCanTru = await _unitOfWork.eMDCanTruRepository.GetByIdAsync(id);

            if (emdCanTru == null)
                return NotFound();
            // ẩn
            emdCanTru.TimThay = false;
            emdCanTru.UserXoa = user.Username;
            emdCanTru.NgayXoa = DateTime.Now;

            _unitOfWork.eMDCanTruRepository.Update(emdCanTru);
            await _unitOfWork.Complete();
            SetAlert("Xóa thành công.", "success");

            return Redirect(strUrl);
        }
        public IActionResult DetailsRedirect(string strUrl)
        {
            return Redirect(strUrl);
        }
    }
}