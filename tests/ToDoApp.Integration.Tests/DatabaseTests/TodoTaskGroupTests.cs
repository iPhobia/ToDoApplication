using System.Linq;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ToDoApp.Core.Entites;
using ToDoApp.Infrastructure.Data;

namespace ToDoApp.Integration.Tests.DatabaseTests
{
    public class TodoTaskGroupTests
    {
        private TodoDbContext _dbContext;

        [OneTimeSetUp]
        protected void OneTimeSetup()
        {
            // перед тестами нужно поднять базу
            // docker-compose  up ms-sql-server
            
            var options = new DbContextOptionsBuilder<TodoDbContext>()
                .UseSqlServer("Server=localhost,1433;Database=tododb;User ID=sa;Password=Pa55w0rd2021");
            _dbContext = new TodoDbContext(options.Options);
            
            //костыль из за сидинга 
            _dbContext.Database.ExecuteSqlRaw("DELETE FROM dbo.TodoTasks");
            _dbContext.Database.ExecuteSqlRaw("DELETE FROM dbo.TodoTaskGroups");
            SeedData();
        }

        [OneTimeTearDown]
        protected void OneTimeTearDown()
        {
            _dbContext.Database.EnsureDeleted();
        }

        [Test]
        public void GroupInsert_Success()
        {
            //Arrange
            var group = new TodoTaskGroup
            {
                GroupName = "group null",
            };
            group.Tasks.Add(new TodoTask
            {
                Content = "bad content",
            });
            
            //Act
            var groupsBeforeAdd = _dbContext.TodoTaskGroups.Count();
            var tasksBeforeAdd = _dbContext.TodoTasks.Count();
            
            _dbContext.TodoTaskGroups.Add(group);
            _dbContext.SaveChanges();
            
            var groupsAfterAdd = _dbContext.TodoTaskGroups.Count();
            var tasksAfterAdd = _dbContext.TodoTasks.Count();

            //Assert
            Assert.Less(tasksBeforeAdd, tasksAfterAdd);
            Assert.Less(groupsBeforeAdd, groupsAfterAdd);
        }

        [Test]
        public void GroupUpdate_Success()
        {
            //Arrange, Act
            var group = _dbContext.TodoTaskGroups.First();
            var initalGroupName = group.GroupName;
            group.GroupName = "updated group";
            _dbContext.TodoTaskGroups.Update(group);
            var itemsUpdated = _dbContext.SaveChanges();

            //Assert
            Assert.AreEqual(1, itemsUpdated);
            Assert.AreNotEqual(initalGroupName, group.GroupName);
        }
        
        [Test]
        public void GroupDelete_Success()
        {
            //Arrange, Act
            var group = _dbContext.TodoTaskGroups.First();
            var itemsBeforeDelete = _dbContext.TodoTaskGroups.Count();
            _dbContext.TodoTaskGroups.Remove(group);
            var itemsDeleted = _dbContext.SaveChanges();
            var itemsAfterDelete = _dbContext.TodoTaskGroups.Count();

            //Assert
            Assert.NotZero(itemsDeleted);
            Assert.Greater(itemsBeforeDelete, itemsAfterDelete);
        }

        private void SeedData()
        {
            var group1 = new TodoTaskGroup
            {
                GroupName = "group null",
            };
            group1.Tasks.Add(new TodoTask
            {
                Content = "bad content",
            });
            
            var group2 = new TodoTaskGroup
            {
                GroupName = "group B",
            };
            group2.Tasks.Add(new TodoTask
            {
                Content = "to do do",
            });
            
            var groups = new[]
            {
                group1, group2
            };
            
            _dbContext.TodoTaskGroups.AddRange(groups);
            _dbContext.SaveChanges();
        }
    }
}