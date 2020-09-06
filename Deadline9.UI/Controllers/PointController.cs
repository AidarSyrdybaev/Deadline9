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
using Microsoft.AspNetCore.Authorization;

namespace Deadline9.UI.Controllers
{
    [Authorize]
    public class PointController : Controller
    {
        private IPointService _pointService { get; }
        private IStudentService _studentService { get; }

        public PointController(IPointService pointService, IStudentService studentService)
        {
            _pointService = pointService;
            _studentService = studentService;
        }
        [AllowAnonymous]
        [Route("Points")]
        public async Task<IActionResult> Index()
        {
            return View(_pointService.GetAll());
        }

        // GET: Lessions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lession = _pointService.GetDetailsModel(id.Value);

            return View(lession);
        }

        // GET: Lessions/Create
        public IActionResult Create()
        {
            ViewBag.Students = _studentService.GetSelectListItems();
            return View();
        }

        // POST: Lessions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(PointCreateModel model)
        {
            _pointService.Create(model);
            return RedirectToAction("Index");
        }

        // GET: Lessions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Students = _studentService.GetSelectListItems();
            var model = _pointService.GetEditModel(id.Value);
            return View(model);
        }

        // POST: Lessions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(PointEditModel PointEditModel)
        {
            _pointService.Edit(PointEditModel);
            return RedirectToAction("Index");
        }

        // GET: Lessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _pointService.Delete(id.Value);
            return RedirectToAction("Index");
        }
    }
}
