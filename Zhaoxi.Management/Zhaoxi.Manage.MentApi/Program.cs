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
    /// ���Կ�����
    /// </summary>
    public class Program
    {
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // ��ȡ���ݿ������ַ���
            builder.Host.AddAppSettingsSecretsJson();

            if (builder.Configuration["IsInitDatabase"] == "1")
            {
                //����SqlSugar--��ʼ�����ݿ�
                //��Ŀ�״�����
                builder.InitDatabase();
            }
            builder.InitSqlSugar();//��ʼ��SqlSugar-ע�ᵽIOC����
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