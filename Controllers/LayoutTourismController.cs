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
            var appDBContext = _context.BaiViet_DiaDiem.Include(e=>e.NhanVien).Include(g=>g.DiaDiem_DuLich);
            ViewData["baiViet_goiY"] =appDBContext.ToList();

            return View(baiViet_DiaDiem);
        }
        // public async Task<IActionResult> Index_Destination()
        // {
        //      var acompec_lvdatContext = _context.Hinh_DiaDiemDuLich.Include(m=>m.DiaDiem_DuLich);
        //     return View(await acompec_lvdatContext.ToArrayAsync());
        // }
    
        public async Task<IActionResult> Index_Destination(string id)
        {
            var acompec_lvdatContext = _context.DiaDiem_DuLich.Where(n=>n.dddl_tinhthanh==id);
            
            ViewData["TP"] = id.ToString();
            return View(await acompec_lvdatContext.ToListAsync());
        }

        public async Task<IActionResult> Index_Service_Destination(string city, string services)
        {
            var acompec_lvdatContext = _context.DichVu.Include(m=>m.loaiDichVu).Where(c=>c.dv_tinhthanh == city);
            var LinqVal_acompec_lvdatContext = acompec_lvdatContext.Where(e=>e.loaiDichVu.ldv_ten == services);
            ViewData["TP"] = city.ToString();
            ViewData["DV"] = services.ToString();
            return View(await LinqVal_acompec_lvdatContext.ToArrayAsync());
        }
        
        public async Task<IActionResult> Details_Destination(int? id)
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
        //id dịch vụ
        public async Task<IActionResult> Details_Service(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dichVu = await _context.DichVu
                .FirstOrDefaultAsync(m => m.dv_id == id);
            if (dichVu == null)
            {
                return NotFound();
            }
             ViewData["Ten_DV"] = dichVu.dv_ten.FirstOrDefault(m => m == id);
            
            return View(dichVu);
        }
        //Thoong tin du khách search bằng id session du khách
        public async Task<IActionResult> Detail_Tourism(string id)
        {
            int temp = int.Parse(id);

            var duKhach = await _context.DuKhach
                .FirstOrDefaultAsync(m => m.dk_id == temp);
            if (duKhach == null)
            {
                return NotFound();
            }

            return View(duKhach);

            
        }
    }
}
