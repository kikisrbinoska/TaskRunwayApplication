using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using TaskRunwayApplication.Controllers;

namespace TaskRunwayTest.Tests.Controllers
{
    
    [TestClass]
    public class HomeTest
    {
        [TestMethod]
        public void Index_Returns_ViewResult()
        {
            var controller = new HomeController();

            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result, "Index action should return a ViewResult.");
        }
        [TestMethod]
        public void About_Returns_ViewResult()
        {
            var controller = new HomeController();

            var result = controller.About() as ViewResult;

            Assert.IsNotNull(result, "About action should return a ViewResult.");
        }
        [TestMethod]
        public void Contact_Returns_ViewResult()
        {
            
            var controller = new HomeController();

            
            var result = controller.Contact() as ViewResult;

            
            Assert.IsNotNull(result, "Contact action should return a ViewResult.");
        }
     


    }
}
