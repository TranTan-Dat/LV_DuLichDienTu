using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Data;
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
        [HttpPost]
        public ActionResult Admin_Login(string email, string password)
        {
            var userDetails = _context.NhanVien.Where( x => x.nv_email == email && x.nv_matKhau == password).FirstOrDefault();
            if(userDetails == null)
            {
                    ViewBag.error = "Invalid Account";
                    return View("Index");
            }
            else
            {
                HttpContext.Session.SetString("userName", userDetails.nv_email);
                HttpContext.Session.SetString("userID", userDetails.nv_id.ToString());
                HttpContext.Session.SetString("Type_role", "NhanVien");
                return RedirectToAction("Index","Home");
            }
        }
        //login form du khachs
        [HttpPost]
        public ActionResult Tourism_login(string email, string password)
        {
            var userDetails = _context.DuKhach.Where( x => x.dk_email == email && x.dk_matkhau == password).FirstOrDefault();
            if(userDetails == null)
            {
                    ViewBag.error = "Invalid Account";
                    return View("Index");
            }
            else
            {
                HttpContext.Session.SetString("userName", userDetails.dk_email);
                HttpContext.Session.SetString("userID", userDetails.dk_id.ToString());
                HttpContext.Session.SetString("Type_role", "DuKhach");
                return RedirectToAction("Index_Home","LayoutTourism");
            }
        }
        //login form ncc
        [HttpPost]
        public ActionResult Business_login(string email, string password)
        {
            var userDetails = _context.NhaCungCap.Where( x => x.ncc_email == email && x.ncc_matkhau == password).FirstOrDefault();
            if(userDetails == null)
            {
                    ViewBag.error = "Invalid Account";
                    return View("Index");
            }
            else
            {
                HttpContext.Session.SetString("userName", userDetails.ncc_email);
                HttpContext.Session.SetString("userID", userDetails.ncc_id.ToString());
                
                HttpContext.Session.SetString("Type_role", "NhaCungCap");
                return RedirectToAction("Index_business","Home");
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("userName");
            HttpContext.Session.Remove("userID");
            return RedirectToAction("Index", "Login");
        }
    }
}
