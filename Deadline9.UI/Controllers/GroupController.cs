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
    public class GroupController : Controller
    {
        private IGroupService _groupSerivce { get; }
        private ISpecialtyService _specialtyService { get; }

        public GroupController(IGroupService groupSerivce, ISpecialtyService specialtyService)
        {
            _groupSerivce = groupSerivce;
            _specialtyService = specialtyService;
        }

        // GET: Groups
        public async Task<IActionResult> Index()
        {
            return View(_groupSerivce.GetAll());
        }

        // GET: Groups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View();
        }

        // GET: Groups/Create
        public IActionResult Create()
        {
            ViewBag.Specialties = _specialtyService.GetSelectListItems();
            return View();
        }

        // POST: Groups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(GroupCreateModel model)
        {
            _groupSerivce.Create(model);
            return RedirectToAction("Index");
        }

        // GET: Groups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Specialties = _specialtyService.GetSelectListItems();
            return View(_groupSerivce.GetEditModel(id.Value));
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(GroupEditModel model)
        {
            _groupSerivce.Edit(model);
            
            return RedirectToAction("Index");
        }

        // GET: Groups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _groupSerivce.Delete(id.Value);

            return RedirectToAction("Index");
        }
    }
}
