using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
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
    public class GetEvents
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
        public void GetEvents_ReturnsJsonResultWithCorrectData()
        {
            
            var result = _controller.GetEvents() as JsonResult;

            
            Assert.IsNotNull(result, "The result should be a JsonResult.");

            var jsonData = JsonConvert.SerializeObject(result.Data);
            var events = JsonConvert.DeserializeObject<List<EventViewModel>>(jsonData);

            Assert.IsNotNull(events, "The events list should not be null.");
            Assert.AreEqual(2, events.Count, "The number of events should be 2.");

            Assert.AreEqual("Task 1", events[0].Title, "The title of the first event should be 'Task 1'.");
            Assert.AreEqual("2024-08-12T00:00:00", events[0].Start, "The start date of the first event should be '2024-08-12T00:00:00'.");

            Assert.AreEqual("Task 2", events[1].Title, "The title of the second event should be 'Task 2'.");
            Assert.AreEqual("2024-08-13T00:00:00", events[1].Start, "The start date of the second event should be '2024-08-13T00:00:00'.");
        }

        private class EventViewModel
        {
            public string Title { get; set; }
            public string Start { get; set; }
        }
    }
}
