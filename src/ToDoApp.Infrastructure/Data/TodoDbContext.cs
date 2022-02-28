using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Core.Entites;

namespace ToDoApp.Infrastructure.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            :base(options)
        {
            Database.Migrate();
        }
        // public TodoDbContext()
        // {
        //     Database.EnsureCreated();
        // }

        public DbSet<TodoTask> TodoTasks { get; set; }
        public DbSet<TodoTaskGroup> TodoTaskGroups { get; set; }


        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     //optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=tododb;Trusted_Connection=True;");
        //     var connectionString = Environment.GetEnvironmentVariable("connectionString");
        //     Console.WriteLine(connectionString);
        //     optionsBuilder.UseSqlServer(connectionString);
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}