using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeadLine9.DAL.Context;
using DeadLine9.DAL.Entities;
using Deadline9.BL.Services;
using Deadline9.Models;

namespace Deadline9.UI.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentService _DepartmentService { get; set; }

        public DepartmentController(IDepartmentService departmentService)
        {
            _DepartmentService = departmentService;
        }

       
        public async Task<IActionResult> Index()
        {
            return View(_DepartmentService.GetAll());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View();
        }


        public IActionResult Create()
        {
            return View();
        }

      
        [HttpPost]
        public async Task<IActionResult> Create(DepartmentCreateModel department)
        {
            _DepartmentService.Create(department);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Department = _DepartmentService.GetDepartmentModel(id.Value);
            return View(Department);
        }

     
        [HttpPost]
        public async Task<IActionResult> Edit(DepartmentModel model)
        {
            _DepartmentService.Edit(model);
            return RedirectToAction("Index");
        }

       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _DepartmentService.Delete(id.Value);
            return RedirectToAction("Index");
        }
    }
}
