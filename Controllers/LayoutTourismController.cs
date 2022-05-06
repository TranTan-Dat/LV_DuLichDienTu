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
    public class LayoutTourismController : Controller
    {
        private readonly acompec_lvdatContext _context;

        public LayoutTourismController(acompec_lvdatContext context)
        {
            _context = context;
        }

        // GET: NhanViens
        public IActionResult Index()
        {
            return View();
        }

        
    }
}
