using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMD.Data.Models;
using EMD.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EMD.Controllers
{
    public class RolesController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public RolesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            return View(_unitOfWork.roleRepository.GetAll());
        }

        //Get Create method
        public IActionResult Create()
        {
            return View();
        }

        // Post Create 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Role role)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.roleRepository.Create(role);
                await _unitOfWork.Complete();
                SetAlert("Thêm mới thành công.", "success");
                return RedirectToAction(nameof(Index));
            }

            return View(role);
        }

        // Get Edit method
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var role = await _unitOfWork.roleRepository.GetByIdAsync(id);

            if (role == null)
                return NotFound();

            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Role role)
        {
            if (id != role.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _unitOfWork.roleRepository.Update(role);
                await _unitOfWork.Complete();
                SetAlert("Cập nhật thành công.", "success");
                return RedirectToAction(nameof(Index));
            }

            return View(role);
        }

        // Get Details method
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var role = await _unitOfWork.roleRepository.GetByIdAsync(id);

            if (role == null)
                return NotFound();

            return View(role);
        }

        // Get Delete method
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var role = await _unitOfWork.roleRepository.GetByIdAsync(id);

            if (role == null)
                return NotFound();

            return View(role);
        }

        // Post Delete 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var role = await _unitOfWork.roleRepository.GetByIdAsync(id);
            _unitOfWork.roleRepository.Delete(role);
            await _unitOfWork.Complete();
            SetAlert("Xóa thành công.", "success");
            return RedirectToAction(nameof(Index));
        }
    }
}