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
    public class DichVusController : Controller
    {
        private readonly acompec_lvdatContext _context;

        public DichVusController(acompec_lvdatContext context)
        {
            _context = context;
        }

        // GET: DichVus
        public async Task<IActionResult> Index(int?id)
        {
            var acompec_lvdatContext = _context.DichVu.Include(d => d.loaiDichVu).Include(e => e.nhaCungCap).Where(x=>x.ncc_id==id);
            return View(await acompec_lvdatContext.ToListAsync());
        }

        public async Task<IActionResult> List_By_ID(int?id)
        {
            var acompec_lvdatContext = _context.DichVu.Include(h => h.nhaCungCap).Include(d => d.loaiDichVu).Where(x=>x.ncc_id==id);
           
            return View(await acompec_lvdatContext.ToListAsync());
        }

        // GET: DichVus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dichVu = await _context.DichVu
                .Include(d => d.loaiDichVu)
                .Include(d => d.nhaCungCap)
                .FirstOrDefaultAsync(m => m.dv_id == id);
            if (dichVu == null)
            {
                return NotFound();
            }

            return View(dichVu);
        }

        // GET: DichVus/Create
        public IActionResult Create(int id)
        {
            ViewData["Select_TenNCC"]= new SelectList(_context.NhaCungCap.Where(m=>m.ncc_id==id),"ncc_id","ncc_ten");
            ViewData["Select_TenLoaiDV"]= new SelectList(_context.LoaiDichVu,"ldv_id","ldv_ten");
            return View();
        }

        // POST: DichVus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("dv_id,dv_ten,dv_dienthoai_hotro,dv_hinh_duongdan,dv_tieude,dv_tinhthanh,dv_quanhuyen,dv_mota,ckdv_id,ncc_id,ldv_id,hd_id")] DichVu dichVu, IFormFile imageUpload)
        {
            if (ModelState.IsValid)
            {
                var saveimg =  Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","Image",imageUpload.FileName);
                var stream = new FileStream(saveimg,FileMode.Create);
                await imageUpload.CopyToAsync(stream);
                
                string[] tempCutSpilt = saveimg.Split('\\');
                string ImgURL = "/"+tempCutSpilt[tempCutSpilt.Length-2]+"/"+tempCutSpilt[tempCutSpilt.Length-1];
                dichVu.dv_hinh_duongdan = ImgURL;
                
                dichVu.dv_trungbinhchatluong =0;
                _context.Add(dichVu);
                await _context.SaveChangesAsync();
                return RedirectToAction("List_By_ID","DichVus", new{id = dichVu.ncc_id});
            }
            ViewData["Select_TenNCC"]= new SelectList(_context.NhaCungCap,"ncc_id","ncc_ten");
            ViewData["Select_TenLoaiDV"]= new SelectList(_context.LoaiDichVu,"ldv_id","ldv_ten");
            return View(dichVu);
        }

        // GET: DichVus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dichVu = await _context.DichVu.FindAsync(id);
            if (dichVu == null)
            {
                return NotFound();
            }
            ViewData["Select_TenNCC"]= new SelectList(_context.NhaCungCap,"ncc_id","ncc_ten");
            ViewData["Select_TenLoaiDV"]= new SelectList(_context.LoaiDichVu,"ldv_id","ldv_ten");
            return View(dichVu);
        }

        // POST: DichVus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("dv_id,dv_ten,dv_dienthoai_hotro,dv_hinh_duongdan,dv_tieude,dv_tinhthanh,dv_quanhuyen,dv_mota,ckdv_id,ncc_id,ldv_id,hd_id")] DichVu dichVu, IFormFile imageUpload)
        {
            if (id != dichVu.dv_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var saveimg =  Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","Image",imageUpload.FileName);
                    var stream = new FileStream(saveimg,FileMode.Create);
                    await imageUpload.CopyToAsync(stream);
                    
                    string[] tempCutSpilt = saveimg.Split('\\');
                    string ImgURL = "/"+tempCutSpilt[tempCutSpilt.Length-2]+"/"+tempCutSpilt[tempCutSpilt.Length-1];
                    dichVu.dv_hinh_duongdan = ImgURL;

                    _context.Update(dichVu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DichVuExists(dichVu.dv_id))
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
            ViewData["Select_TenNCC"]= new SelectList(_context.NhaCungCap,"ncc_id","ncc_ten");
            ViewData["Select_TenLoaiDV"]= new SelectList(_context.LoaiDichVu,"ldv_id","ldv_ten");
            return View(dichVu);
        }

        // GET: DichVus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dichVu = await _context.DichVu
                .Include(d => d.loaiDichVu)
                .Include(d => d.nhaCungCap)
                .FirstOrDefaultAsync(m => m.dv_id == id);
            if (dichVu == null)
            {
                return NotFound();
            }

            return View(dichVu);
        }

        // POST: DichVus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dichVu = await _context.DichVu.FindAsync(id);
            int temp = dichVu.ncc_id;
            _context.DichVu.Remove(dichVu);
            await _context.SaveChangesAsync();
            return RedirectToAction("List_By_ID", new {id = temp});
        }

        private bool DichVuExists(int id)
        {
            return _context.DichVu.Any(e => e.dv_id == id);
        }
    }
}
