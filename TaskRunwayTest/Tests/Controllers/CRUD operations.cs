using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TaskRunwayApplication.Controllers;
using TaskRunwayApplication.Models;

namespace TaskRunwayApplication.Tests.Controllers
{
    [TestClass]
    public class TasksControllerTests
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
        public void Delete_Returns_ViewResult_With_Task()
        {
            
            var taskId = 1;
            var task = new Task { Id = taskId, Title = "Task 1", Description = "Description 1", DueDate = DateTime.Now, Spent = 0, TaskStatus = TaskStatus.NotStarted, Category = "Category 1" };

            var mockTasksSet = new Mock<DbSet<Task>>();
            mockTasksSet.As<IQueryable<Task>>().Setup(m => m.Provider).Returns(new List<Task> { task }.AsQueryable().Provider);
            mockTasksSet.As<IQueryable<Task>>().Setup(m => m.Expression).Returns(new List<Task> { task }.AsQueryable().Expression);
            mockTasksSet.As<IQueryable<Task>>().Setup(m => m.ElementType).Returns(new List<Task> { task }.AsQueryable().ElementType);
            mockTasksSet.As<IQueryable<Task>>().Setup(m => m.GetEnumerator()).Returns(new List<Task> { task }.AsQueryable().GetEnumerator());
            mockTasksSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns(task);

            _mockDbContext.Setup(c => c.Tasks).Returns(mockTasksSet.Object);

            _controller = new TasksController
            {
                db = _mockDbContext.Object
            };

            
            var result = _controller.Delete(taskId) as ViewResult;

            
            Assert.IsNotNull(result);
            var model = result.Model as Task;
            Assert.IsNotNull(model);
            Assert.AreEqual(taskId, model.Id);
            Assert.AreEqual("Task 1", model.Title);
        }

