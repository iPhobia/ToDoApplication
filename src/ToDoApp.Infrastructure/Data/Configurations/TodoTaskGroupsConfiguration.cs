using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoApp.Core.Entites;

namespace ToDoApp.Infrastructure.Data.Configurations
{
    public class TodoTaskGroupsConfiguration : IEntityTypeConfiguration<TodoTaskGroup>
    {
        public void Configure(EntityTypeBuilder<TodoTaskGroup> entity)
        {
            entity.Property(b => b.GroupName)
                .IsRequired();
            entity.HasData(new[]
            {
                new TodoTaskGroup
                {
                    Id = 1,
                    GroupName = "My day"
                }
            });
        }
    }
}