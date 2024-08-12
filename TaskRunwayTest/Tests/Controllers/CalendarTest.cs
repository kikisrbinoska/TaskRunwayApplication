using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using TaskRunwayApplication.Controllers;
using TaskRunwayApplication.Models;

namespace TaskRunwayTest.Tests.Controllers
{
    [TestClass]
    public class CalendarTest
    {
        private Mock<ApplicationDbContext> _mockDbContext;
        private Mock<DbSet<Task>> _mockTaskSet;
        private TasksController _controller;

        [TestInitialize]
        public void SetUp()
        {
            
            _mockDbContext = new Mock<ApplicationDbContext>();
            _mockTaskSet = new Mock<DbSet<Task>>();

            var tasks = new List<Task>
            {
                new Task { Id = 1, Title = "Task 1", DueDate = new DateTime(2024, 8, 12), Spent = 120 },
                new Task { Id = 2, Title = "Task 2", DueDate = new DateTime(2024, 8, 13), Spent = 180 }
            }.AsQueryable();

            _mockTaskSet.As<IQueryable<Task>>().Setup(m => m.Provider).Returns(tasks.Provider);
            _mockTaskSet.As<IQueryable<Task>>().Setup(m => m.Expression).Returns(tasks.Expression);
            _mockTaskSet.As<IQueryable<Task>>().Setup(m => m.ElementType).Returns(tasks.ElementType);
            _mockTaskSet.As<IQueryable<Task>>().Setup(m => m.GetEnumerator()).Returns(tasks.GetEnumerator());

            _mockDbContext.Setup(c => c.Tasks).Returns(_mockTaskSet.Object);

            
            _controller = new TasksController();
            _controller.db = _mockDbContext.Object; 
        }

        [TestMethod]
        public void Calendar_ReturnsViewResult()
        {
            
            var result = _controller.Calendar() as ViewResult;

            
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}
