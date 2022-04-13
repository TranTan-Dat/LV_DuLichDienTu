using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LV_DuLichDienTu.Models;

namespace LV_DuLichDienTu.Controllers
{
    public class CamKetDichVusController : Controller
    {
        private readonly acompec_lvdatContext _context;

        public CamKetDichVusController(acompec_lvdatContext context)
        {
            _context = context;
        }

        // GET: CamKetDichVus
        public async Task<IActionResult> Index()
        {
            return View(await _context.CamKetDichVu.ToListAsync());
        }

        // GET: CamKetDichVus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camKetDichVu = await _context.CamKetDichVu
                .FirstOrDefaultAsync(m => m.ckdv_id == id);
            if (camKetDichVu == null)
            {
                return NotFound();
            }

            return View(camKetDichVu);
        }

        // GET: CamKetDichVus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CamKetDichVus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ckdv_id,ckdv_noidung,ckdv_boithuong,dv_id")] CamKetDichVu camKetDichVu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(camKetDichVu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(camKetDichVu);
        }

        // GET: CamKetDichVus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camKetDichVu = await _context.CamKetDichVu.FindAsync(id);
            if (camKetDichVu == null)
            {
                return NotFound();
            }
            return View(camKetDichVu);
        }

        // POST: CamKetDichVus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ckdv_id,ckdv_noidung,ckdv_boithuong,dv_id")] CamKetDichVu camKetDichVu)
        {
            if (id != camKetDichVu.ckdv_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(camKetDichVu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CamKetDichVuExists(camKetDichVu.ckdv_id))
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
            return View(camKetDichVu);
        }

        // GET: CamKetDichVus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camKetDichVu = await _context.CamKetDichVu
                .FirstOrDefaultAsync(m => m.ckdv_id == id);
            if (camKetDichVu == null)
            {
                return NotFound();
            }

            return View(camKetDichVu);
        }

        // POST: CamKetDichVus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var camKetDichVu = await _context.CamKetDichVu.FindAsync(id);
            _context.CamKetDichVu.Remove(camKetDichVu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CamKetDichVuExists(int id)
        {
            return _context.CamKetDichVu.Any(e => e.ckdv_id == id);
        }
    }
}