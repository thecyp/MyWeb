using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWeb.Controllers
{
    public class HelloController : Controller
    {
        //打招呼Action(Method) 回應值 使用介面多型化
        public IActionResult helloWorld()
        {
            //先回文字內容(被包裝在一個HTTP協定封包內)
            //直接透過既定方法 產生一個ContainReusult物件 回應字串同時設定Content-Type:text/html
            ContentResult result = this.Content("<font size='7' color='red'>早安</font>","text/html;charset=UTF-8");
            return result;
        }

        public void helloWorld2()
        {
            //先回文字內容(被包裝在一個HTTP協定封包內)
            //直接透過既定方法 產生一個ContainReusult物件 回應字串同時設定Content-Type:text/html
            //低階寫法(直接控制Response物件)
            HttpResponse response = this.Response;
            response.ContentType = "text/html;charset=UTF-8";
            response.WriteAsync("<font size='7' color='red'>吃飽沒?</font>").GetAwaiter().GetResult(); //採用非同步寫出進型等待 回應同一個工作
        }

        //採用QuerySting 傳遞一個打招呼的人名
        //前端瀏覽器URL 參數名稱應對方法參數名稱???
        //使用特徵描述類別(語法糖)
        public IActionResult helloToY2([FromQueryAttribute(Name ="w")]string who)
        {
            //處理一下 狀態state 如何持續到View Page去?
             string result = $"{who}你好! 世界和平";
            //要持續(使用動態屬性參考之)這一個字串狀態到 調用View去
            this.ViewBag.Message = result;//底層偷偷使用httpResquest
            //調用一個View Page(Razer Page)
            ViewResult view = this.View(); //不指定View Page名稱預設採用Method名稱
            //Dispatcher 派送 持續原先的Resquest and Response兩個物件
            return view;
            //return Content(who);
        }
    }
}
