using FluentValidation.AspNetCore;
using Hospital.DataAccess;
using Hospital.DataAccess.Repositories.Implementations;
using Hospital.DataAccess.Repositories.Interfaces;
using Hospital.Service.Implementations;
using Hospital.Service.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace Hospital
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
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:Hospital"]);
            });

            services.AddOpenApiDocument();
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            services.AddMvc(option => option.EnableEndpointRouting = false)
                    .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                    .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddTransient<IDoktorRepository, DoktorRepository>();
            services.AddTransient<IDoktorService, DoktorService>();

            services.AddTransient<IRasporedRepository, RasporedRepository>();
            services.AddTransient<IRasporedService, RasporedService>();

            services.AddTransient<ITerminRepository, TerminRepository>();
            services.AddTransient<ITerminService, TerminService>();

            services.AddTransient<IKlijentRepository, KlijentRepository>();
            services.AddTransient<IKlijentService, KlijentService>();

            services.AddTransient<ITipPregledaRepository, TipPregledaRepository>();
            services.AddTransient<ITipPregledaService, TipPregledaService>();

            services.AddTransient<IZakazivanjePregledaRepository, ZakazivanjePregledaRepository>();
            services.AddTransient<IZakazivanjePregledaService, ZakazivanjePregledaService>();

            services.AddMvc().AddFluentValidation();
            services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseOpenApi();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
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
