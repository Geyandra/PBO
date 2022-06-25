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
    public class RuangsController : Controller
    {
        private readonly AppDBContext _context;

        public RuangsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Ruangs
        public async Task<IActionResult> Index()
        {
              return _context.Ruangs != null ? 
                          View(await _context.Ruangs.ToListAsync()) :
                          Problem("Entity set 'AppDBContext.Ruangs'  is null.");
        }

        // GET: Ruangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ruangs == null)
            {
                return NotFound();
            }

            var ruang = await _context.Ruangs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ruang == null)
            {
                return NotFound();
            }

            return View(ruang);
        }

        // GET: Ruangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ruangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nama,Jenis,Kelas,Kapasitas")] Ruang ruang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ruang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ruang);
        }

        // GET: Ruangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ruangs == null)
            {
                return NotFound();
            }

            var ruang = await _context.Ruangs.FindAsync(id);
            if (ruang == null)
            {
                return NotFound();
            }
            return View(ruang);
        }

        // POST: Ruangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nama,Jenis,Kelas,Kapasitas")] Ruang ruang)
        {
            if (id != ruang.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ruang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RuangExists(ruang.Id))
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
            return View(ruang);
        }

        // GET: Ruangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ruangs == null)
            {
                return NotFound();
            }

            var ruang = await _context.Ruangs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ruang == null)
            {
                return NotFound();
            }

            return View(ruang);
        }

        // POST: Ruangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ruangs == null)
            {
                return Problem("Entity set 'AppDBContext.Ruangs'  is null.");
            }
            var ruang = await _context.Ruangs.FindAsync(id);
            if (ruang != null)
            {
                _context.Ruangs.Remove(ruang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RuangExists(int id)
        {
          return (_context.Ruangs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
