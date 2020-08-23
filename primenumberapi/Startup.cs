using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using primenumberapi.Filters;

namespace primenumberapi
{
    public class Startup
    {

        const string CORS_DEVELOPMENT = "Cors_DevelopmentOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddCors(options =>
            {
                // Create an option to run with any Origin to work around a cors issue in dev between two localhosts on different servers and IP.
                // Production would be better having a env variable of possible allowed origins
                options.AddPolicy(name: CORS_DEVELOPMENT,
                    builder =>
                    {
                        //builder.WithOrigins(
                        //    "https://*.somedomain.com"
                        //    "https://some.specificsubdomain.com"
                        //);
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); //.AllowCredentials();
                        builder.WithHeaders("AuthToken");
                    }
                );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            if (env.IsDevelopment())
            {
                app.UseCors(CORS_DEVELOPMENT);
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();   
            });

        }

    }
}
