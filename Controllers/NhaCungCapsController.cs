using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LV_DuLichDienTu.Models;
using System.Data;
using Microsoft.AspNetCore.Http;


namespace LV_DuLichDienTu.Controllers
{
    public class NhaCungCapsController : Controller
    {
        private readonly acompec_lvdatContext _context;

        public NhaCungCapsController(acompec_lvdatContext context)
        {
            _context = context;
        }

        // GET: NhaCungCaps
        public async Task<IActionResult> Index()
        {
            return View(await _context.NhaCungCap.ToListAsync());
        }

        // GET: NhaCungCaps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhaCungCap = await _context.NhaCungCap
                .FirstOrDefaultAsync(m => m.ncc_id == id);
            if (nhaCungCap == null)
            {
                return NotFound();
            }

            return View(nhaCungCap);
        }

        // GET: NhaCungCaps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NhaCungCaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ncc_id,ncc_taikhoan,ncc_matkhau,ncc_ten,ncc_email,ncc_dienthoai,ncc_diachi,dv_id")] NhaCungCap nhaCungCap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhaCungCap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            if (HttpContext.Session.GetString("Type_role")=="NhanVien")
            {
                return View(nhaCungCap);
            }
            else{
                return RedirectToAction("Index_business","Home");
            }
            
        }

        // GET: NhaCungCaps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhaCungCap = await _context.NhaCungCap.FindAsync(id);
            if (nhaCungCap == null)
            {
                return NotFound();
            }
            return View(nhaCungCap);
        }

        // POST: NhaCungCaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ncc_id,ncc_taikhoan,ncc_matkhau,ncc_ten,ncc_email,ncc_dienthoai,ncc_diachi,dv_id")] NhaCungCap nhaCungCap)
        {
            if (id != nhaCungCap.ncc_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhaCungCap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhaCungCapExists(nhaCungCap.ncc_id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details","NhaCungCaps", new{id = nhaCungCap.ncc_id});
            }
            return RedirectToAction("Details","NhaCungCaps", new{id = nhaCungCap.ncc_id});
        }

        // GET: NhaCungCaps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhaCungCap = await _context.NhaCungCap
                .FirstOrDefaultAsync(m => m.ncc_id == id);
            if (nhaCungCap == null)
            {
                return NotFound();
            }

            return View(nhaCungCap);
        }

        // POST: NhaCungCaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhaCungCap = await _context.NhaCungCap.FindAsync(id);
            _context.NhaCungCap.Remove(nhaCungCap);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhaCungCapExists(int id)
        {
            return _context.NhaCungCap.Any(e => e.ncc_id == id);
        }
    }
}
