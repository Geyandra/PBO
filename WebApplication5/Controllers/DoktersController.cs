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
    public class DoktersController : Controller
    {
        private readonly AppDBContext _context;

        public DoktersController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Dokters
        public async Task<IActionResult> Index()
        {
              return _context.Dokters != null ? 
                          View(await _context.Dokters.ToListAsync()) :
                          Problem("Entity set 'AppDBContext.Dokters'  is null.");
        }

        // GET: Dokters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Dokters == null)
            {
                return NotFound();
            }

            var dokter = await _context.Dokters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dokter == null)
            {
                return NotFound();
            }

            return View(dokter);
        }

        // GET: Dokters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dokters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nama,Poli,Nomor_Telepon,Alamat")] Dokter dokter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dokter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dokter);
        }

        // GET: Dokters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Dokters == null)
            {
                return NotFound();
            }

            var dokter = await _context.Dokters.FindAsync(id);
            if (dokter == null)
            {
                return NotFound();
            }
            return View(dokter);
        }

        // POST: Dokters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nama,Poli,Nomor_Telepon,Alamat")] Dokter dokter)
        {
            if (id != dokter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dokter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DokterExists(dokter.Id))
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
            return View(dokter);
        }

        // GET: Dokters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Dokters == null)
            {
                return NotFound();
            }

            var dokter = await _context.Dokters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dokter == null)
            {
                return NotFound();
            }

            return View(dokter);
        }

        // POST: Dokters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Dokters == null)
            {
                return Problem("Entity set 'AppDBContext.Dokters'  is null.");
            }
            var dokter = await _context.Dokters.FindAsync(id);
            if (dokter != null)
            {
                _context.Dokters.Remove(dokter);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DokterExists(int id)
        {
          return (_context.Dokters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
