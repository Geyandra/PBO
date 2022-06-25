using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class Rawat_InapController : Controller
    {
        private readonly AppDBContext _context;

        public Rawat_InapController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Rawat_Inap
        public async Task<IActionResult> Index()
        {
              return _context.Rawat_Inaps != null ? 
                          View(await _context.Rawat_Inaps.ToListAsync()) :
                          Problem("Entity set 'AppDBContext.Rawat_Inaps'  is null.");
        }

        // GET: Rawat_Inap/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rawat_Inaps == null)
            {
                return NotFound();
            }

            var rawat_Inap = await _context.Rawat_Inaps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rawat_Inap == null)
            {
                return NotFound();
            }

            return View(rawat_Inap);
        }

        // GET: Rawat_Inap/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rawat_Inap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NIK,Kamar,Dokter,Tanggal")] Rawat_Inap rawat_Inap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rawat_Inap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rawat_Inap);
        }

        // GET: Rawat_Inap/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rawat_Inaps == null)
            {
                return NotFound();
            }

            var rawat_Inap = await _context.Rawat_Inaps.FindAsync(id);
            if (rawat_Inap == null)
            {
                return NotFound();
            }
            return View(rawat_Inap);
        }

        // POST: Rawat_Inap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NIK,Kamar,Dokter,Tanggal")] Rawat_Inap rawat_Inap)
        {
            if (id != rawat_Inap.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rawat_Inap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Rawat_InapExists(rawat_Inap.Id))
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
            return View(rawat_Inap);
        }

        // GET: Rawat_Inap/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rawat_Inaps == null)
            {
                return NotFound();
            }

            var rawat_Inap = await _context.Rawat_Inaps
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rawat_Inap == null)
            {
                return NotFound();
            }

            return View(rawat_Inap);
        }

        // POST: Rawat_Inap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rawat_Inaps == null)
            {
                return Problem("Entity set 'AppDBContext.Rawat_Inaps'  is null.");
            }
            var rawat_Inap = await _context.Rawat_Inaps.FindAsync(id);
            if (rawat_Inap != null)
            {
                _context.Rawat_Inaps.Remove(rawat_Inap);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Rawat_InapExists(int id)
        {
          return (_context.Rawat_Inaps?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
