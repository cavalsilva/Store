using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elmah.Io.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Store.Domain.StoreContext.Handlers;
using Store.Domain.StoreContext.Repositories;
using Store.Domain.StoreContext.Services;
using Store.Infra.Repositories;
using Store.Infra.Services;
using Store.Infra.StoreContext.DataContexts;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.Configuration;
using System.IO;
using Store.Shared;

namespace Store.Api
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // TODO: Incluir JSON e deploy Azure
            /*
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
            */
            services.AddMvc();

            services.AddResponseCompression();

            services.AddScoped<StoreDataContext, StoreDataContext>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<CustomerHandler, CustomerHandler>();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Info { Title = "Cavalsilva Store", Version = "v1" });
            });

            services.AddElmahIo(o =>
            {
                o.ApiKey = "9d471b02163744c997fef2f2a7ee9cc2";
                o.LogId = new Guid("d76a3261-4a19-49a4-b104-8315a395d3fd");
            }); 

            //Settings.ConnectionString = $"{Configuration["connectionString"]}";
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();                
            app.UseResponseCompression();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cavalsilva Store - V1");
            });

            app.UseElmahIo();
        }
    }
}