        [TestMethod]
        public void Delete_Post_ValidModel_Redirects_To_Index()
        {
            
            var taskId = 1;

            var mockTasksSet = new Mock<DbSet<Task>>();
            mockTasksSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns(new Task { Id = taskId });
            mockTasksSet.Setup(m => m.Remove(It.IsAny<Task>())).Callback<Task>(task =>
            {
                
            });

            _mockDbContext.Setup(c => c.Tasks).Returns(mockTasksSet.Object);

            _controller = new TasksController
            {
                db = _mockDbContext.Object
            };

            
            var result = _controller.DeleteConfirmed(taskId) as RedirectToRouteResult;

            
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void Index_Returns_ViewResult_With_ListOfTasks()
        {
            
            var result = _controller.Index() as ViewResult;

            
            Assert.IsNotNull(result);
            var model = result.Model as List<Task>;
            Assert.IsNotNull(model);
            Assert.AreEqual(2, model.Count);
            Assert.AreEqual("Task 1", model[0].Title);
            Assert.AreEqual("Task 2", model[1].Title);
        }

        [TestMethod]
        public void Details_Returns_ViewResult_With_Task()
        {
            
            var result = _controller.Details(1) as ViewResult;

            
            Assert.IsNotNull(result);
            var model = result.Model as Task;
            Assert.IsNotNull(model);
            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Task 1", model.Title);
        }

        [TestMethod]
        public void Details_Returns_BadRequest_For_Null_Id()
        {
            
            var result = _controller.Details(null) as HttpStatusCodeResult;

            
            Assert.IsNotNull(result);
            Assert.AreEqual((int)HttpStatusCode.BadRequest, result.StatusCode);
        }

        [TestMethod]
        public void Details_Returns_NotFound_For_Invalid_Id()
        {
            
            var result = _controller.Details(999) as HttpNotFoundResult;

            
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create_Returns_ViewResult()
        {
            
            var result = _controller.Create() as ViewResult;

            
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create_Post_ValidModel_Redirects_To_Calendar()
        {
           
            var newTask = new Task
            {
                Id = 3,
                Title = "New Task",
                Description = "New Description",
                DueDate = DateTime.Now.AddDays(1),
                Spent = 0,
                TaskStatus = TaskStatus.NotStarted,
                Category = "New Category"
            };

            var mockTasksSet = new Mock<DbSet<Task>>();
            mockTasksSet.As<IQueryable<Task>>().Setup(m => m.Provider).Returns(new List<Task>
            {
                new Task { Id = 1, Title = "Task 1", Description = "Description 1", DueDate = DateTime.Now, Spent = 0, TaskStatus = TaskStatus.NotStarted, Category = "Category 1" },
                new Task { Id = 2, Title = "Task 2", Description = "Description 2", DueDate = DateTime.Now, Spent = 0, TaskStatus = TaskStatus.InProgress, Category = "Category 2" }
            }.AsQueryable().Provider);

            mockTasksSet.As<IQueryable<Task>>().Setup(m => m.Expression).Returns(new List<Task>
            {
                new Task { Id = 1, Title = "Task 1", Description = "Description 1", DueDate = DateTime.Now, Spent = 0, TaskStatus = TaskStatus.NotStarted, Category = "Category 1" },
                new Task { Id = 2, Title = "Task 2", Description = "Description 2", DueDate = DateTime.Now, Spent = 0, TaskStatus = TaskStatus.InProgress, Category = "Category 2" }
            }.AsQueryable().Expression);
            mockTasksSet.As<IQueryable<Task>>().Setup(m => m.ElementType).Returns(new List<Task>
            {
                new Task { Id = 1, Title = "Task 1", Description = "Description 1", DueDate = DateTime.Now, Spent = 0, TaskStatus = TaskStatus.NotStarted, Category = "Category 1" },
                new Task { Id = 2, Title = "Task 2", Description = "Description 2", DueDate = DateTime.Now, Spent = 0, TaskStatus = TaskStatus.InProgress, Category = "Category 2" }
            }.AsQueryable().ElementType);
            mockTasksSet.As<IQueryable<Task>>().Setup(m => m.GetEnumerator()).Returns(new List<Task>
            {
                new Task { Id = 1, Title = "Task 1", Description = "Description 1", DueDate = DateTime.Now, Spent = 0, TaskStatus = TaskStatus.NotStarted, Category = "Category 1" },
                new Task { Id = 2, Title = "Task 2", Description = "Description 2", DueDate = DateTime.Now, Spent = 0, TaskStatus = TaskStatus.InProgress, Category = "Category 2" }
            }.AsQueryable().GetEnumerator());

            mockTasksSet.Setup(m => m.Add(It.IsAny<Task>())).Callback<Task>(task =>
            {
                
                var taskList = new List<Task>
                {
                    new Task { Id = 1, Title = "Task 1", Description = "Description 1", DueDate = DateTime.Now, Spent = 0, TaskStatus = TaskStatus.NotStarted, Category = "Category 1" },
                    new Task { Id = 2, Title = "Task 2", Description = "Description 2", DueDate = DateTime.Now, Spent = 0, TaskStatus = TaskStatus.InProgress, Category = "Category 2" },
                    task 
                };
                mockTasksSet.As<IQueryable<Task>>().Setup(m => m.Provider).Returns(taskList.AsQueryable().Provider);
                mockTasksSet.As<IQueryable<Task>>().Setup(m => m.Expression).Returns(taskList.AsQueryable().Expression);
            });

            _mockDbContext.Setup(c => c.Tasks).Returns(mockTasksSet.Object);

            _controller = new TasksController
            {
                db = _mockDbContext.Object
            };

            
            var result = _controller.Create(newTask) as RedirectToRouteResult;

            
            Assert.IsNotNull(result);
            Assert.AreEqual("Calendar", result.RouteValues["action"]);
        }

        [TestMethod]
        public void Create_Post_InvalidModel_Returns_Create_View()
        {
            
            _controller.ModelState.AddModelError("Title", "Required");

            var invalidTask = new Task
            {
                Id = 3,
                Title = "", 
                Description = "Invalid Description",
                DueDate = DateTime.Now.AddDays(1),
                Spent = 0,
                TaskStatus = TaskStatus.NotStarted,
                Category = "New Category"
            };

         
            var result = _controller.Create(invalidTask) as ViewResult;

            Assert.IsNotNull(result);
            var model = result.Model as Task;
            Assert.IsNotNull(model);
            Assert.AreEqual(invalidTask, model);
        }

        [TestMethod]
        public void Edit_Returns_ViewResult_With_Task()
        {
            
            var taskId = 1;
            var task = new Task { Id = taskId, Title = "Task 1", Description = "Description 1", DueDate = DateTime.Now, Spent = 0, TaskStatus = TaskStatus.NotStarted, Category = "Category 1" };

            var mockTasksSet = new Mock<DbSet<Task>>();
            mockTasksSet.As<IQueryable<Task>>().Setup(m => m.Provider).Returns(new List<Task> { task }.AsQueryable().Provider);
            mockTasksSet.As<IQueryable<Task>>().Setup(m => m.Expression).Returns(new List<Task> { task }.AsQueryable().Expression);
            mockTasksSet.As<IQueryable<Task>>().Setup(m => m.ElementType).Returns(new List<Task> { task }.AsQueryable().ElementType);
            mockTasksSet.As<IQueryable<Task>>().Setup(m => m.GetEnumerator()).Returns(new List<Task> { task }.AsQueryable().GetEnumerator());
            mockTasksSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns(task);

            _mockDbContext.Setup(c => c.Tasks).Returns(mockTasksSet.Object);

            _controller = new TasksController
            {
                db = _mockDbContext.Object
            };

            
            var result = _controller.Edit(taskId) as ViewResult;

            Assert.IsNotNull(result);
            var model = result.Model as Task;
            Assert.IsNotNull(model);
            Assert.AreEqual(taskId, model.Id);
            Assert.AreEqual("Task 1", model.Title);
        }

          

    }
}
