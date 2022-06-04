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
using Cotur.DataMining;
using Cotur.DataMining.Association;

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
            // // -----------Lấy ra tập D và I cho luật kết hợp-------------
            // // đếm ra số du khách lên lịch trình
            // int count_DKID = (from item in _context.HopDong
            //             select item.dk_id).Distinct().Count();
            // //list lưu id dk
            // List<int> List_IDDK = new List<int>(count_DKID);
            // foreach (var item in _context.HopDong)
            // {
            //     bool ContainInList = List_IDDK.Contains(item.dk_id);
            //     if (ContainInList == false)
            //     {
            //         List_IDDK.Add(item.dk_id);
            //     }
            // }
            
            // //LIST ITEM TỪ TRANSACTION
            // List<string> List_Item = new List<string> ();


            // // tạo một mảng 2 chiều cột đầu lưu id_dk, cột sau lưu iddv
            // string[,] TempArray = new string[List_IDDK.Count(),2];
            // for (int i = 0; i<  List_IDDK.Count();i++)
            // {string chuoidulieu = "";
            //     // TempArray[i,0] = List_IDDK[i];
            //     // TempArray[i,1] = 0;
            //     var dataIDKH = _context.HopDong.Where(h => h.duKhach.dk_id == List_IDDK[i]).ToList();
            
            //     foreach(var item2 in dataIDKH)
            //     {
            //         string temp = item2.dv_id.ToString();
            //         bool ContainORNoT = chuoidulieu.Contains(temp);
            //         if(ContainORNoT==false)
            //         {
            //             chuoidulieu = chuoidulieu+temp+' ';
            //         }

            //         //add các Item vào itemlist
            //         bool ItemInList = List_Item.Contains(temp);
            //         if(ItemInList == false)
            //         {
            //             List_Item.Add(temp);
            //         }

            //     }
            //     chuoidulieu = chuoidulieu.TrimEnd(' ');
            //     TempArray[i,0]= List_IDDK[i].ToString();
            //     TempArray[  i,1]=chuoidulieu;
            // }

            // //TRANSACTION D
            // //tạo một list lưu id dv theo id dk, list này có độ dài bằng list id du khách (dùng count)
            // List<string> List_Transaction_IDDV_ByIDDK = new List<string>(List_IDDK.Count());
            // for (var i = 0; i < List_IDDK.Count(); i++)
            // {
            //     List_Transaction_IDDV_ByIDDK.Add(TempArray[ i,1]);
            // }
            
            

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


        //register for tourism and provider
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create_tourism([Bind("dk_id,dk_taikhoan,dk_matkhau,dk_hoten,dk_cmnd,dk_dienthoai,dk_diachi,dk_email,dk_diemthanhvien,bvdd_id,hd_id")] DuKhach duKhach, string email, string password)
        {
            if (ModelState.IsValid)
            {
                duKhach.dk_email= email;
                duKhach.dk_matkhau = password;
                _context.Add(duKhach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create_Business([Bind("ncc_id,ncc_taikhoan,ncc_matkhau,ncc_ten,ncc_email,ncc_dienthoai,ncc_diachi,dv_id")] NhaCungCap nhaCungCap, string email, string password)
        {
            if (ModelState.IsValid)
            {
                nhaCungCap.ncc_email= email;
                nhaCungCap.ncc_matkhau = password;
                _context.Add(nhaCungCap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return RedirectToAction("Index", "Login");
        }
    }
}
