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
    public class DiaDiem_DuLichsController : Controller
    {
        private readonly acompec_lvdatContext _context;

        public DiaDiem_DuLichsController(acompec_lvdatContext context)
        {
            _context = context;
        }

        // GET: DiaDiem_DuLichs
        public async Task<IActionResult> Index()
        {
            
            //  = from p in _context.DiaDiem_DuLich
            // where p.dddl_id = _context.Hinh_DiaDiemDuLich.Find(c => c.dddl_id)
            // group p by p.PartID into gp
            // select new
            //        {
            //            PartID = gp.PartID,
            //            InstanceCount = gp.Count(),
            //        }

            // ViewData["tempData"] = _context.DiaDiem_DuLich.; 
            return View(await _context.DiaDiem_DuLich.ToListAsync());
        }

        // GET: DiaDiem_DuLichs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diaDiem_DuLich = await _context.DiaDiem_DuLich
                .FirstOrDefaultAsync(m => m.dddl_id == id);
            if (diaDiem_DuLich == null)
            {
                return NotFound();
            }

            return View(diaDiem_DuLich);
        }

        // GET: DiaDiem_DuLichs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DiaDiem_DuLichs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("dddl_id,dddl_ten,dddl_mota,hinh_id,bvdd_id")] DiaDiem_DuLich diaDiem_DuLich)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diaDiem_DuLich);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diaDiem_DuLich);
        }

        // GET: DiaDiem_DuLichs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diaDiem_DuLich = await _context.DiaDiem_DuLich.FindAsync(id);
            if (diaDiem_DuLich == null)
            {
                return NotFound();
            }
            return View(diaDiem_DuLich);
        }

        // POST: DiaDiem_DuLichs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("dddl_id,dddl_ten,dddl_mota,hinh_id,bvdd_id")] DiaDiem_DuLich diaDiem_DuLich)
        {
            if (id != diaDiem_DuLich.dddl_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diaDiem_DuLich);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiaDiem_DuLichExists(diaDiem_DuLich.dddl_id))
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
            return View(diaDiem_DuLich);
        }

        // GET: DiaDiem_DuLichs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diaDiem_DuLich = await _context.DiaDiem_DuLich
                .FirstOrDefaultAsync(m => m.dddl_id == id);
            if (diaDiem_DuLich == null)
            {
                return NotFound();
            }

            return View(diaDiem_DuLich);
        }

        // POST: DiaDiem_DuLichs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diaDiem_DuLich = await _context.DiaDiem_DuLich.FindAsync(id);
            _context.DiaDiem_DuLich.Remove(diaDiem_DuLich);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiaDiem_DuLichExists(int id)
        {
            return _context.DiaDiem_DuLich.Any(e => e.dddl_id == id);
        }
    }
}
