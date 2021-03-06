﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestWithASPNetUdemy.Model.Context;
using RestWithASPNetUdemy.Services;
using RestWithASPNetUdemy.Services.Implementation;

namespace RestWithASPNetUdemy
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
            //getting connection string from appsettings.json
            var connection = Configuration["MySqlConnection:MySqlConnectionString"];
            //creating MYSQL coonection database using connection above
            services.AddDbContext<MySqlContext>(options => options.UseMySql(connection));
            
            services.AddMvc();

            //dependency injection area 
            services.AddScoped<IPersonService, PersonServiceImplementation>();
          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
