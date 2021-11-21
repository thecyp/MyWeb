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
        //�D�{��Entry Point ....(�Ĥ@��n���檺�{��)
        //�o�@�Ӥ�k�|�i�J�D����Ƥ�k(Non-Instance Method) ������ϥ�static
        public static void Main(string[] args)
        {
            //�ۭq�@��static method CreateHostBuilder method
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //���ͤ@�����Ψt�Υh�t�m�A�ȻPMiddleWare
                    //UseStarup<Generic�x��>() �x���`�J�v�T��k�ѼƻP�^����
                    webBuilder.UseStartup<Startup>();
                });
    }
}
