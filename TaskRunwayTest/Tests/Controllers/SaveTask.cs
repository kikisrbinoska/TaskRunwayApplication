using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using TaskRunwayApplication.Controllers;
using TaskRunwayApplication.Models;

namespace TaskRunwayTest.Tests.Controllers
{
    
    [TestClass]
    public class SaveTask
    {

        private Mock<ApplicationDbContext> _mockDbContext;
        private TasksController _controller;

        [TestInitialize]
        public void Setup()
        {
            var mockTasks = new List<Task>
    {
        new Task { Id = 1, Title = "Task 1", Description = "Description 1", DueDate = DateTime.Now, Spent = 0, TaskStatus = TaskStatus.NotStarted, Category = "Category 1" },
        new Task { Id = 2, Title = "Task 2", Description = "Description 2", DueDate = DateTime.Now, Spent = 0, TaskStatus = TaskStatus.InProgress, Category = "Category 2" }
    }.AsQueryable();

            var mockTasksSet = new Mock<DbSet<Task>>();
            mockTasksSet.As<IQueryable<Task>>().Setup(m => m.Provider).Returns(mockTasks.Provider);
            mockTasksSet.As<IQueryable<Task>>().Setup(m => m.Expression).Returns(mockTasks.Expression);
            mockTasksSet.As<IQueryable<Task>>().Setup(m => m.ElementType).Returns(mockTasks.ElementType);
            mockTasksSet.As<IQueryable<Task>>().Setup(m => m.GetEnumerator()).Returns(mockTasks.GetEnumerator());
            mockTasksSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns<object[]>(ids => mockTasks.SingleOrDefault(t => t.Id == (int)ids[0]));

            _mockDbContext = new Mock<ApplicationDbContext>();
            _mockDbContext.Setup(c => c.Tasks).Returns(mockTasksSet.Object);

            _controller = new TasksController
            {
                db = _mockDbContext.Object
            };
        }
       [TestMethod]
        public void SaveTasks_Handles_Empty_Form()
        {
            
            var form = new FormCollection(); 

          
            var result = _controller.SaveTasks(form) as RedirectToRouteResult;

            
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);

            
            _mockDbContext.Verify(c => c.SaveChanges(), Times.Never, "SaveChanges should not be called for an empty form.");
        }

    }
}
