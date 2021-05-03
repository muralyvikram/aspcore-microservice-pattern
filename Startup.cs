﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using cms.Entities;
using cms.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore;
namespace cms
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

            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); ;
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new Swashbuckle.AspNetCore.Swagger.Info() { Title = "CMS", Version = "1.0" });
            });
            services.AddEntityFrameworkNpgsql().AddDbContext<MasterDBContext>(opt =>
              opt.UseNpgsql(Configuration.GetConnectionString("MasterDBConnection")));

            // services.AddScoped<IPostRepository, PostRepository> ();
            var config = new AutoMapper.MapperConfiguration(c =>
            {
                c.AddProfile(new dtos.AutoMapperProfile());
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IClusterRepository, ClusterRepository>();
            services.AddScoped<IPlantRepository, PlantRepository>();

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            else
            {
                app.UseHsts();
            }
            // app.UseStaticFiles ();

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Api"));
            app.UseMvc();

            app.UseStaticFiles();
        }
    }
}