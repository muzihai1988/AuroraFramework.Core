using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AuroraFramework.Core.API.Extensions;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace AuroraFramework.Core.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var basePath = ApplicationEnvironment.ApplicationBasePath;

            services.UseSqlSugarExtension();

            #region Swagger

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("V1", new OpenApiInfo
                {
                    Version = "V1",
                    Title = "AuroraFramework.Core 接口文档--.Net Core 3.1",
                    Description = "AuroraFramework.Core HTTP API V1",
                    Contact = new OpenApiContact { Name = "AuroraFramework.Core", Email = "971251768@qq.com", Url = new Uri("http://baidu.com") },
                    License = new OpenApiLicense { Name = "AuroraFramework.Core", Url = new Uri("http://baidu.com") }
                });
                c.OrderActionsBy(o => o.RelativePath);

                var xmlPath = Path.Combine(basePath, "AuroraFramework.Core.API.xml");
                c.IncludeXmlComments(xmlPath, true);
            });
            #endregion
        }

        /// <summary>
        /// Autofac依赖注入
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            var basePath = ApplicationEnvironment.ApplicationBasePath;

            var servicesDllFile = Path.Combine(basePath, "AuroraFramework.Core.Services.dll");
            var assemblyServices = Assembly.LoadFrom(servicesDllFile);

            builder.RegisterAssemblyTypes(assemblyServices)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .EnableInterfaceInterceptors();

            var repositoryDllFile = Path.Combine(basePath, "AuroraFramework.Core.Repository.dll");
            var assemblysRepository = Assembly.LoadFrom(repositoryDllFile);
            builder.RegisterAssemblyTypes(assemblysRepository).AsImplementedInterfaces();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/V1/swagger.json", "AuroraFramework.Core.API V1");
                c.RoutePrefix = "";
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
