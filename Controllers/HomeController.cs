using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LV_DuLichDienTu.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.AspNetCore.Http;

namespace LV_DuLichDienTu.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            
            return RedirectToAction("Details","NhanViens", new {@id = HttpContext.Session.GetString("userID")});
        }
        public IActionResult Index_business()
        {
            
            return RedirectToAction("Details","NhaCungCaps", new {@id = HttpContext.Session.GetString("userID")});
        }

        


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
