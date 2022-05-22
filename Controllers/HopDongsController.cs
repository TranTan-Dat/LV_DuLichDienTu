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
    public class HopDongsController : Controller
    {
        private readonly acompec_lvdatContext _context;

        public HopDongsController(acompec_lvdatContext context)
        {
            _context = context;
        }

        // GET: HopDongs
        public async Task<IActionResult> Index()
        {
            var acompec_lvdatContext = _context.HopDong.Include(h => h.dichVu).Include(h => h.duKhach);
           
            return View(await acompec_lvdatContext.ToListAsync());
        }
        public async Task<IActionResult> List_By_ID(int?id)
        {
            var acompec_lvdatContext = _context.HopDong.Include(h => h.dichVu).Include(h => h.duKhach).Where(x=>x.dichVu.ncc_id==id);
           
            return View(await acompec_lvdatContext.ToListAsync());
        }


        // GET: HopDongs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hopDong = await _context.HopDong
                .Include(h => h.dichVu)
                .Include(h => h.duKhach)
                .FirstOrDefaultAsync(m => m.hd_id == id);
            if (hopDong == null)
            {
                return NotFound();
            }

            return View(hopDong);
        }

        // GET: HopDongs/Create
        public IActionResult Create(int service, int id)
        {

            ViewData["dv_ten"] = new SelectList(_context.DichVu.Where(m=>m.dv_id==service), "dv_id", "dv_ten");
            ViewData["dk_hoten"] = new SelectList(_context.DuKhach.Where(n=>n.dk_id ==id), "dk_id", "dk_hoten");
            
            return View();
        }

        // POST: HopDongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("hd_id,hd_ngaybatdau,hd_ngayketthuc,hd_chiphi,hd_danhgiachatluong,hd_phanhoi,dk_id,dv_id")] HopDong hopDong)
        {
                string idDuKhach = hopDong.dk_id.ToString();
            if (ModelState.IsValid)
            {
                _context.Add(hopDong);
                await _context.SaveChangesAsync();
                return RedirectToAction("TravellingSchedule","HopDongs",new{id = idDuKhach});
            }
            ViewData["dv_id"] = new SelectList(_context.DichVu, "dv_id", "dv_id", hopDong.dv_id);
            ViewData["dk_id"] = new SelectList(_context.DuKhach, "dk_id", "dk_id", hopDong.dk_id);
            return RedirectToAction("TravellingSchedule","HopDongs",new{id = idDuKhach});
        }

        // GET: HopDongs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hopDong = await _context.HopDong.FindAsync(id);
            if (hopDong == null)
            {
                return NotFound();
            }
            ViewData["dv_ten"] = new SelectList(_context.DichVu, "dv_id", "dv_ten", hopDong.dv_id);
            ViewData["dk_hoten"] = new SelectList(_context.DuKhach, "dk_id", "dk_hoten", hopDong.dk_id);
            return View(hopDong);
        }

        // POST: HopDongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("hd_id,hd_ngaybatdau,hd_ngayketthuc,hd_chiphi,hd_danhgiachatluong,hd_phanhoi,dk_id,dv_id")] HopDong hopDong)
        {
            if (id != hopDong.hd_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hopDong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HopDongExists(hopDong.hd_id))
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
            ViewData["dv_id"] = new SelectList(_context.DichVu, "dv_id", "dv_id", hopDong.dv_id);
            ViewData["dk_id"] = new SelectList(_context.DuKhach, "dk_id", "dk_id", hopDong.dk_id);
            return View(hopDong);
        }

        // GET: HopDongs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hopDong = await _context.HopDong
                .Include(h => h.dichVu)
                .Include(h => h.duKhach)
                .FirstOrDefaultAsync(m => m.hd_id == id);
            if (hopDong == null)
            {
                return NotFound();
            }

            return View(hopDong);
        }

        // POST: HopDongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hopDong = await _context.HopDong.FindAsync(id);
            _context.HopDong.Remove(hopDong);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HopDongExists(int id)
        {
            return _context.HopDong.Any(e => e.hd_id == id);
        }
        public async Task<IActionResult> TravellingSchedule(string id)
        {
            int ID = int.Parse(id);
            var acompec_lvdatContext = _context.HopDong.Include(h => h.dichVu).Include(h => h.duKhach).Where(m=>m.dk_id==ID).OrderBy(m=>m.hd_ngaybatdau);
            return View(await acompec_lvdatContext.ToListAsync());
        }

        [HttpPost]
        //id là id dung khách, rating => điểm đánh giá từ 1 đến 5, id hợp đồng để cho update
        public async Task<IActionResult> Updaterating(double stars,  int hdid, int dvid, string userID)
        {
            HopDong hopDong = _context.HopDong.Single(m=>m.hd_id == hdid);
            hopDong.hd_danhgiachatluong = stars;
            await _context.SaveChangesAsync();


            // cập nhật lại trung bình đánh giá chất lượng
            double SumStart_In_HD = _context.HopDong.Where(m=>m.dv_id==dvid&&m.hd_danhgiachatluong >0).Sum(c=>c.hd_danhgiachatluong);
            int Count_HD_Voted = _context.HopDong.Where(m=>m.dv_id==dvid&&m.hd_danhgiachatluong>0).Count();

            DichVu dichVu = _context.DichVu.Single(q=>q.dv_id==dvid);
            dichVu.dv_trungbinhchatluong = SumStart_In_HD/Count_HD_Voted;
            await _context.SaveChangesAsync();
            
            return RedirectToAction("TravellingSchedule","HopDongs",new{id = int.Parse(userID)});
        }

        // Hàm trả về trung bình điểm đánh giá 
        // public  IActionResult AvgRating(int id)
        // {
            
        //     var Sum = (from HD in _context.HopDong where HD.hd_danhgiachatluong!=0 && HD.hd_id==id select HD.hd_danhgiachatluong).Average();
        //     TempData["sumRating"] = Sum;
        //     return View();
        // }
    }
}
