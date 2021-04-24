using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pampara.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Pampara.Api.DependencyInjection;

namespace Pampara.Api
{
    public class Startup
    {
        private readonly string corsPolicy = "myCors";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(opts => opts.UseSqlServer(Configuration.GetConnectionString("PamparaDB")));

            // Inject Services
            Injection.AddPamparaServices(services);

            services.AddCors(opts =>
            {
                opts.AddPolicy(name: corsPolicy, b =>
                {
                    b
                    // .AllowAnyOrigin()
                    .WithOrigins(new string[] { "http://localhost:4200", "http://localhost:5001" })
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
                });
            });
            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors(corsPolicy);
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
