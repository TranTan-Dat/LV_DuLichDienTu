using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LV_DuLichDienTu.Models;
using System.Dynamic;

namespace LV_DuLichDienTu.Controllers
{
    public class LayoutTourismController : Controller
    {
        private readonly acompec_lvdatContext _context;

        public LayoutTourismController(acompec_lvdatContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index_Home()
        {
            var appDBContext = _context.BaiViet_DiaDiem.Include(e=>e.NhanVien).Include(g=>g.DiaDiem_DuLich);
            return View(await appDBContext.ToListAsync());
        }

        
        
        public async Task<IActionResult> Index_News(int? id)
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
        // public async Task<IActionResult> Index_Destination()
        // {
        //      var acompec_lvdatContext = _context.Hinh_DiaDiemDuLich.Include(m=>m.DiaDiem_DuLich);
        //     return View(await acompec_lvdatContext.ToArrayAsync());
        // }
    
        public async Task<IActionResult> Index_Destination(string id)
        {
             var acompec_lvdatContext = _context.Hinh_DiaDiemDuLich.Include(m=>m.DiaDiem_DuLich).Where(c=>c.DiaDiem_DuLich.dddl_tinhthanh==id);
            ViewData["TP"] = id.ToString();
            return View(await acompec_lvdatContext.ToArrayAsync());
        }
        public async Task<IActionResult> Index_Service_Destination(string city, string services)
        {
            var acompec_lvdatContext = _context.DichVu.Include(m=>m.loaiDichVu).Where(c=>c.dv_tinhthanh == city);
            var LinqVal_acompec_lvdatContext = acompec_lvdatContext.Where(e=>e.loaiDichVu.ldv_ten == services);
            ViewData["TP"] = city.ToString();
            ViewData["DV"] = services.ToString();
            return View(await LinqVal_acompec_lvdatContext.ToArrayAsync());
        }
        
    }
}
