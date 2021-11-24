using BankDemo.Data;
using BankDemo.Data.Repository;
using BankDemo.Services;
using BankDemo.Services.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankDemo
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
            services.AddDbContext<BankDemoContext>(options => options.UseSqlServer(Configuration.GetSection("Datasource:ConnectionString").Value, serverOptions => { serverOptions.MigrationsAssembly(typeof(Startup).Assembly.FullName); }));

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IMovementRepository, MovementRepository>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddSingleton<IClientMapper, ClientMapper>();
            services.AddSingleton<IAccountMapper, AccountMapper>();
            services.AddSingleton<IMovementMapper, MovementMapper>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BankDemo", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BankDemo v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
