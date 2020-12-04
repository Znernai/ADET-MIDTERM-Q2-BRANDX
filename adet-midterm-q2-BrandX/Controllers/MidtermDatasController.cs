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
    public class MidtermDatasController : Controller
    {
        private readonly InfoData _context;

        public MidtermDatasController(InfoData context)
        {
            _context = context;
        }

        // GET: MidtermDatas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Midterm.ToListAsync());
        }

        // GET: MidtermDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var midtermData = await _context.Midterm
                .FirstOrDefaultAsync(m => m.ID == id);
            if (midtermData == null)
            {
                return NotFound();
            }

            return View(midtermData);
        }

        // GET: MidtermDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MidtermDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Quiz1,Quiz2,Quiz3,Assignment1,Assignment2,Assignment3,Exam")] MidtermData midtermData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(midtermData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(midtermData);
        }

        // GET: MidtermDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var midtermData = await _context.Midterm.FindAsync(id);
            if (midtermData == null)
            {
                return NotFound();
            }
            return View(midtermData);
        }

        // POST: MidtermDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Quiz1,Quiz2,Quiz3,Assignment1,Assignment2,Assignment3,Exam")] MidtermData midtermData)
        {
            if (id != midtermData.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(midtermData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MidtermDataExists(midtermData.ID))
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
            return View(midtermData);
        }

        // GET: MidtermDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var midtermData = await _context.Midterm
                .FirstOrDefaultAsync(m => m.ID == id);
            if (midtermData == null)
            {
                return NotFound();
            }

            return View(midtermData);
        }

        // POST: MidtermDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var midtermData = await _context.Midterm.FindAsync(id);
            _context.Midterm.Remove(midtermData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MidtermDataExists(int id)
        {
            return _context.Midterm.Any(e => e.ID == id);
        }
    }
}
