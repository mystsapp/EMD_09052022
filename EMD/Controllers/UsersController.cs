using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMD.Data.Models;
using EMD.Data.Repository;
using EMD.Models;
using EMD.Utilities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EMD.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public UserViewModel UserVM { get; set; }
        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            UserVM = new UserViewModel()
            {
                ChiNhanhs = _unitOfWork.chiNhanhRepository.GetAll(),
                User = new Data.Models.User(),
                DMDaiLies = _unitOfWork.dMDaiLyRepository.GetAll(),
                Roles = _unitOfWork.roleRepository.GetAll()
            };
        }
        public async Task<IActionResult> Index()
        {
            var users = _unitOfWork.userRepository.GetAllIncludeAsync(x => x.ChiNhanh, y => y.Role);
            return View(await users);
        }

        // Get Create method
        public IActionResult Create()
        {

            return View(UserVM);
        }

        // Post: Create Method
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePOST()
        {
            if (!ModelState.IsValid)
            {
                return View(UserVM);
            }

            UserVM.User.Password = MaHoaSHA1.EncodeSHA1(UserVM.User.Password);
            UserVM.User.Username = UserVM.UsernameCreate;

            _unitOfWork.userRepository.Create(UserVM.User);
            await _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }

        // Get: Edit method
        public async Task<IActionResult> Edit(int? id)
        {
            UserEditViewModel userEditVM = new UserEditViewModel()
            {
                ChiNhanhs = _unitOfWork.chiNhanhRepository.GetAll(),
                User = new Data.Models.User(),
                DMDaiLies = _unitOfWork.dMDaiLyRepository.GetAll(),
                Roles = _unitOfWork.roleRepository.GetAll()
            };
            if (id == null)
                return NotFound();

            userEditVM.User = await _unitOfWork.userRepository.FindIdIncludeChiNhanh(id);

            if (userEditVM.User == null)
                return NotFound();

            userEditVM.UsernameEdit = userEditVM.User.Username;
            userEditVM.Username = userEditVM.User.Username;

            return View(userEditVM);
        }

        // Post: Eidt method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserEditViewModel userEditVM)
        {
            if (id != userEditVM.User.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(userEditVM.User.Password))
                {
                    userEditVM.User.Password = userEditVM.OldPass;
                }

                userEditVM.User.Username = userEditVM.UsernameEdit;

                _unitOfWork.userRepository.Update(userEditVM.User);
                await _unitOfWork.Complete();

                return RedirectToAction(nameof(Index));
            }

            return View(userEditVM);
        }

        // Get: Details method
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            UserVM.User = await _unitOfWork.userRepository.FindIdIncludeChiNhanh(id);

            if (UserVM.User == null)
                return NotFound();

            return View(UserVM);
        }

        // Get: Delete method
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            UserVM.User = await _unitOfWork.userRepository.FindIdIncludeChiNhanh(id);

            if (UserVM.User == null)
                return NotFound();

            return View(UserVM);
        }

        // Post: Delete method
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            User user = await _unitOfWork.userRepository.GetByIdAsync(id);

            if (user == null)
                return NotFound();
            else
            {
                _unitOfWork.userRepository.Delete(user);
                await _unitOfWork.Complete();

                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public JsonResult GetDmDaiLyByChiNhanh(int chinhanh)
        {
            var dMDaiLies = _unitOfWork.dMDaiLyRepository.Find(x => x.ChiNhanhId == chinhanh);
            return Json(new
            {
                data = JsonConvert.SerializeObject(dMDaiLies)
            });
        }

        [AcceptVerbs("get", "post")]
        public IActionResult UsersExists(string UsernameCreate)
        {
            bool result = false;
            var user = _unitOfWork.userRepository.Find(x => x.Username.ToLower() == UsernameCreate.ToLower());
            if (user.Count() == 0)
                result = true;
            return Json(result);
        }
        
        [AcceptVerbs("get", "post")]
        public IActionResult UsersEditExists(string UsernameEdit, string Username)
        {
            bool result = false;
            var user = _unitOfWork.userRepository.Find(x => x.Username.ToLower() == UsernameEdit.ToLower());
            var count = user.Count();
            if (count == 0 || (UsernameEdit == Username))
                result = true;
            return Json(result);
        }
    }
}