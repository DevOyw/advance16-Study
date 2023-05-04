using Microsoft.OpenApi.Models;
using SqlSugar;
using System.Reflection;
using Zhaoxi.Manage.BusinessInterface;
using Zhaoxi.Manage.BusinessInterface.MapConfig;
using Zhaoxi.Manage.BusinessService;
using Zhaoxi.Manage.MentApi.Utility.HostingExt;
using Zhaoxi.Manage.MentApi.Utility.InitDatabaseExt;
using Zhaoxi.Manage.MentApi.Utility.SwaggerExt;

namespace Zhaoxi.Manage.MentApi
{
    /// <summary>
    /// 测试控制器
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 程序入口
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // 读取数据库连接字符串
            builder.Host.AddAppSettingsSecretsJson();

            if (builder.Configuration["IsInitDatabase"] == "1")
            {
                //配置SqlSugar--初始化数据库
                //项目首次启动
                builder.InitDatabase();
            }
            builder.InitSqlSugar();//初始化SqlSugar-注册到IOC容器
            builder.Services.AddTransient<IUserManagerService, UserManagerService>();

            // Add services to the container.

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.AddSwaggerExt();

            builder.Services.AddAutoMapper(typeof(AutoMapperConfigs));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            app.UseSwaggerExt();
            //}

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}