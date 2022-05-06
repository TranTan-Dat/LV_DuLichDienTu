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
    public class Login : Controller
    {
        private readonly acompec_lvdatContext _context;

        public Login(acompec_lvdatContext context)
        {
            _context = context;
        }

public IActionResult Index()
        {
            return View();
        }
    }
}
