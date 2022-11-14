using deliveraholic_backend.DALs;
using deliveraholic_backend.Tools.MessageHandler;
using deliveraholic_backend.Tools.MessageHandler.Hubs;
using deliveraholic_backend.Tools.MessageHandler.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace deliveraholic_backend
{
    public class Startup
    {
        public IConfiguration configuration { get; }
        public bool test { get; set; }


        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureDatabaseServices(services);
            ConfigureDefaultServices(services);
        }


        protected void ConfigureDefaultServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
            {
                builder.WithOrigins("https://localhost:3000/").AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials();
                builder.WithOrigins("http://localhost:3000/").AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true).AllowCredentials();
            }));

            services.AddSignalR();
            services.AddSingleton<IMessage, MessageHandler>();
        }


        protected virtual void ConfigureDatabaseServices(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DBConnStr"),
                builder => builder.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name)));
        }


        public virtual void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseCors(builder => builder
                 .AllowAnyMethod()
                 .AllowAnyHeader()
                 .SetIsOriginAllowed(origin => true).AllowCredentials());

            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<UserMessageHub>("/UserMessageHub");
            });
        }
    }
}