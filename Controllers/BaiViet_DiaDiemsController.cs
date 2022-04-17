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
    public class BaiViet_DiaDiemsController : Controller
    {
        private readonly acompec_lvdatContext _context;

        public BaiViet_DiaDiemsController(acompec_lvdatContext context)
        {
            _context = context;
        }

        // GET: BaiViet_DiaDiems
        public async Task<IActionResult> Index()
        {
            var appDBContext = _context.BaiViet_DiaDiem.Include(e=>e.NhanVien).Include(g=>g.DiaDiem_DuLich);
            return View(await appDBContext.ToListAsync());
        //    return View(await _context.BaiViet_DiaDiem.ToListAsync());
        }

        // GET: BaiViet_DiaDiems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baiViet_DiaDiem = await _context.BaiViet_DiaDiem
                .FirstOrDefaultAsync(m => m.bvdd_id == id);
            if (baiViet_DiaDiem == null)
            {
                return NotFound();
            }

            return View(baiViet_DiaDiem);
        }

        // GET: BaiViet_DiaDiems/Create
        public IActionResult Create()
        {
            ViewData["select_Hoten_NV"] = new SelectList(_context.NhanVien,"nv_id","nv_hoten");
            ViewData["select_Ten_DD"] = new SelectList(_context.DiaDiem_DuLich,"dddl_id","dddl_ten");
            return View();
        }

        // POST: BaiViet_DiaDiems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("bvdd_id,bvdd_tieude,bvdd_noidung,bvdd_tinhtrang,dddl_id,nv_id,dk_id")] BaiViet_DiaDiem baiViet_DiaDiem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baiViet_DiaDiem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(baiViet_DiaDiem);
        }

        // GET: BaiViet_DiaDiems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baiViet_DiaDiem = await _context.BaiViet_DiaDiem.FindAsync(id);
            if (baiViet_DiaDiem == null)
            {
                return NotFound();
            }
            ViewData["ReturnMA"] = baiViet_DiaDiem.bvdd_tinhtrang;
            ViewData["select_Hoten_NV"] = new SelectList(_context.NhanVien,"nv_id","nv_hoten");
            ViewData["select_Ten_DD"] = new SelectList(_context.DiaDiem_DuLich,"dddl_id","dddl_ten");
            return View(baiViet_DiaDiem);
        }

        // POST: BaiViet_DiaDiems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("bvdd_id,bvdd_tieude,bvdd_noidung,bvdd_tinhtrang,dddl_id,nv_id,dk_id")] BaiViet_DiaDiem baiViet_DiaDiem)
        {
            if (id != baiViet_DiaDiem.bvdd_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baiViet_DiaDiem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaiViet_DiaDiemExists(baiViet_DiaDiem.bvdd_id))
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
            
            return View(baiViet_DiaDiem);
        }

        // GET: BaiViet_DiaDiems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baiViet_DiaDiem = await _context.BaiViet_DiaDiem
                .FirstOrDefaultAsync(m => m.bvdd_id == id);
            if (baiViet_DiaDiem == null)
            {
                return NotFound();
            }
            var appDBContext =  _context.BaiViet_DiaDiem.Include(e=>e.NhanVien).Include(g=>g.DiaDiem_DuLich);
            return View(baiViet_DiaDiem);
        }

        // POST: BaiViet_DiaDiems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var baiViet_DiaDiem = await _context.BaiViet_DiaDiem.FindAsync(id);
            _context.BaiViet_DiaDiem.Remove(baiViet_DiaDiem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaiViet_DiaDiemExists(int id)
        {
            return _context.BaiViet_DiaDiem.Any(e => e.bvdd_id == id);
        }
    }
}
