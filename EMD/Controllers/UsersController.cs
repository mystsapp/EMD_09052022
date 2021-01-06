using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMD.Data.Models;
using EMD.Data.Models_QLTaiKhoan;
using EMD.Data.Repository;
using EMD.Models;
using EMD.Utilities;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EMD.Controllers
{
    public class UsersController : BaseController
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
            UserVM.StrUrl = UriHelper.GetDisplayUrl(Request);

            UserVM.Users = await _unitOfWork.userRepository.GetAllIncludeAsync(x => x.ChiNhanh, y => y.Role);
            return View(UserVM);
        }

        // Get Create method
        public IActionResult Create(string strUrl)
        {
            UserVM.StrUrl = strUrl;
            return View(UserVM);
        }

        // Post: Create Method
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePOST(string strUrl)
        {
            var user = HttpContext.Session.Gets<User>("loginUser").SingleOrDefault();
            if (!ModelState.IsValid)
            {
                return View(UserVM);
            }

            UserVM.User.Password = MaHoaSHA1.EncodeSHA1(UserVM.User.Password);
            UserVM.User.Username = UserVM.UsernameCreate;
            UserVM.User.NgayTao = DateTime.Now;
            UserVM.User.Doimk = false;
            UserVM.User.NguoiTao = user.Username;
            UserVM.User.MaCN = _unitOfWork.chiNhanhRepository.GetById(UserVM.User.ChiNhanhId).MaChiNhanh;

            //_unitOfWork.userRepository.Create(UserVM.User);
            //await _unitOfWork.Complete();
            //SetAlert("Tạo mới User thành công.", "success");
            //return RedirectToAction(nameof(Index));

            try
            {


                // kiem tra ton tai user trong qltk
                var qltkUserExist = await _unitOfWork.userQLTaiKhoanRepository.GetByIdAsync(UserVM.User.Username);
                // kiem tra ton tai user trong qltk
                if (qltkUserExist == null) // user trong qltk chua co
                {
                    // INSERT INTO qltaikhoan.dbo.Users(username,[password],hoten,macn, trangthai,doimk,ngaydoimk,ngaytao,nguoitao)
                    var qltkUser = new Data.Models_QLTaiKhoan.Users()
                    {
                        Username = UserVM.User.Username,
                        Password = UserVM.User.Password,
                        Hoten = UserVM.User.Name,
                        Macn = UserVM.User.MaCN,
                        Trangthai = UserVM.User.TrangThai,
                        Doimk = UserVM.User.Doimk,
                        Ngaydoimk = UserVM.User.Ngaydoimk,
                        Ngaytao = UserVM.User.NgayTao,
                        Nguoitao = UserVM.User.NguoiTao
                    };

                    _unitOfWork.userQLTaiKhoanRepository.Create(qltkUser);
                    // INSERT INTO qltaikhoan.dbo.Users(username,[password],hoten,macn, trangthai,doimk,ngaydoimk,ngaytao,nguoitao)

                }

                // kiem tra ton tai user trong applicationuser qltk
                var qltkApplicationUser = await _unitOfWork.applicationUserQLTaiKhoanRepository.GetByIdTwoKeyAsync(UserVM.User.Username, "012");
                if (qltkApplicationUser == null)
                {

                    // 	insert into qltaikhoan.dbo.ApplicationUser(username, mact)
                    var applicationUser = new ApplicationUser()
                    {
                        Username = UserVM.User.Username,
                        Mact = "012"
                    };
                    _unitOfWork.applicationUserQLTaiKhoanRepository.Create(applicationUser);
                    await _unitOfWork.Complete();
                    // 	insert into qltaikhoan.dbo.ApplicationUser(username, mact)

                }
                // kiem tra ton tai user trong applicationuser qltk

                //if (qltkUserExist != null && qltkApplicationUser != null)
                //{
                //    SetAlert("User này đã tồn tại trên QLTK và trên ứng dụng này", "warning");
                //    UserVM = new UserViewModel()
                //    {
                //        User = new Data.Models_IB.User(),
                //        Dmchinhanhs = _unitOfWork.dmChiNhanhRepository.GetAll(),
                //        Roles = _unitOfWork.roleRepository.GetAll()
                //    };
                //    return View(UserVM);
                //}
                _unitOfWork.userRepository.Create(UserVM.User);
                await _unitOfWork.Complete();
                SetAlert("Thêm mới thành công.", "success");
                return Redirect(strUrl);
            }
            catch (Exception ex)
            {
                SetAlert(ex.Message, "error");
                return View(UserVM);
            }

        }

        // Get: Edit method
        public async Task<IActionResult> Edit(int? id, string strUrl)
        {
            UserVM.StrUrl = strUrl;

            //UserEditViewModel userEditVM = new UserEditViewModel()
            //{
            //    ChiNhanhs = _unitOfWork.chiNhanhRepository.GetAll(),
            //    User = new Data.Models.User(),
            //    DMDaiLies = _unitOfWork.dMDaiLyRepository.GetAll(),
            //    Roles = _unitOfWork.roleRepository.GetAll()
            //};
            if (id == null)
                return NotFound();

            UserVM.User = await _unitOfWork.userRepository.FindIdIncludeChiNhanh(id);

            if (UserVM.User == null)
                return NotFound();

            UserVM.OldPassword = UserVM.User.Password;
            //userEditVM.Username = userEditVM.User.Username;
            UserVM.UsernameCreate = "cde";

            return View(UserVM);
        }

        // Post: Eidt method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string strUrl)
        {
            if (id != UserVM.User.Id)
                return NotFound();

            if (ModelState.IsValid)
            {

                if (string.IsNullOrEmpty(UserVM.User.Password))
                {
                    UserVM.User.Password = UserVM.OldPassword;
                }
                else
                {
                    UserVM.User.Password = MaHoaSHA1.EncodeSHA1(UserVM.User.Password);
                }

                //_unitOfWork.userRepository.Update(userEditVM.User);
                //await _unitOfWork.Complete();
                //SetAlert("Cập nhật User thành công.", "success");
                //return RedirectToAction(nameof(Index));

                try
                {

                    // update qltaikhoan.dbo.users 
                    // set[password] = i.[password],hoten = i.[Name],trangthai = i.TrangThai,doimk = i.Doimk,ngaydoimk = i.ngaydoimk
                    var userQLTaiKhoan = new Data.Models_QLTaiKhoan.Users()
                    {
                        Username = UserVM.User.Username,
                        Password = UserVM.User.Password,
                        Hoten = UserVM.User.Name,
                        Macn = UserVM.User.MaCN,
                        Trangthai = UserVM.User.TrangThai,
                        Doimk = UserVM.User.Doimk,
                        Ngaydoimk = UserVM.User.Ngaydoimk,
                        Ngaytao = UserVM.User.NgayTao,
                        Nguoitao = UserVM.User.NguoiTao
                    };
                    var userQLTaiKhoanDb = _unitOfWork.userQLTaiKhoanRepository.GetByIdAsNoTracking(x => x.Username == UserVM.User.Username);
                    if (userQLTaiKhoanDb != null)
                    {
                        _unitOfWork.userQLTaiKhoanRepository.Update(userQLTaiKhoan);
                    }
                    else
                    {
                        SetAlert("User không tồn tại trên QLTK", "warning");
                        return View(UserVM);
                    }
                    // update qltaikhoan.dbo.users set[password] = i.[password],hoten = i.[Name],trangthai = i.TrangThai,doimk = i.Doimk,ngaydoimk = i.ngaydoimk

                    _unitOfWork.userRepository.Update(UserVM.User);
                    await _unitOfWork.Complete();
                    SetAlert("Cập nhật thành công", "success");
                    return Redirect(strUrl);
                }
                catch (Exception ex)
                {
                    SetAlert(ex.Message, "error");
                    return View(UserVM);
                }
            }

            return View(UserVM);
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
        public async Task<IActionResult> DeleteConfirm(int id, string strUrl)
        {
            User user = await _unitOfWork.userRepository.GetByIdAsync(id);

            if (user == null)
                return NotFound();


            //        delete qltaikhoan.dbo.ApplicationUser where username = (select username from deleted)
            var applicationUserQLTaiKhoan = await _unitOfWork.applicationUserQLTaiKhoanRepository.GetByIdTwoKeyAsync(user.Username, "012");
            if (applicationUserQLTaiKhoan != null)
            {
                _unitOfWork.applicationUserQLTaiKhoanRepository.Delete(applicationUserQLTaiKhoan);
            }
            //        delete qltaikhoan.dbo.ApplicationUser where username = (select username from deleted)

            try
            {
                _unitOfWork.userRepository.Delete(user);
                await _unitOfWork.Complete();
                SetAlert("Xóa User thành công.", "success");
                return Redirect(strUrl);
            }
            catch (Exception ex)
            {
                SetAlert(ex.Message, "error");
                return Redirect(strUrl);
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

        public JsonResult UsersExists(string UsernameCreate)
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