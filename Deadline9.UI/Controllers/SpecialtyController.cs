using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Deadline9.BL.Services;
using Deadline9.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Deadline9.UI.Controllers
{
    public class SpecialtyController : Controller
    {
        private IDepartmentService _DepartmentService { get; }
        private ISpecialtyService _SpecialtyService { get; }

        public SpecialtyController(IDepartmentService departmentService, ISpecialtyService specialtyService)
        {
            _DepartmentService = departmentService;
            _SpecialtyService = specialtyService;
        }

        public ActionResult Index()
        {
            var Specialties = _SpecialtyService.GetAll();
            return View(Specialties);
        }

        
        public ActionResult Details(int id)
        {
            return View();
        }

        
        public ActionResult Create()
        {
            ViewBag.Departments = _DepartmentService.GetDepartmentsSelectListItems();
            return View();
        }

        [HttpPost]
        public ActionResult Create(SpecialtyCreateModel model)
        {
            _SpecialtyService.Create(model);
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            ViewBag.Departments = _DepartmentService.GetDepartmentsSelectListItems();
            var Model = _SpecialtyService.GetSpecialityEditModel(id);
            return View(Model);
        }
        [HttpPost]
        public ActionResult Edit(SpecialtyEditModel model)
        {
            _SpecialtyService.Edit(model);
            return RedirectToAction("Index");
            
        }

        
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}
