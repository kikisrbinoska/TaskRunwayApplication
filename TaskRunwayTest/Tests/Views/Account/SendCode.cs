using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using TaskRunwayApplication.Models;

namespace TaskRunwayTest.Tests.Controllers
{
    
    [TestClass]
    public class SendCode
    {
        [TestMethod]
        public void SelectedProvider_Property_GetterSetter_Should_Work()
        {
            
            var model = new SendCodeViewModel();
            var expectedProvider = "Provider1";

            
            model.SelectedProvider = expectedProvider;
            var actualProvider = model.SelectedProvider;

            
            Assert.AreEqual(expectedProvider, actualProvider);
        }

        [TestMethod]
        public void ReturnUrl_Property_GetterSetter_Should_Work()
        {
            
            var model = new SendCodeViewModel();
            var expectedReturnUrl = "/some/return/url";

           
            model.ReturnUrl = expectedReturnUrl;
            var actualReturnUrl = model.ReturnUrl;

         
            Assert.AreEqual(expectedReturnUrl, actualReturnUrl);
        }

        [TestMethod]
        public void RememberMe_Property_GetterSetter_Should_Work()
        {
            
            var model = new SendCodeViewModel();
            var expectedRememberMe = true;

            
            model.RememberMe = expectedRememberMe;
            var actualRememberMe = model.RememberMe;

           
            Assert.AreEqual(expectedRememberMe, actualRememberMe);
        }
    }
}
