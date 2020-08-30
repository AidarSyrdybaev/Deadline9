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
    public class StudentController : Controller
    {
        private IStudentService _studentService { get; }
        private IGroupService _groupService { get; }

        public StudentController(IStudentService studentService, IGroupService groupService)
        {
            _studentService = studentService;
            _groupService = groupService;
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
            var Students = _studentService.GetAll();
            return View(Students);
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = _studentService.GetDetailsModel(id.Value);
            return View(model);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            ViewBag.Groups = _groupService.GetSelectListItems();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(StudentCreateModel model)
        {
            _studentService.Create(model);
            return RedirectToAction("Index");
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Groups = _groupService.GetSelectListItems();
            var Model = _studentService.GetEditModel(id.Value);
            return View(Model);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(StudentEditModel model)
        {
            _studentService.Edit(model);
            return RedirectToActionPermanent("Details", new { id = model.Id});
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _studentService.Delete(id.Value);
            return RedirectToAction("Index");
        }
    }
}
