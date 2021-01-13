using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Restaurant.Application;
using Restaurant.Application.Common.Interfaces;
using Restaurant.Infrastructure;
using Restaurant.WebUI.Handlers;
using Restaurant.WebUI.Services;
using Serilog;

namespace Restaurant.WebUI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructure(Configuration);
            services.AddApplication();
            services.AddControllers().AddNewtonsoftJson();
            services.AddCors();

            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
            });
            
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.EnvironmentName == "dev")
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "Images")),
                RequestPath = "/Images"
            });

            app.UseErrorHandler();
            app.UseHttpsRedirection();
            app.UseSpaStaticFiles();
            app.UseRouting();
            app.UseCookiePolicy();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSerilogRequestLogging();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            
            app.UseSpa(spa => spa.Options.SourcePath = "ClientApp");
        }
    }
}