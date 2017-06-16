using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Tavisca.Connector.Hotels.WebAPI;
using Tavisca.Platform.Common;
using Tavisca.Platform.Common.ExceptionManagement;
using StructureMap;
using Tavisca.Connector.Hotels.Translators;
using Microsoft.AspNetCore.Http.Features;

namespace Tavisca181.Host
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();

            services.AddMvc()
                .AddControllersAsServices()
                .AddJsonOptions(opt => opt.SerializerSettings.ContractResolver = new TranslatorFactory().Build("1.0").ContractResolver); ;

            var serviceProvider = ConfigureIoC(services);
            ExceptionPolicy.Configure(serviceProvider.GetRequiredService<IErrorHandler>());
            return serviceProvider;
        }

        public IServiceProvider ConfigureIoC(IServiceCollection services)
        {
            var container = new Container(c =>
            {
                c.AddRegistry<ComponentRegistry>();
            });
            container.Configure(config =>
            {
                config.Populate(services);
            });
            return container.GetInstance<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureStartup();

            app.UseMvc();
        }
    }
}
