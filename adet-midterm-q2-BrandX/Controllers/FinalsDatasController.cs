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
    public class FinalsDatasController : Controller
    {
        private readonly InfoData _context;

        public FinalsDatasController(InfoData context)
        {
            _context = context;
        }

        // GET: FinalsDatas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Finals.ToListAsync());
        }

        // GET: FinalsDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finalsData = await _context.Finals
                .FirstOrDefaultAsync(m => m.ID == id);
            if (finalsData == null)
            {
                return NotFound();
            }

            return View(finalsData);
        }

        // GET: FinalsDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FinalsDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Quiz1,Quiz2,Quiz3,Assignment1,Assignment2,Assignment3,Exam")] FinalsData finalsData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(finalsData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(finalsData);
        }

        // GET: FinalsDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finalsData = await _context.Finals.FindAsync(id);
            if (finalsData == null)
            {
                return NotFound();
            }
            return View(finalsData);
        }

        // POST: FinalsDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Quiz1,Quiz2,Quiz3,Assignment1,Assignment2,Assignment3,Exam")] FinalsData finalsData)
        {
            if (id != finalsData.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(finalsData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FinalsDataExists(finalsData.ID))
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
            return View(finalsData);
        }

        // GET: FinalsDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finalsData = await _context.Finals
                .FirstOrDefaultAsync(m => m.ID == id);
            if (finalsData == null)
            {
                return NotFound();
            }

            return View(finalsData);
        }

        // POST: FinalsDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var finalsData = await _context.Finals.FindAsync(id);
            _context.Finals.Remove(finalsData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FinalsDataExists(int id)
        {
            return _context.Finals.Any(e => e.ID == id);
        }
    }
}
