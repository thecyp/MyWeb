using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient; //for SQL Server .net Data Provider
//客戶資料維護或者查詢控制器 
namespace MyWeb.Controllers
{
    public class CustomersController : Controller
    {
        //調用一個依照客戶編號查詢的表單頁面 (Razor Page)
        public IActionResult customersQryForm()
        {
            //直接調用畫面(razor page)
            return this.View(); //沒有指定View Name就是預設與方法名稱一樣的View Name
        }
        //客戶查詢作業 by 客戶編號
        public IActionResult byCustomerID([FromFormAttribute(Name = "id")] String customerId)
        {
            String message = null;
            //...資料處理--查詢
            //1.建立連接上資料庫的連接物件
            SqlConnection conn = new SqlConnection();
            //配置連接上資料庫 連接字串與登入帳密
            conn.ConnectionString = MyWeb.Properties.Resources.nor;
            //開啟連接
            try
            {
                conn.Open();
                //君子寫法
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    message = "資料庫連接成功!!";
                    //執行查詢 線上讀取 主角是命令物件
                    //1.建構命令物件
                    SqlCommand comm = new SqlCommand();
                    //我要認識開路傢伙(連接物件) Property Injection(DI)
                    comm.Connection = conn; //將conn變數參考物件為只指派給Command進行參考
                    //2.命令當主角 設定令命類型 命令敘述
                    comm.CommandType = System.Data.CommandType.Text;
                    //3.設定查詢命令 採用參數設定方式 預防駭客採用SQL Injection竊取資料或埋入病毒
                    comm.CommandText = "Select CustomerID,CompanyName,Address,Phone,Country " +
                        "From Customers Where CustomerID=CustomerID";
                    //建構參數物件(prepared 編譯 防語法資安漏點)
                    SqlParameter p1 = new SqlParameter("CustomerID", customerId);
                    //讓命令物件背後看不到參數集合物件Collection
                    SqlParameterCollection col = comm.Parameters;
                    col.Add(p1);
                    //執行線上讀取查詢作業
                    SqlDataReader reader = comm.ExecuteReader();
                    //準備逐筆讀取Fetching 
                    if (reader.Read())
                    {
                        //有資料  將資料(欄位)讀下來 封裝成一個Entity實體物件
                        message = "公司行號:" + reader["CompanyName"].ToString();
                    }
                    else
                    {
                        //查無資料
                        message = "查無資料";
                    }

                    //處理關閉
                    conn.Close();
                }
            }
            catch (SqlException ex)
            {
                message = "連接失敗..." + ex.Message;
            }
            //..調用畫面
            return Content(message);
        }
    }
}