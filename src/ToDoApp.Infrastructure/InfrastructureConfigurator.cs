using Microsoft.Extensions.DependencyInjection;
using ToDoApp.Infrastructure.Data;

namespace ToDoApp.Infrastructure
{
    public static class InfrastructureConfigurator
    {
        public static void ConfigureDatabase(this IServiceCollection services)
        {
            services.AddDbContext<TodoDbContext>();
        }
    }
}