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
            // ViewData["sdt"] = _context.HopDong.Include(h => h.dichVu).Include(h => h.duKhach).Where(x=>x.dichVu.ncc_id==id).Select(m=>m.duKhach.dk_dienthoai);
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
            // //T???p lu???t k???t h???p tr??? v??? ds g???i ?? ?????a ??i???m ch??a t??nh theo rating
            // List<string> Val_Apriori =  Function_Apriori();
            // List<string> Final_value = new List<string>();
            // for (int i = 0; i < Val_Apriori.Count(); i++)
            // {
            //     bool return_check_rating = Check_Rating_ITEM_IN_Val_Apriori(Val_Apriori[i]);
            //     if (return_check_rating == true)
            //     {
            //         System.Console.WriteLine("Ph???n t??? {0} c?? trung b??nh rating V?????T m???c y??u c???u => ----Nh???n-----",Val_Apriori[i]);
            //         Final_value.Add(Val_Apriori[i]);
            //     }
            //     else
            //     {
            //         System.Console.WriteLine("Ph???n t??? {0} kh??ng ????? trung b??nh rating => LO???I",Val_Apriori[i]);
            //     }
            // }
            // int check = Final_value.Count();
            
            return View(await acompec_lvdatContext.ToListAsync());
        }

        // public bool Check_Rating_ITEM_IN_Val_Apriori(string ele_List_Apriori)
        // {
        //     /*
        //     1. t??? chu???i ?????a ??i???m c???t ra th??nh t???ng ph???n t???
        //     2. truy v???n csdl l???y ra rating c???a c??c ?????a ??i???m
        //     3. t??nh trung b??nh rating c???a chu???i id ?????a ??i???m (n???u avg_rating < 3.5 => lo???i)
        //     */

        //     bool checkHigher = false;
        //     List<string> list_id = ele_List_Apriori.Split(" ").ToList();
        //     double avg_rating = 0;
        //     for (var i = 0; i < list_id.Count(); i++)
        //     {
        //         // var RateIDFromDB= _context.DichVu.Where(h => h.dv_id == int.Parse(list_id[i])).Select(m=>m.dv_trungbinhchatluong);
        //         var RateIDFromDB = from f in _context.DichVu
        //                                 where f.dv_id == int.Parse(list_id[i])
        //                                 select f.dv_trungbinhchatluong;
        //         double returnRateIDFromDB = double.Parse( RateIDFromDB.FirstOrDefault().ToString());
        //         avg_rating+=returnRateIDFromDB;
        //     }
        //     avg_rating = avg_rating/list_id.Count();
        //     if (avg_rating >= 4)
        //     {
        //         checkHigher =true;
        //     }
        //     return checkHigher;
            
        // }

        // public List<string> Function_Apriori()
        // {

        //     // -----------L???y ra t???p D v?? I cho lu???t k???t h???p-------------
        //     // ?????m ra s??? du kh??ch l??n l???ch tr??nh
        //     int count_DKID = (from item in _context.HopDong
        //                 select item.dk_id).Distinct().Count();
        //     //list l??u id dk
        //     List<int> List_IDDK = new List<int>(count_DKID);
        //     foreach (var item in _context.HopDong)
        //     {
        //         bool ContainInList = List_IDDK.Contains(item.dk_id);
        //         if (ContainInList == false)
        //         {
        //             List_IDDK.Add(item.dk_id);
        //         }
        //     }
            
        //     //LIST ITEM T??? TRANSACTION
        //     List<string> List_Item = new List<string> ();


        //     // t???o m???t m???ng 2 chi???u c???t ?????u l??u id_dk, c???t sau l??u iddv
        //     string[,] TempArray = new string[List_IDDK.Count(),2];
        //     for (int i = 0; i<  List_IDDK.Count();i++)
        //     {string chuoidulieu = "";
        //         // TempArray[i,0] = List_IDDK[i];
        //         // TempArray[i,1] = 0;
        //         var dataIDKH = _context.HopDong.Where(h => h.duKhach.dk_id == List_IDDK[i]).ToList();
            
        //         foreach(var item2 in dataIDKH)
        //         {
        //             string temp = item2.dv_id.ToString();
        //             bool ContainORNoT = chuoidulieu.Contains(temp);
        //             if(ContainORNoT==false)
        //             {
        //                 chuoidulieu = chuoidulieu+temp+' ';
        //             }

        //             //add c??c Item v??o itemlist
        //             bool ItemInList = List_Item.Contains(temp);
        //             if(ItemInList == false)
        //             {
        //                 List_Item.Add(temp);
        //             }

        //         }
        //         chuoidulieu = chuoidulieu.TrimEnd(' ');
        //         TempArray[i,0]= List_IDDK[i].ToString();
        //         TempArray[  i,1]=chuoidulieu;
        //     }

        //     //TRANSACTION D
        //     //t???o m???t list l??u id dv theo id dk, list n??y c?? ????? d??i b???ng list id du kh??ch (d??ng count)
        //     List<string> List_Transaction_IDDV_ByIDDK = new List<string>(List_IDDK.Count());
        //     for (var i = 0; i < List_IDDK.Count(); i++)
        //     {
        //         List_Transaction_IDDV_ByIDDK.Add(TempArray[ i,1]);
        //     }
        //     //-----------------------------------------//
        //     ////////B???t ?????u t??nh lu???t k???t h???p//////////
        //     // T???p D theo K
        //     List<string> DTheoK = new List<string>();
        //     //cho bi???n Temp ????? c???ng t???p itemset v??o m???t chu???i
        //     string TempForSubStr="";
        //     foreach (var item in List_Item)
        //     {
        //         TempForSubStr+=item+" ";
        //     }
        //     TempForSubStr=TempForSubStr.Trim();
        //     // add temp v??o t???p ????? c?? chu???i itemset
        //     DTheoK.Add(TempForSubStr);

        //     List<string> TempItem_plit = new List<string>();
        //     TempItem_plit = DTheoK;
        //     string Str_DTheoK="";
        //     bool gitri = true;
        //     List<string> ReturnValK = new List<string>();
        //     List<string>  Str_DTheoK_sPlit= new List<string>();
             

        //     // n???u minsup = 2 => ch???y t???i i=3 l?? max
        //     // n???u minsup = 1 => ch???y t???i i=7 l?? max
        //     // n???u minsup = 3 => ch???y t???i i=2 l?? max


        //     for (int i = 1; i < 3; i++)
        //     {
        //         System.Console.WriteLine("----------K = {0}-----",i);
        //         //l???n ?????u ti??n l??u l???i nh???ng ItemSet ????? d??ng cho lu???t k???t h???p, nh???ng l???n sau gitri = false k g??n b???ng gi?? tr??? n??y ???????c n???a
        //         if (gitri ==true)
        //         {
        //               Str_DTheoK = TempItem_plit[i-1];
        //               Str_DTheoK_sPlit = Str_DTheoK.Split(' ').ToList();
        //             gitri = false;
        //         }
                
        //         //c???t t??? chu???i ra nhi???u ph???n t??? => Str_DTheoK_sPlitl ki???u list
        //         //cho ReturnValK = r???ng ????? n???p l???i ph???n t??? k???t h???p
        //          ReturnValK = new List<string>();

        //         for (int x = 0; x < Str_DTheoK_sPlit.Count(); x++)
        //         {
                    
        //             //cho x,y l?? ph???n t??? 1 v?? 2 li???n k??? nh??n nhau, v??ng l???p d???ng khi x t???i length - 1
        //             if (x == Str_DTheoK_sPlit.Count()-1)
        //                 {
        //                     break;
        //                 }
        //             for (int y = x+1; y < Str_DTheoK_sPlit.Count(); y++)
        //             {var substring="";
        //                 List<string> Val1 = new List<string>();
        //                 List<string>  Val2 = new List<string>();

        //                 //Val1.Add(Str_DTheoK_sPlit[x]);
        //                 // Val2.Add(Str_DTheoK_sPlit[y]);

        //                 Val1 = Str_DTheoK_sPlit[x].Split(' ').ToList();
        //                 Val2 = Str_DTheoK_sPlit[y].Split(' ').ToList();
        //                 var union = Val1.Union(Val2);
                        
        //                 foreach (var j in union)
        //                 {
        //                     substring = substring+ j + " ";
                            
        //                 }
        //                 substring = substring.Trim();
        //                 List<string> check = substring.Split(' ').ToList();
        //                 check.Count();
        //                 if (checkContain(substring, ReturnValK) == false)
        //                 {
        //                     if (check.Count()==i+1 )
        //                     {
        //                         Console.WriteLine(substring);
        //                         ReturnValK.Add(substring);
        //                     }
                            
        //                 }
        //             }
        //             TempItem_plit = ReturnValK;
        //             // l???y t???p temitem_split ????? t??nh ????? sub, ki???m tra sub so s??nh min sub ????? lo???i ra
        //         }
        //         //T???o 1 list l??u tr??? item c?? sup >=1
        //         for (int g = 0; g < TempItem_plit.Count(); g++)
        //         {
        //             int MINSUP = 2;// g??n c???ng b???ng 2, nh???ng ph???n t??? n??o d?????i 2 s??? b??? lo???i
        //             if (Return_Sup(TempItem_plit[g], List_Transaction_IDDV_ByIDDK)< MINSUP)
        //             {
        //                 System.Console.WriteLine(TempItem_plit[g] + " Co SUP = "+Return_Sup(TempItem_plit[g], List_Transaction_IDDV_ByIDDK) + " < 2 => loai");
        //                 TempItem_plit.RemoveAt(g);
        //                 g = g -1  ;
        //             }
        //             else{System.Console.WriteLine(TempItem_plit[g] + " Co SUP = "+Return_Sup(TempItem_plit[g], List_Transaction_IDDV_ByIDDK) + " >= 2  => ChapNhan---------");}
        //         }
                
        //         Str_DTheoK_sPlit = TempItem_plit;
                
        //     }
        //     //Tr??? v??? list nh???ng ph???n t??? c?? sub>minsub & conf > minConf
        //    // List<string> checkVal = ThuatToanSinhLuat(Str_DTheoK_sPlit,List_Transaction_IDDV_ByIDDK);
        //     // ??ang l???i kh??c add gi?? tr??? lu???t k???t h???p v?? CheckVal

        //     List<string> checkVal = new List<string>();
        //     for (var i = 0; i < Str_DTheoK_sPlit.Count(); i++)
        //     {
        //         string Split_val_from_Str_DTheoK_sPlit = Str_DTheoK_sPlit[i];
        //         foreach (var item in ThuatToanSinhLuat(Split_val_from_Str_DTheoK_sPlit,List_Transaction_IDDV_ByIDDK))
        //         {
        //             checkVal.Add(item);
        //         }
        //     }
        
        //      return checkVal;
        // }

        // public static bool checkContain(string sub, List<string> ReTurnVal)
        // {
        //     bool checkContain = false;
        //     int count = 0;
        //     //t??ch sub ra th??nh list nhi???u ph???n t???
        //     List<string> Ptu_Sub = sub.Split(' ').ToList();
        //     //Duy???t trong List return 
        //     for (int i = 0; i < ReTurnVal.Count; i++)
        //     {   count = 0;
        //         //t??ch ph???n t??? list return ra nh??? h??n
        //         //List<string> Ptu_ReturnVal = ReTurnVal[i].Split(' ').ToList();
        //         //ki???m tra ph???n t??? sub n???u c?? trong ph???n t??? list ReturnVal => count +1
        //         for (int j = 0; j < Ptu_Sub.Count(); j++)
        //         {
        //              bool check = ReTurnVal[i].Contains(Ptu_Sub[j]);
        //                 if (check == true)
        //                 {
        //                     count++;
        //                 }
                    
        //         }
        //         if (count>= Ptu_Sub.Count())
        //         {
        //             checkContain = true;
        //         }
        //     }
            
        //     return checkContain;
        // }

        // static int Return_Sup(string Item, List<string> D)
        // {
            
        //     int sub = 0, DLenght = D.Count;

        //     string[] TempItem_plit = Item.Split(' ');
        //     int rangeOf_ItemPlit = TempItem_plit.Length;
        //      int Count_Check_Contain = 0;
        //     for (int i = 0; i < DLenght; i++)
        //     {
        //         //c???t chu???i b???ng d???u " " (c??ch)
        //         //string[] TempTransaction_Plit = D[i].Split(' ');
        //         Count_Check_Contain = 0;
        //             for (int x = 0; x < rangeOf_ItemPlit; x++)
        //             {
        //                 bool check = D[i].Contains(TempItem_plit[x]);
        //                     if (check == true)
        //                     {
        //                         Count_Check_Contain++;
        //                             if (Count_Check_Contain == rangeOf_ItemPlit)
        //                             {
        //                                 sub++;
        //                             }
        //                     }                    
        //             }
        //     }
        //     return sub;
        // }

        // public static List<string> ThuatToanSinhLuat(string Item_theoK, List<string> D)
        // {
        //     List<string> AprioriVal = new List<string>();
            
        //     // List<string> temp= new List<string>();
        //     // temp.Add(Item_theoK);

        //     List<string> temp = Item_theoK.Split(" ").ToList();

        //     // List<string> ReturnValK = Item_theoK;
        //     List<string> ReturnValK = new List<string>();
        //     ReturnValK.Add(Item_theoK);
        //     List<string> val = temp;
            
        //     for (int i = 1; i < temp.Count(); i++)
        //     {
        //         ReturnValK = new List<string>();
        //         for (int x = 0; x < temp.Count(); x++)
        //         {


        //             if (x == temp.Count() - 1)
        //             {
        //                 break;
        //             }
        //             for (int y = x + 1; y < temp.Count(); y++)
        //             {
        //                 var substring = "";
        //                 List<string> Val1 = new List<string>();
        //                 List<string> Val2 = new List<string>();

        //                 //Val1.Add(Str_DTheoK_sPlit[x]);
        //                 // Val2.Add(Str_DTheoK_sPlit[y]);

        //                 Val1 = temp[x].Split(' ').ToList();
        //                 Val2 = temp[y].Split(' ').ToList();
        //                 var union = Val1.Union(Val2);

        //                 foreach (var j in union)
        //                 {
        //                     substring = substring + j + " ";

        //                 }
        //                 substring = substring.Trim();
        //                 List<string> check = substring.Split(' ').ToList();
        //                 check.Count();
        //                 if (checkContain(substring, ReturnValK) == false) 
        //                 {
        //                     if (check.Count() - 1 == i)
        //                     {
        //                         Console.WriteLine(substring);
        //                         ReturnValK.Add(substring);
        //                         val.Add(substring);
        //                     }

        //                 }
        //             }

        //         }
                
                
        //     }
        //     //Loai Tap ban dau
        //     val.RemoveAt(val.Count()-1);
            

        //     foreach (var item in val)
        //     {
        //         Console.WriteLine(item);
        //     }
            
            
        //     // cho k???t h??n gi?? tr??? ?????u + gi?? tr??? cu???i
        //     for (int item = 0; item < val.Count(); item++)
        //     {
        //         string ItemA = val[item];

        //         string ItemBCD = val[val.Count()-1-item];
        //         string ItemA_BCD = ItemA+" "+ItemBCD;  
        //         double SupA = Return_Sup(ItemA, D);
        //         double SupA_BCD= Return_Sup(ItemA_BCD, D);
        //         double Conf = ( SupA_BCD/ SupA);
        //         if (Conf >= 0.8)
        //         {
        //             System.Console.WriteLine(SupA_BCD +" CONF =  "+Conf);
        //                 if (checkContain(ItemA_BCD, AprioriVal) == false)
        //                 {
        //                     AprioriVal.Add(ItemA+" "+ItemBCD);
        //                 }
                    
        //         }
        //     }

        //     return AprioriVal;

        // }



        [HttpPost]
        //id l?? id dung kh??ch, rating => ??i???m ????nh gi?? t??? 1 ?????n 5, id h???p ?????ng ????? cho update
        public async Task<IActionResult> Updaterating(double stars,  int hdid, int dvid, string userID)
        {
            HopDong hopDong = _context.HopDong.Single(m=>m.hd_id == hdid);
            hopDong.hd_danhgiachatluong = stars;
            await _context.SaveChangesAsync();


            // c???p nh???t l???i trung b??nh ????nh gi?? ch???t l?????ng
            double SumStart_In_HD = _context.HopDong.Where(m=>m.dv_id==dvid&&m.hd_danhgiachatluong >0).Sum(c=>c.hd_danhgiachatluong);
            int Count_HD_Voted = _context.HopDong.Where(m=>m.dv_id==dvid&&m.hd_danhgiachatluong>0).Count();

            DichVu dichVu = _context.DichVu.Single(q=>q.dv_id==dvid);
            dichVu.dv_trungbinhchatluong = SumStart_In_HD/Count_HD_Voted;
            await _context.SaveChangesAsync();
            
            return RedirectToAction("TravellingSchedule","HopDongs",new{id = int.Parse(userID)});
        }

        // H??m tr??? v??? trung b??nh ??i???m ????nh gi?? 
        // public  IActionResult AvgRating(int id)
        // {
            
        //     var Sum = (from HD in _context.HopDong where HD.hd_danhgiachatluong!=0 && HD.hd_id==id select HD.hd_danhgiachatluong).Average();
        //     TempData["sumRating"] = Sum;
        //     return View();
        // }
    }
}
