using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Core.Entites;

namespace ToDoApp.Infrastructure.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<TodoTask> TodoTasks { get; set; }
        public DbSet<TodoTaskGroup> TodoTaskGroups { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=tododb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}