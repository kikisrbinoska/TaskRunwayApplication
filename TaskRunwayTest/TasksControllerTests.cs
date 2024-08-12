using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using TaskRunwayApplication.Controllers;
using TaskRunwayApplication.Models;

namespace TaskRunwayTest
{
    [TestClass]
    public class TasksControllerTests
    {
        /*private TasksController _controller;
        private Mock<ApplicationDbContext> _mockContext;
        private Mock<DbSet<Task>> _mockSet;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockSet = new Mock<DbSet<Task>>();
            _mockContext = new Mock<ApplicationDbContext>();
            _mockContext.Setup(m => m.Tasks).Returns(_mockSet.Object);

            
            _controller = new TasksController();

            var dbProperty = typeof(TasksController).GetProperty("db", BindingFlags.NonPublic | BindingFlags.Instance);
            if (dbProperty != null)
            {
                dbProperty.SetValue(_controller, _mockContext.Object);
            }
        }
        [TestMethod]
        public void Index_ReturnsViewResultWithListOfTasks()
        {
            // Arrange
            var tasks = new List<Task>
    {
        new Task { Id = 1, Title = "Task 1" },
        new Task { Id = 2, Title = "Task 2" }
    }.AsQueryable();

            _mockSet.As<IQueryable<Task>>().Setup(m => m.Provider).Returns(tasks.Provider);
            _mockSet.As<IQueryable<Task>>().Setup(m => m.Expression).Returns(tasks.Expression);
            _mockSet.As<IQueryable<Task>>().Setup(m => m.ElementType).Returns(tasks.ElementType);
            _mockSet.As<IQueryable<Task>>().Setup(m => m.GetEnumerator()).Returns(tasks.GetEnumerator());

            // Act
            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            var model = result.Model as List<Task>;
            Assert.AreEqual(2, model.Count);
        }
        [TestMethod]
        public void Details_TaskNotFound_ReturnsHttpNotFound()
        {
            // Arrange
            int taskId = 1;
            _mockSet.Setup(m => m.Find(taskId)).Returns((Task)null);

            // Act
            var result = _controller.Details(taskId);

            // Assert
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }

        [TestMethod]
        public void Details_TaskFound_ReturnsViewWithTask()
        {
            // Arrange
            int taskId = 1;
            var task = new Task { Id = taskId, Title = "Task 1" };
            _mockSet.Setup(m => m.Find(taskId)).Returns(task);

            // Act
            var result = _controller.Details(taskId) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            var model = result.Model as Task;
            Assert.AreEqual(taskId, model.Id);
        }

        [TestMethod]
        public void Create_ValidTask_RedirectsToCalendar()
        {
            // Arrange
            var task = new Task { Id = 1, Title = "Task 1" };

            // Act
            var result = _controller.Create(task) as RedirectToRouteResult;

            // Assert
            _mockSet.Verify(m => m.Add(It.IsAny<Task>()), Times.Once);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
            Assert.AreEqual("Calendar", result.RouteValues["action"]);
        }

        [TestMethod]
        public void Edit_ValidTask_RedirectsToIndex()
        {
            // Arrange
            var task = new Task { Id = 1, Title = "Task 1" };

            // Act
            var result = _controller.Edit(task) as RedirectToRouteResult;

            // Assert
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
        [TestMethod]
        public void DeleteConfirmed_ValidTask_RedirectsToIndex()
        {
            // Arrange
            int taskId = 1;
            var task = new Task { Id = taskId, Title = "Task 1" };
            _mockSet.Setup(m => m.Find(taskId)).Returns(task);

            // Act
            var result = _controller.DeleteConfirmed(taskId) as RedirectToRouteResult;

            // Assert
            _mockSet.Verify(m => m.Remove(It.IsAny<Task>()), Times.Once);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
        */


    }
}
