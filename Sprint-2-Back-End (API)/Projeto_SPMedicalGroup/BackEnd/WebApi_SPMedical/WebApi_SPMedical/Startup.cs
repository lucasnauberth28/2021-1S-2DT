using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_SPMedical
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services
                //Adiciona o serviço dos controllers
                .AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    //Ignora os loopings
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    //Ignora os valores nulos ao fazer junções
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });
        }

            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }

                app.UseRouting();

                app.UseEndpoints(endpoints =>
                {

                    endpoints.MapControllers();

                });
            }
        }
    }



   