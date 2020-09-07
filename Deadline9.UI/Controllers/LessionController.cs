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
    public class LessionController : Controller
    {
        private ILessionService _lessionService { get;}

        public LessionController(ILessionService lessionService)
        {
            _lessionService = lessionService;
        }
        [AllowAnonymous]
        [Route("Lessions")]
        public async Task<IActionResult> Index()
        {
            return View(_lessionService.GetAll());
        }

        // GET: Lessions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lession = _lessionService.GetDetailsModel(id.Value);

            return View(lession);
        }

        // GET: Lessions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lessions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(LessionCreateModel model)
        {
            _lessionService.Create(model);
            return RedirectToAction("Index");
        }

        // GET: Lessions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = _lessionService.GetEditModel(id.Value);
            return View(model);
        }

        // POST: Lessions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(LessionEditModel lessionEditModel)
        {
            _lessionService.Edit(lessionEditModel);
            return RedirectToAction("Index");
        }

        // GET: Lessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _lessionService.Delete(id.Value);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Like(int Id)
        {
            try
            {
                var likes = _lessionService.Like(Id);

                return Ok(likes);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}
