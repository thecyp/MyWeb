using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWeb
{
    public class Program
    {
        //主程式Entry Point ....(第一支要執行的程序)
        //這一個方法會進入非物件化方法(Non-Instance Method) 關鍵詞使用static
        public static void Main(string[] args)
        {
            //自訂一個static method CreateHostBuilder method
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //產生一個應用系統去配置服務與MiddleWare
                    //UseStarup<Generic泛型>() 泛型注入影響方法參數與回應值
                    webBuilder.UseStartup<Startup>();
                });
    }
}
