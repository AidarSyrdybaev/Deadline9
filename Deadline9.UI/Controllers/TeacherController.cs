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
    public class TeacherController : Controller
    {
        private ITeacherService _TeacherSerivce { get; }

        public TeacherController(ITeacherService teacherService)
        {
            _TeacherSerivce = teacherService;
        }

        // GET: Teacher
        public async Task<IActionResult> Index()
        {   
            
            return View(_TeacherSerivce.GetAll());
        }

        // GET: Teacher/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            return View(_TeacherSerivce.GetDetailsModel(id.Value));
        }

        // GET: Teacher/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TeacherCreateModel model)
        {
            _TeacherSerivce.Create(model);
            return RedirectToAction("Index");
        }

        // GET: Teacher/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = _TeacherSerivce.GetEditModel(id.Value);
            return View(model);
        }

       
        [HttpPost]
        
        public async Task<IActionResult> Edit(TeacherEditModel teacherEditModel)
        {
            _TeacherSerivce.Edit(teacherEditModel);
            return View();
        }

        // GET: Teacher/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            _TeacherSerivce.Delete(id.Value);
            return RedirectToAction("Index");
        }

    }
}
