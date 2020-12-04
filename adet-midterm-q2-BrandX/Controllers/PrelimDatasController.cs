using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BrandX.Data;
using BrandX.Models;

namespace BrandX.Controllers
{
    public class PrelimDatasController : Controller
    {
        private readonly InfoData _context;

        public PrelimDatasController(InfoData context)
        {
            _context = context;
        }

        // GET: PrelimDatas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Prelim.ToListAsync());
        }

        // GET: PrelimDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prelimData = await _context.Prelim
                .FirstOrDefaultAsync(m => m.ID == id);
            if (prelimData == null)
            {
                return NotFound();
            }

            return View(prelimData);
        }

        // GET: PrelimDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PrelimDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Quiz1,Quiz2,Quiz3,Assignment1,Assignment2,Assignment3,Exam")] PrelimData prelimData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prelimData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prelimData);
        }

        // GET: PrelimDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prelimData = await _context.Prelim.FindAsync(id);
            if (prelimData == null)
            {
                return NotFound();
            }
            return View(prelimData);
        }

        // POST: PrelimDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Quiz1,Quiz2,Quiz3,Assignment1,Assignment2,Assignment3,Exam")] PrelimData prelimData)
        {
            if (id != prelimData.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prelimData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrelimDataExists(prelimData.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(prelimData);
        }

        // GET: PrelimDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prelimData = await _context.Prelim
                .FirstOrDefaultAsync(m => m.ID == id);
            if (prelimData == null)
            {
                return NotFound();
            }

            return View(prelimData);
        }

        // POST: PrelimDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prelimData = await _context.Prelim.FindAsync(id);
            _context.Prelim.Remove(prelimData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrelimDataExists(int id)
        {
            return _context.Prelim.Any(e => e.ID == id);
        }
    }
}
