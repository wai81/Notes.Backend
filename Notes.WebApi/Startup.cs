using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Notes.Aplication;
using Notes.Aplication.Common.Mappings;
using Notes.Aplication.Interfaces;
using Notes.Persistence;
using System.Reflection;

namespace Notes.WebApi
{
    public class Startup

    {
        public IConfiguration Configuration { get; }
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(conf =>
            {
                conf.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                conf.AddProfile(new AssemblyMappingProfile(typeof(INotesDbContext).Assembly));
            });
            services.AddApplication();
            services.AddPersistence(Configuration);
            services.AddControllers();

            services.AddCors( opt =>
            {
                opt.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });
           // services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           

            app.UseHttpsRedirection();
            // app.UseStaticFiles();

            app.UseRouting();
            app.UseCors("AllowAll");
            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
