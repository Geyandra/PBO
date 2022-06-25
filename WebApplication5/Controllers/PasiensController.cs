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
    public class PasiensController : Controller
    {
        private readonly AppDBContext _context;

        public PasiensController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Pasiens
        public async Task<IActionResult> Index()
        {
              return _context.Pasiens != null ? 
                          View(await _context.Pasiens.ToListAsync()) :
                          Problem("Entity set 'AppDBContext.Pasiens'  is null.");
        }

        // GET: Pasiens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pasiens == null)
            {
                return NotFound();
            }

            var pasien = await _context.Pasiens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pasien == null)
            {
                return NotFound();
            }

            return View(pasien);
        }

        // GET: Pasiens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pasiens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nama,NIK,Jenis_Kelamin,Umur,TTL,Alamat,Nomor_Telepon,Pekerjaan,Poli,Keluhan")] Pasien pasien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pasien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pasien);
        }

        // GET: Pasiens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pasiens == null)
            {
                return NotFound();
            }

            var pasien = await _context.Pasiens.FindAsync(id);
            if (pasien == null)
            {
                return NotFound();
            }
            return View(pasien);
        }

        // POST: Pasiens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nama,NIK,Jenis_Kelamin,Umur,TTL,Alamat,Nomor_Telepon,Pekerjaan,Poli,Keluhan")] Pasien pasien)
        {
            if (id != pasien.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pasien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PasienExists(pasien.Id))
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
            return View(pasien);
        }

        // GET: Pasiens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pasiens == null)
            {
                return NotFound();
            }

            var pasien = await _context.Pasiens
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pasien == null)
            {
                return NotFound();
            }

            return View(pasien);
        }

        // POST: Pasiens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pasiens == null)
            {
                return Problem("Entity set 'AppDBContext.Pasiens'  is null.");
            }
            var pasien = await _context.Pasiens.FindAsync(id);
            if (pasien != null)
            {
                _context.Pasiens.Remove(pasien);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PasienExists(int id)
        {
          return (_context.Pasiens?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
