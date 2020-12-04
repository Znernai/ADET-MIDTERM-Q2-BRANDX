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
    public class PrefinalDatasController : Controller
    {
        private readonly InfoData _context;

        public PrefinalDatasController(InfoData context)
        {
            _context = context;
        }

        // GET: PrefinalDatas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Prefinal.ToListAsync());
        }

        // GET: PrefinalDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prefinalData = await _context.Prefinal
                .FirstOrDefaultAsync(m => m.ID == id);
            if (prefinalData == null)
            {
                return NotFound();
            }

            return View(prefinalData);
        }

        // GET: PrefinalDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PrefinalDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Quiz1,Quiz2,Quiz3,Assignment1,Assignment2,Assignment3,Exam")] PrefinalData prefinalData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prefinalData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prefinalData);
        }

        // GET: PrefinalDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prefinalData = await _context.Prefinal.FindAsync(id);
            if (prefinalData == null)
            {
                return NotFound();
            }
            return View(prefinalData);
        }

        // POST: PrefinalDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Quiz1,Quiz2,Quiz3,Assignment1,Assignment2,Assignment3,Exam")] PrefinalData prefinalData)
        {
            if (id != prefinalData.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prefinalData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrefinalDataExists(prefinalData.ID))
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
            return View(prefinalData);
        }

        // GET: PrefinalDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prefinalData = await _context.Prefinal
                .FirstOrDefaultAsync(m => m.ID == id);
            if (prefinalData == null)
            {
                return NotFound();
            }

            return View(prefinalData);
        }

        // POST: PrefinalDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prefinalData = await _context.Prefinal.FindAsync(id);
            _context.Prefinal.Remove(prefinalData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrefinalDataExists(int id)
        {
            return _context.Prefinal.Any(e => e.ID == id);
        }
    }
}
