using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoApp.Core.Entites;

namespace ToDoApp.Infrastructure.Data.Configurations
{
    public class TodoTaskConfiguration : IEntityTypeConfiguration<TodoTask>
    {
        public void Configure(EntityTypeBuilder<TodoTask> entity)
        {
            entity.Property(e => e.Content)
                .IsRequired();
        }
    }
}