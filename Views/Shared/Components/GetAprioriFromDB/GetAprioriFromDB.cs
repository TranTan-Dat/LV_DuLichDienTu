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
namespace LV_DuLichDienTu.Views.Shared.Components.GetAprioriFromDB
{
    public class GetAprioriFromDB : ViewComponent
    {
        private readonly acompec_lvdatContext _context;

        public GetAprioriFromDB(acompec_lvdatContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id_dukhach)
        {   
            int ID = id_dukhach ;
            List<string> list_substring_List_ID_NeedToShow = new List<string>();
            //Tập luật kết hợp trả về ds gợi ý địa điểm chưa tính theo rating
            List<string> Val_Apriori =  Function_Apriori();
            List<string> Final_value = new List<string>();
            for (int i = 0; i < Val_Apriori.Count(); i++)
            {
                bool return_check_rating = Check_Rating_ITEM_IN_Val_Apriori(Val_Apriori[i]);
                if (return_check_rating == true)
                {
                    System.Console.WriteLine("Phần tử {0} có trung bình rating VƯỢT mức yêu cầu => ----Nhận-----",Val_Apriori[i]);
                    Final_value.Add(Val_Apriori[i]);
                }
                else
                {
                    System.Console.WriteLine("Phần tử {0} không đủ trung bình rating => LOẠI",Val_Apriori[i]);
                }
            }
            int check = Final_value.Count();

            // bắt đầu truy vấn lấy id dịch vụ mà du khách lựa chọn 
            var acompec_lvdatContext = _context.HopDong.Include(h => h.dichVu).Include(h => h.duKhach);
            var ListIDService_By_User =  _context.HopDong.Where(m=>m.dk_id== id_dukhach).Select(s => s.dv_id).Distinct().ToList();
            if (ListIDService_By_User.Count() ==0)
            {
                list_substring_List_ID_NeedToShow.Add("");
            }
            else
            {
                List<string> String_ListIDService_By_User = ListIDService_By_User.ConvertAll<string>(x => x.ToString());
                string SUbStringValIDServicesByUser = "";
                List<string> List_ID_NeedToShow = new List<string>();
                for (var i = 0; i < String_ListIDService_By_User.Count(); i++)
                {
                    SUbStringValIDServicesByUser= SUbStringValIDServicesByUser+String_ListIDService_By_User[i]+" ";
                }
                SUbStringValIDServicesByUser=SUbStringValIDServicesByUser.TrimEnd(' ');
                int count = 0;
                //tách sub ra thành list nhiều phần tử
                List<string> Ptu_Sub = SUbStringValIDServicesByUser.Split(' ').ToList();
                for (int i = 0; i < Final_value.Count; i++)
                {   count = 0;
                bool CheckValContain = false;
                    //tách phẩn tử list return ra nhỏ hơn
                    //List<string> Ptu_ReturnVal = Final_value[i].Split(' ').ToList();
                    //kiểm tra phẩn tử sub nếu có trong phần tử list Final_value => count +1
                    for (int j = 0; j < Ptu_Sub.Count(); j++)
                    {
                        CheckValContain = Final_value[i].Contains(Ptu_Sub[j]);
                            if (CheckValContain == true)
                            {
                                count++;
                            }
                        
                    }
                    if (count>= 1)
                    {
                        List_ID_NeedToShow.Add(Final_value[i]);
                    }
                
                }
                //Duyệt trong List return 
                
                //Kết quả trả về là danh sách các phần tử có id giống như id dịch vụ ncc chọn

                //Danh sách gợi ý phải loại ra những thằng đã chọn
                //1. tách List_ID_NeedToShow thành 1 tập phần tử lẻ
                //2. lấy list địa điểm dk chọn (list là ptusup) Đã có
                string substring_List_ID_NeedToShow = "";
                for (var i = 0; i < List_ID_NeedToShow.Count; i++)
                {
                    substring_List_ID_NeedToShow= substring_List_ID_NeedToShow+List_ID_NeedToShow[i]+" ";
                }
                substring_List_ID_NeedToShow=substring_List_ID_NeedToShow.Trim();
                list_substring_List_ID_NeedToShow = substring_List_ID_NeedToShow.Split(' ').ToList(); //list id gợi ý cho dk khách

                // chạy các for i -> ptusub.count , kiem tra ptusub[i] co nam trong List_substring_List_ID_NeedToShow 
                for (var i = 0; i < list_substring_List_ID_NeedToShow.Count; i++)
                {
                    for (var j = 0; j < Ptu_Sub.Count; j++)
                    {
                        if (Ptu_Sub[j]==list_substring_List_ID_NeedToShow[i])
                        {
                            list_substring_List_ID_NeedToShow.RemoveAt(i);
                            i=i-1;
                        }
                    }
                }
            }
            // lưu giá trị vài view Data
            @ViewData["list4"] = list_substring_List_ID_NeedToShow;
            // foreach (var item in list_substring_List_ID_NeedToShow)
            // {
            //    var KQ = _context.DichVu.Where(m => m.dv_id ==  int.Parse(item));
            // }
            // ViewBag.list4 = KQ;
            System.Console.WriteLine("kq tra ve");
            foreach (var item in ViewBag.list4)
            {
                System.Console.WriteLine(item);
            }
            

            var result = await _context.DichVu.ToListAsync();
            return View<List<DichVu>>(result);
            
        }

        
        public bool Check_Rating_ITEM_IN_Val_Apriori(string ele_List_Apriori)
        {
            /*
            1. từ chuỗi địa điểm cắt ra thành từng phần tử
            2. truy vấn csdl lấy ra rating của các địa điểm
            3. tính trung bình rating của chuỗi id địa điểm (nếu avg_rating < 3.5 => loại)
            */

            bool checkHigher = false;
            List<string> list_id = ele_List_Apriori.Split(" ").ToList();
            double avg_rating = 0;
            for (var i = 0; i < list_id.Count(); i++)
            {
                // var RateIDFromDB= _context.DichVu.Where(h => h.dv_id == int.Parse(list_id[i])).Select(m=>m.dv_trungbinhchatluong);
                var RateIDFromDB = from f in _context.DichVu
                                        where f.dv_id == int.Parse(list_id[i])
                                        select f.dv_trungbinhchatluong;
                double returnRateIDFromDB = double.Parse( RateIDFromDB.FirstOrDefault().ToString());
                avg_rating+=returnRateIDFromDB;
            }
            avg_rating = avg_rating/list_id.Count();
            if (avg_rating >= 4)
            {
                checkHigher =true;
            }
            return checkHigher;
        }

