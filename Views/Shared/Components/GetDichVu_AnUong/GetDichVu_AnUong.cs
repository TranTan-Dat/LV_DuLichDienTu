using System.Net;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LV_DuLichDienTu.Models;
using Microsoft.AspNetCore.Http;
namespace LV_DuLichDienTu.Views.Shared.Components
{
    public class GetDichVu_AnUong : ViewComponent
    {
        private readonly acompec_lvdatContext _context;

        public GetDichVu_AnUong(acompec_lvdatContext context)
        {
            _context = context;
        }
        //id loại dịch vụ ăn uống là 5 => truy vấn tỉnh thành và id loại dịch vụ 
        public async Task<IViewComponentResult> InvokeAsync(string DiaDiem)
        {   
            var result = await _context.DichVu.Include(e=>e.loaiDichVu).Where(m => m.dv_tinhthanh == DiaDiem && m.loaiDichVu.ldv_id==5).ToListAsync();
            return View<List<DichVu>>(result);
        }
    }

}