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
    public class PembayaransController : Controller
    {
        private readonly AppDBContext _context;

        public PembayaransController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Pembayarans
        public async Task<IActionResult> Index()
        {
              return _context.Pembayarans != null ? 
                          View(await _context.Pembayarans.ToListAsync()) :
                          Problem("Entity set 'AppDBContext.Pembayarans'  is null.");
        }

        // GET: Pembayarans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pembayarans == null)
            {
                return NotFound();
            }

            var pembayaran = await _context.Pembayarans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pembayaran == null)
            {
                return NotFound();
            }

            return View(pembayaran);
        }

        // GET: Pembayarans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pembayarans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NIK,Biaya,Tanggal")] Pembayaran pembayaran)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pembayaran);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pembayaran);
        }

        // GET: Pembayarans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pembayarans == null)
            {
                return NotFound();
            }

            var pembayaran = await _context.Pembayarans.FindAsync(id);
            if (pembayaran == null)
            {
                return NotFound();
            }
            return View(pembayaran);
        }

        // POST: Pembayarans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NIK,Biaya,Tanggal")] Pembayaran pembayaran)
        {
            if (id != pembayaran.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pembayaran);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PembayaranExists(pembayaran.Id))
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
            return View(pembayaran);
        }

        // GET: Pembayarans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pembayarans == null)
            {
                return NotFound();
            }

            var pembayaran = await _context.Pembayarans
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pembayaran == null)
            {
                return NotFound();
            }

            return View(pembayaran);
        }

        // POST: Pembayarans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pembayarans == null)
            {
                return Problem("Entity set 'AppDBContext.Pembayarans'  is null.");
            }
            var pembayaran = await _context.Pembayarans.FindAsync(id);
            if (pembayaran != null)
            {
                _context.Pembayarans.Remove(pembayaran);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PembayaranExists(int id)
        {
          return (_context.Pembayarans?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
