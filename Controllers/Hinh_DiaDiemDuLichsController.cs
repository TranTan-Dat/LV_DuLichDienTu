using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LV_DuLichDienTu.Models;
using System.IO;
using Microsoft.AspNetCore.Http;


namespace LV_DuLichDienTu.Controllers
{
    public class Hinh_DiaDiemDuLichsController : Controller
    {
        private readonly acompec_lvdatContext _context;

        public Hinh_DiaDiemDuLichsController(acompec_lvdatContext context)
        {
            _context = context;
        }

        // GET: Hinh_DiaDiemDuLichs
        public async Task<IActionResult> Index()
        {
            var acompec_lvdatContext = _context.Hinh_DiaDiemDuLich.Include(h => h.DiaDiem_DuLich);
            return View(await acompec_lvdatContext.ToListAsync());
        }

        // GET: Hinh_DiaDiemDuLichs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hinh_DiaDiemDuLich = await _context.Hinh_DiaDiemDuLich
                .Include(h => h.DiaDiem_DuLich)
                .FirstOrDefaultAsync(m => m.hinh_id == id);
            if (hinh_DiaDiemDuLich == null)
            {
                return NotFound();
            }

            return View(hinh_DiaDiemDuLich);
        }

        // GET: Hinh_DiaDiemDuLichs/Create
        public IActionResult Create()
        {
            ViewData["dddl_ten"] = new SelectList(_context.DiaDiem_DuLich, "dddl_id", "dddl_ten");
            return View();
        }

        // POST: Hinh_DiaDiemDuLichs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("hinh_id,hinh_duongdan,dddl_id")] Hinh_DiaDiemDuLich hinh_DiaDiemDuLich, IFormFile imageUpload)
        {
            if (ModelState.IsValid)
            {
                var saveimg =  Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","Image",imageUpload.FileName);
                var stream = new FileStream(saveimg,FileMode.Create);
                await imageUpload.CopyToAsync(stream);
                
                string[] tempCutSpilt = saveimg.Split('\\');
                string ImgURL = "/"+tempCutSpilt[tempCutSpilt.Length-2]+"/"+tempCutSpilt[tempCutSpilt.Length-1];
                hinh_DiaDiemDuLich.hinh_duongdan = ImgURL;

                _context.Add(hinh_DiaDiemDuLich);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index","hinh_DiaDiemDuLichs");
            }
            ViewData["dddl_ten"] = new SelectList(_context.DiaDiem_DuLich, "dddl_id", "dddl_ten", hinh_DiaDiemDuLich.dddl_id);
            return View(hinh_DiaDiemDuLich);
        }

        // GET: Hinh_DiaDiemDuLichs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hinh_DiaDiemDuLich = await _context.Hinh_DiaDiemDuLich.FindAsync(id);
            if (hinh_DiaDiemDuLich == null)
            {
                return NotFound();
            }
            ViewData["dddl_ten"] = new SelectList(_context.DiaDiem_DuLich, "dddl_id", "dddl_ten", hinh_DiaDiemDuLich.dddl_id);
            return View(hinh_DiaDiemDuLich);
        }

        // POST: Hinh_DiaDiemDuLichs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("hinh_id,hinh_duongdan,dddl_id")] Hinh_DiaDiemDuLich hinh_DiaDiemDuLich)
        {
            if (id != hinh_DiaDiemDuLich.hinh_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hinh_DiaDiemDuLich);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Hinh_DiaDiemDuLichExists(hinh_DiaDiemDuLich.hinh_id))
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
            ViewData["dddl_ten"] = new SelectList(_context.DiaDiem_DuLich, "dddl_id", "dddl_ten", hinh_DiaDiemDuLich.dddl_id);
            return View(hinh_DiaDiemDuLich);
        }

        // GET: Hinh_DiaDiemDuLichs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hinh_DiaDiemDuLich = await _context.Hinh_DiaDiemDuLich
                .Include(h => h.DiaDiem_DuLich)
                .FirstOrDefaultAsync(m => m.hinh_id == id);
            if (hinh_DiaDiemDuLich == null)
            {
                return NotFound();
            }

            return View(hinh_DiaDiemDuLich);
        }

        // POST: Hinh_DiaDiemDuLichs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hinh_DiaDiemDuLich = await _context.Hinh_DiaDiemDuLich.FindAsync(id);
            _context.Hinh_DiaDiemDuLich.Remove(hinh_DiaDiemDuLich);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Hinh_DiaDiemDuLichExists(int id)
        {
            return _context.Hinh_DiaDiemDuLich.Any(e => e.hinh_id == id);
        }
    }
}
