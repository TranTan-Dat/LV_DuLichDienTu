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
            Take_Items_AndD_Transaction();
            return View(await acompec_lvdatContext.ToListAsync());
        }

        public void Take_Items_AndD_Transaction()
        {

            // -----------Lấy ra tập D và I cho luật kết hợp-------------
            // đếm ra số du khách lên lịch trình
            int count_DKID = (from item in _context.HopDong
                        select item.dk_id).Distinct().Count();
            //list lưu id dk
            List<int> List_IDDK = new List<int>(count_DKID);
            foreach (var item in _context.HopDong)
            {
                bool ContainInList = List_IDDK.Contains(item.dk_id);
                if (ContainInList == false)
                {
                    List_IDDK.Add(item.dk_id);
                }
            }
            
            //LIST ITEM TỪ TRANSACTION
            List<string> List_Item = new List<string> ();


            // tạo một mảng 2 chiều cột đầu lưu id_dk, cột sau lưu iddv
            string[,] TempArray = new string[List_IDDK.Count(),2];
            for (int i = 0; i<  List_IDDK.Count();i++)
            {string chuoidulieu = "";
                // TempArray[i,0] = List_IDDK[i];
                // TempArray[i,1] = 0;
                var dataIDKH = _context.HopDong.Where(h => h.duKhach.dk_id == List_IDDK[i]).ToList();
            
                foreach(var item2 in dataIDKH)
                {
                    string temp = item2.dv_id.ToString();
                    bool ContainORNoT = chuoidulieu.Contains(temp);
                    if(ContainORNoT==false)
                    {
                        chuoidulieu = chuoidulieu+temp+' ';
                    }

                    //add các Item vào itemlist
                    bool ItemInList = List_Item.Contains(temp);
                    if(ItemInList == false)
                    {
                        List_Item.Add(temp);
                    }

                }
                chuoidulieu = chuoidulieu.TrimEnd(' ');
                TempArray[i,0]= List_IDDK[i].ToString();
                TempArray[  i,1]=chuoidulieu;
            }

            //TRANSACTION D
            //tạo một list lưu id dv theo id dk, list này có độ dài bằng list id du khách (dùng count)
            List<string> List_Transaction_IDDV_ByIDDK = new List<string>(List_IDDK.Count());
            for (var i = 0; i < List_IDDK.Count(); i++)
            {
                List_Transaction_IDDV_ByIDDK.Add(TempArray[ i,1]);
            }
            




            
            ////////Bắt đầu tính luật kết hợp//////////
            // Tập D theo K



            List<string> DTheoK = new List<string>();
            //cho biến Temp để cộng tập itemset vào một chuỗi
            string TempForSubStr="";
            foreach (var item in List_Item)
            {
                TempForSubStr+=item+" ";
            }
            TempForSubStr=TempForSubStr.Trim();
            // add temp vào tập để có chuỗi itemset
            DTheoK.Add(TempForSubStr);

            List<string> TempItem_plit = new List<string>();
            TempItem_plit = DTheoK;
            string Str_DTheoK="";
            bool gitri = true;
            List<string> ReturnValK = new List<string>();
            List<string>  Str_DTheoK_sPlit= new List<string>();
             
            for (int i = 1; i < 7; i++)
            {
                //lần đầu tiên lưu lại những ItemSet để dùng cho luật kết hợp, những lần sau gitri = false k gán bằng giá trị này được nữa
                if (gitri ==true)
                {
                      Str_DTheoK = TempItem_plit[i-1];
                      Str_DTheoK_sPlit = Str_DTheoK.Split(' ').ToList();
                    gitri = false;
                }
                
                //cắt từ chuỗi ra nhiều phần tử => Str_DTheoK_sPlitl kiểu list
                //cho ReturnValK = rỗng để nạp lại phần tử kết hợp
                 ReturnValK = new List<string>();

                for (int x = 0; x < Str_DTheoK_sPlit.Count(); x++)
                {
                    
                    //cho x,y là phần tử 1 và 2 liền kề nhân nhau, vòng lặp dừng khi x tới length - 1
                    if (x == Str_DTheoK_sPlit.Count()-1)
                        {
                            break;
                        }
                    for (int y = x+1; y < Str_DTheoK_sPlit.Count(); y++)
                    {var substring="";
                        List<string> Val1 = new List<string>();
                        List<string>  Val2 = new List<string>();

                        //Val1.Add(Str_DTheoK_sPlit[x]);
                        // Val2.Add(Str_DTheoK_sPlit[y]);

                        Val1 = Str_DTheoK_sPlit[x].Split(' ').ToList();
                        Val2 = Str_DTheoK_sPlit[y].Split(' ').ToList();
                        var union = Val1.Union(Val2);
                        
                        foreach (var j in union)
                        {
                            substring = substring+ j + " ";
                            
                        }
                        substring = substring.Trim();
                        List<string> check = substring.Split(' ').ToList();
                        check.Count();
                        if (checkContain(substring, ReturnValK) == false)
                        {
                            if (check.Count()==i+1 )
                            {
                                Console.WriteLine(substring);
                                ReturnValK.Add(substring);

                            }
                            
                        }
                    }
                    TempItem_plit = ReturnValK;
                    // lấy tập temitem_split để tính độ sub, kiểm tra sub so sánh min sub để loại ra
                }
                //Tạo 1 list lưu trữ item có sup >=3
                string jádasd ="";
                for (int g = 0; g < TempItem_plit.Count(); g++)
                {
                    int MINSUP = 1;// gán cứng bằng 3, những phần tử nào dưới 3 sẽ bị loại
                    if (Return_Sup(TempItem_plit[g], List_Transaction_IDDV_ByIDDK)< MINSUP)
                    {
                        TempItem_plit.RemoveAt(g);
                        g = g -1  ;
                    }
                }
                ///đang tính khúc này
                Str_DTheoK_sPlit = TempItem_plit;
                //Min sub =1, K = 7 là max => không thể kết hợp ra hàm bên dưới
                // if (Str_DTheoK_sPlit.Count()==1)
                // {
                //     break;
                // }
            }
            



            // Trả về list những phần tử có sub>minsub & conf > minConf
            //List<string> checkVal = new List<string>(ThuatToanSinhLuat(Str_DTheoK_sPlit,List_Transaction_IDDV_ByIDDK));
            

            //Cần sửa lưu tập luật 
            
            // List<string> checkVal = new List<string>();
            // for (var i = 0; i < Str_DTheoK_sPlit.Count(); i++)
            // {
            //     checkVal.Add(ThuatToanSinhLuat(Str_DTheoK_sPlit[i],List_Transaction_IDDV_ByIDDK).ToList());
            //     checkVal= checkVal+ThuatToanSinhLuat(Str_DTheoK_sPlit[i],List_Transaction_IDDV_ByIDDK) ;
            // }
            
        }

        public static bool checkContain(string sub, List<string> ReTurnVal)
        {
            bool checkContain = false;
            int count = 0;
            //tách sub ra thành list nhiều phần tử
            List<string> Ptu_Sub = sub.Split(' ').ToList();
            //Duyệt trong List return 
            for (int i = 0; i < ReTurnVal.Count; i++)
            {   count = 0;
                //tách phẩn tử list return ra nhỏ hơn
                //List<string> Ptu_ReturnVal = ReTurnVal[i].Split(' ').ToList();
                //kiểm tra phẩn tử sub nếu có trong phần tử list ReturnVal => count +1
                for (int j = 0; j < Ptu_Sub.Count(); j++)
                {
                     bool check = ReTurnVal[i].Contains(Ptu_Sub[j]);
                        if (check == true)
                        {
                            count++;
                        }
                    
                }
                if (count>= Ptu_Sub.Count())
                {
                    checkContain = true;
                }
            }
            
            return checkContain;
        }

        static int Return_Sup(string Item, List<string> D)
        {
            
            int sub = 0, DLenght = D.Count;

            string[] TempItem_plit = Item.Split(' ');
            int rangeOf_ItemPlit = TempItem_plit.Length;
             int Count_Check_Contain = 0;
            for (int i = 0; i < DLenght; i++)
            {
                //cắt chuỗi bằng dấu " " (cách)
                //string[] TempTransaction_Plit = D[i].Split(' ');
                Count_Check_Contain = 0;
                    for (int x = 0; x < rangeOf_ItemPlit; x++)
                    {
                        bool check = D[i].Contains(TempItem_plit[x]);
                            if (check == true)
                            {
                                Count_Check_Contain++;
                                    if (Count_Check_Contain == rangeOf_ItemPlit)
                                    {
                                        sub++;
                                    }
                            }                    
                    }
            }
            return sub;
        }

        public static List<string> ThuatToanSinhLuat(string Item_theoK, List<string> D)
        {
            List<string> AprioriVal = new List<string>();
            
            List<string> temp= new List<string>();
            temp.Add(Item_theoK);
            // List<string> temp = Item_theoK[0].Split(" ").ToList();

            // List<string> ReturnValK = Item_theoK;
            List<string> ReturnValK = new List<string>();
            ReturnValK.Add(Item_theoK);
            List<string> val = temp;
            for (int i = 1; i < temp.Count(); i++)
            {
                ReturnValK = new List<string>();
                for (int x = 0; x < temp.Count(); x++)
                {


                    if (x == temp.Count() - 1)
                    {
                        break;
                    }
                    for (int y = x + 1; y < temp.Count(); y++)
                    {
                        var substring = "";
                        List<string> Val1 = new List<string>();
                        List<string> Val2 = new List<string>();

                        //Val1.Add(Str_DTheoK_sPlit[x]);
                        // Val2.Add(Str_DTheoK_sPlit[y]);

                        Val1 = temp[x].Split(' ').ToList();
                        Val2 = temp[y].Split(' ').ToList();
                        var union = Val1.Union(Val2);

                        foreach (var j in union)
                        {
                            substring = substring + j + " ";

                        }
                        substring = substring.Trim();
                        List<string> check = substring.Split(' ').ToList();
                        check.Count();
                        if (checkContain(substring, ReturnValK) == false) 
                        {
                            if (check.Count() - 1 == i)
                            {
                                Console.WriteLine(substring);
                                ReturnValK.Add(substring);
                                val.Add(substring);
                            }

                        }
                    }

                }
                
                
            }
            //Loai Tap ban dau
            val.RemoveAt(val.Count()-1);
            foreach (var item in val)
            {
                Console.WriteLine(item);
            }
            // cho kết hơn giá trị đầu + giá trị cuối
            for (int item = 0; item < val.Count()/2; item++)
            {
                string ItemA = val[item];
                string ItemA_BCD = val[val.Count()-1-item];
                double SupA = Return_Sup(ItemA, D);
                double SupA_BCD= Return_Sup(ItemA_BCD, D);
                double Conf = ( SupA_BCD/ SupA)*100;
                if (Conf >= 70)
                {
                    AprioriVal.Add(ItemA_BCD);
                }
            }

            return AprioriVal;

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
