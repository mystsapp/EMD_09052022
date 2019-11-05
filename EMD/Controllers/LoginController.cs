using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMD.Data.Models;
using EMD.Data.Repository;
using EMD.Models;
using EMD.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMD.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public LoginController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View();
        }

        [ActionName("login")]
        [HttpGet]
        public IActionResult login()
        {
            // ViewBag.request = UriHelper.GetDisplayUrl(Request);
            // listDaily("");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _unitOfWork.userRepository.login(model.username, model.password);
                switch (result)
                {
                    case 0:
                        ModelState.AddModelError("", "Tài khoản này không tồn tại");
                        break;
                    case 1:
                        {
                            var userInfo = await _unitOfWork.userRepository.FindIncludeOneAsync(y => y.Role, x => x.Username.ToLower() == model.username.ToLower());
                            //HttpContext.Session.SetString("username", userInfo.Username);
                            //HttpContext.Session.SetString("hoten", userInfo.Hoten);
                            //HttpContext.Session.SetString("password", model.password);
                            //HttpContext.Session.SetString("macn", userInfo.Macn);
                            //HttpContext.Session.SetString("daily", model.daily);
                            //HttpContext.Session.SetString("userInfo", JsonConvert.SerializeObject(userInfo));

                            HttpContext.Session.Set("ssUser", userInfo.FirstOrDefault());

                            return RedirectToAction("Index", "EMDs");
                        }

                    case -1:
                        ModelState.AddModelError("", "Tài khoản này đã bị khóa");
                        break;
                    case -2:
                        ModelState.AddModelError("", "Mật khẩu không đúng.");
                        break;
                }

            }
            return View();
        }
        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("index", "EMDs");
        }

        [HttpGet]
        public ActionResult changepass(string strUrl)
        {
            var entity = new changepassModel();
            User user = HttpContext.Session.Get<User>("ssUser");
            entity.username = user.Username;
            entity.password = user.Password;
            entity.strUrl = strUrl;
            return View("changepass", entity);
        }
        [HttpPost]
        public ActionResult changepass(changepassModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _unitOfWork.userRepository.changepass(model.username, model.password, model.newpassword, model.confirmpassword);
                if (result == -1)
                {
                    ModelState.AddModelError("", "Vui lòng nhập mật khẩu cũ.");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu cũ không đúng.");
                }
                else if (result == -3)
                {
                    ModelState.AddModelError("", "Vui lòng nhập mật khẩu mới.");
                }
                else if (result == -4)
                {
                    ModelState.AddModelError("", "Vui lòng nhập lại mật khẩu mới.");
                }
                else if (result == -5)
                {
                    ModelState.AddModelError("", "Mật khẩu nhập lại không đúng.");
                }
                else if (result == 1)
                {
                    //if (Session["role"].Equals("cashier"))
                    //{
                    //    return RedirectToAction("Index", "Cashier");
                    //}
                    //else
                    //{
                    //return RedirectToAction("Index", "Home");
                    //}

                    SetAlert("Đổi mật khẩu thành công.", "success");

                    return Redirect(model.strUrl);
                }
            }
            return View("changepass");
        }

        private void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "waring")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
        }
    }
}