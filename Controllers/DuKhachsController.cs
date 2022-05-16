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
    public class DuKhachsController : Controller
    {
        private readonly acompec_lvdatContext _context;

        public DuKhachsController(acompec_lvdatContext context)
        {
            _context = context;
        }

        // GET: DuKhachs
        public async Task<IActionResult> Index()
        {
            return View(await _context.DuKhach.ToListAsync());
        }

        // GET: DuKhachs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duKhach = await _context.DuKhach
                .FirstOrDefaultAsync(m => m.dk_id == id);
            if (duKhach == null)
            {
                return NotFound();
            }

            return View(duKhach);
        }

        // GET: DuKhachs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DuKhachs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("dk_id,dk_taikhoan,dk_matkhau,dk_hoten,dk_cmnd,dk_dienthoai,dk_diachi,dk_email,dk_diemthanhvien,bvdd_id,hd_id")] DuKhach duKhach)
        {
            if (ModelState.IsValid)
            {
                _context.Add(duKhach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(duKhach);
        }

        // GET: DuKhachs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            int temp = int.Parse(id);
            if (id == null)
            {
                return NotFound();
            }

            var duKhach = await _context.DuKhach.FindAsync(temp);
            if (duKhach == null)
            {
                return NotFound();
            }
            return View(duKhach);
        }

        // POST: DuKhachs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("dk_id,dk_taikhoan,dk_matkhau,dk_hoten,dk_cmnd,dk_dienthoai,dk_diachi,dk_email,dk_diemthanhvien,bvdd_id,hd_id")] DuKhach duKhach)
        {
            string temp = id.ToString();
            if (id != duKhach.dk_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(duKhach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DuKhachExists(duKhach.dk_id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return  RedirectToAction( "Detail_Tourism","LayoutTourism",new {id = int.Parse(temp)});
            }
            return RedirectToAction( "Detail_Tourism","LayoutTourism", id = int.Parse(temp));
        }

        // GET: DuKhachs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duKhach = await _context.DuKhach
                .FirstOrDefaultAsync(m => m.dk_id == id);
            if (duKhach == null)
            {
                return NotFound();
            }

            return View(duKhach);
        }

        // POST: DuKhachs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var duKhach = await _context.DuKhach.FindAsync(id);
            _context.DuKhach.Remove(duKhach);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DuKhachExists(int id)
        {
            return _context.DuKhach.Any(e => e.dk_id == id);
        }
    }
}