        public List<string> Function_Apriori()
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
            //-----------------------------------------//
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
             

            // nếu minsup = 2 => chạy tới i=3 là max
            // nếu minsup = 1 => chạy tới i=7 là max
            // nếu minsup = 3 => chạy tới i=2 là max


            for (int i = 1; i < 3; i++)
            {
                System.Console.WriteLine("----------K = {0}-----",i);
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
                //Tạo 1 list lưu trữ item có sup >=1
                for (int g = 0; g < TempItem_plit.Count(); g++)
                {
                    int MINSUP = 2;// gán cứng bằng 2, những phần tử nào dưới 2 sẽ bị loại
                    if (Return_Sup(TempItem_plit[g], List_Transaction_IDDV_ByIDDK)< MINSUP)
                    {
                        System.Console.WriteLine(TempItem_plit[g] + " Co SUP = "+Return_Sup(TempItem_plit[g], List_Transaction_IDDV_ByIDDK) + " < 2 => loai");
                        TempItem_plit.RemoveAt(g);
                        g = g -1  ;
                    }
                    else{System.Console.WriteLine(TempItem_plit[g] + " Co SUP = "+Return_Sup(TempItem_plit[g], List_Transaction_IDDV_ByIDDK) + " >= 2  => ChapNhan---------");}
                }
                
                Str_DTheoK_sPlit = TempItem_plit;
                
            }
            //Trả về list những phần tử có sub>minsub & conf > minConf
           // List<string> checkVal = ThuatToanSinhLuat(Str_DTheoK_sPlit,List_Transaction_IDDV_ByIDDK);
            // đang lỗi khúc add giá trị luật kết hợp vô CheckVal

            List<string> checkVal = new List<string>();
            for (var i = 0; i < Str_DTheoK_sPlit.Count(); i++)
            {
                string Split_val_from_Str_DTheoK_sPlit = Str_DTheoK_sPlit[i];
                foreach (var item in ThuatToanSinhLuat(Split_val_from_Str_DTheoK_sPlit,List_Transaction_IDDV_ByIDDK))
                {
                    checkVal.Add(item);
                }
            }
        
             return checkVal;
        }
        //Hàm kiểm tra string có nằm trong danh sách k 
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
        //Tính sub
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
        //Tính thuật toán sinh luật
        public static List<string> ThuatToanSinhLuat(string Item_theoK, List<string> D)
        {
            List<string> AprioriVal = new List<string>();
            
            // List<string> temp= new List<string>();
            // temp.Add(Item_theoK);

            List<string> temp = Item_theoK.Split(" ").ToList();

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
            for (int item = 0; item < val.Count(); item++)
            {
                string ItemA = val[item];

                string ItemBCD = val[val.Count()-1-item];
                string ItemA_BCD = ItemA+" "+ItemBCD;  
                double SupA = Return_Sup(ItemA, D);
                double SupA_BCD= Return_Sup(ItemA_BCD, D);
                double Conf = ( SupA_BCD/ SupA);
                if (Conf >= 0.8)
                {
                    System.Console.WriteLine(SupA_BCD +" CONF =  "+Conf);
                        if (checkContain(ItemA_BCD, AprioriVal) == false)
                        {
                            AprioriVal.Add(ItemA+" "+ItemBCD);
                        }
                    
                }
            }

            return AprioriVal;

        }
        
    }

}