using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWeb
{
    //服務配置與中介元件MiddleWare
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //執行階段傳遞服務收集器物件進來
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //決定你是一個MVC網站系統服務
            services.AddControllersWithViews();
        }
        //參數採多型化架構進行相容性
        //物件透過環境適時注入(Injection)
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            //使用靜態檔案(包含有xxx.html page/圖片/文件/樣式表css/javascript...)
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            //公版路由配置 UseEndPoint(Action委派)
            app.UseEndpoints(endpoints =>
            {
                //傳遞進來參數IEndPointRouteBuilder物件 進行路由配置
                //MapControllerRout >> Extension Method(外掛的咬住對象)
                endpoints.MapControllerRoute(
                    //具名參數
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
