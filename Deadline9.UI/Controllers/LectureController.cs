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
    public class LectureController : Controller
    {
        private ILectureService _lectureService { get; }
        private IGroupService _groupService { get; }
        private ITeacherService _teacherService { get; }
        private ILessionService _lessionService { get; }
        public LectureController(ILectureService lectureService, IGroupService groupService, ITeacherService teacherService, ILessionService lessionService)
        {
            _lectureService = lectureService;
            _groupService = groupService;
            _teacherService = teacherService;
            _lessionService = lessionService;
        }

        // GET: Lessions
        public async Task<IActionResult> Index()
        {
            return View(_lectureService.GetAll());
        }

        // GET: Lessions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lession = _lectureService.GetDetailsModel(id.Value);

            return View(lession);
        }

        // GET: Lessions/Create
        public IActionResult Create()
        {
            ViewBag.Teachers = _teacherService.GetSelectListItems();
            ViewBag.Lessions = _lessionService.GetSelectListItems();
            ViewBag.Groups = _groupService.GetSelectListItems();
            return View();
        }

        // POST: Lessions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(LectureCreateModel model)
        {
            _lectureService.Create(model);
            return RedirectToAction("Index");
        }

        // GET: Lessions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {   
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Teachers = _teacherService.GetSelectListItems();
            ViewBag.Lessions = _lessionService.GetSelectListItems();
            ViewBag.Groups = _groupService.GetSelectListItems();
            var model = _lectureService.GetEditModel(id.Value);
            return View(model);
        }

        // POST: Lessions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(LectureEditModel lessionEditModel)
        {
            _lectureService.Edit(lessionEditModel);
            return RedirectToAction("Index");
        }

        // GET: Lessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _lectureService.Delete(id.Value);
            return RedirectToAction("Index");
        }

    }
}
