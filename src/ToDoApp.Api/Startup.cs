using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ToDoApp.Core.Interfaces;
using ToDoApp.Core.Services;
using ToDoApp.Infrastructure;
using ToDoApp.Infrastructure.Data.QueryServices;

namespace ToDoApp.Api
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (_env.IsDevelopment())
            {
                services.AddScoped<ITodoTaskGroupsService, TodoTaskGroupsServiceStub>();
                services.AddScoped<ITodoTasksService, TodoTasksServiceStub>();
            }
            else
            {
                services.AddScoped<ITodoTaskGroupsService, TodoTaskGroupsService>();
                services.AddScoped<ITodoTasksService, TodoTasksService>();
            }
            
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ToDo Api",
                    Description = "Api for managing todo tasks ",
                });
            });
            
            
            services.ConfigureDatabase(Configuration.GetValue<string>("connectionString"));
            
            //query services
            services.AddScoped<ITodoTaskGroupsQueryService, TodoTaskGroupsQueryService>();
            services.AddScoped<ITodoTasksQueryService, TodoTasksQueryService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = "swagger";
            });
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}