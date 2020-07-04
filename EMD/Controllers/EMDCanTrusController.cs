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
        public async Task<IActionResult> EMDPlus(int emdOldId, string strUrl)
        {
            var emd = await _unitOfWork.emdRepository.GetByIdAsync(emdOldId);
            if (emd == null)
            {
                return NotFound();
            }
            EMDCanTruVM.EMDTbl = emd;
            EMDCanTruVM.StrUrl = strUrl;

            return View(EMDCanTruVM);
        }
        
        [HttpPost, ActionName("EMDPlus")]
        public async Task<IActionResult> EMDPlusPost(string strUrl)
        {
            var user = HttpContext.Session.Gets<User>("loginUser").FirstOrDefault();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            EMDCanTruVM.EMDCanTru.UserNhap = user.Username;
            EMDCanTruVM.EMDCanTru.NgayNhap = DateTime.Now;

            _unitOfWork.eMDCanTruRepository.Create(EMDCanTruVM.EMDCanTru);
            await _unitOfWork.Complete();
            SetAlert("Thêm mới thành công.", "success");

            return Redirect(strUrl);
        }

        public IActionResult DetailsRedirect(string strUrl)
        {
            return Redirect(strUrl);
        }
    }
}