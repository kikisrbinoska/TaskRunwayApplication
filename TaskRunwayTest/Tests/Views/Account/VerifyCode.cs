using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TaskRunwayApplication.Models;

namespace TaskRunwayTest.Tests.Controllers
{
    
    [TestClass]
    public class VerifyCode
    {
        [TestMethod]
        public void Provider_Property_GetterSetter_Should_Work()
        {
            
            var model = new VerifyCodeViewModel();
            var expectedProvider = "Provider1";

            
            model.Provider = expectedProvider;
            var actualProvider = model.Provider;

            
            Assert.AreEqual(expectedProvider, actualProvider);
        }

        [TestMethod]
        public void Code_Property_GetterSetter_Should_Work()
        {
           
            var model = new VerifyCodeViewModel();
            var expectedCode = "123456";

            
            model.Code = expectedCode;
            var actualCode = model.Code;

           
            Assert.AreEqual(expectedCode, actualCode);
        }

        [TestMethod]
        public void ReturnUrl_Property_GetterSetter_Should_Work()
        {
            
            var model = new VerifyCodeViewModel();
            var expectedReturnUrl = "/some/return/url";

            
            model.ReturnUrl = expectedReturnUrl;
            var actualReturnUrl = model.ReturnUrl;

            
            Assert.AreEqual(expectedReturnUrl, actualReturnUrl);
        }

        [TestMethod]
        public void RememberBrowser_Property_GetterSetter_Should_Work()
        {
          
            var model = new VerifyCodeViewModel();
            var expectedRememberBrowser = true;

            
            model.RememberBrowser = expectedRememberBrowser;
            var actualRememberBrowser = model.RememberBrowser;

            
            Assert.AreEqual(expectedRememberBrowser, actualRememberBrowser);
        }

        [TestMethod]
        public void RememberMe_Property_GetterSetter_Should_Work()
        {
           
            var model = new VerifyCodeViewModel();
            var expectedRememberMe = true;

            model.RememberMe = expectedRememberMe;
            var actualRememberMe = model.RememberMe;

            
            Assert.AreEqual(expectedRememberMe, actualRememberMe);
        }

        [TestMethod]
        public void Provider_Property_Should_Have_Required_Attribute()
        {
            
            var model = new VerifyCodeViewModel();
            var validationContext = new ValidationContext(model);
            var results = new List<ValidationResult>();

            
            var isValid = Validator.TryValidateProperty(model.Provider,
                new ValidationContext(model) { MemberName = nameof(model.Provider) }, results);

            
            Assert.IsFalse(isValid); 
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("The Provider field is required.", results[0].ErrorMessage);
        }

        [TestMethod]
        public void Code_Property_Should_Have_Required_Attribute()
        {
            
            var model = new VerifyCodeViewModel();
            var validationContext = new ValidationContext(model);
            var results = new List<ValidationResult>();

           
            var isValid = Validator.TryValidateProperty(model.Code,
                new ValidationContext(model) { MemberName = nameof(model.Code) }, results);

            
            Assert.IsFalse(isValid); 
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("The Code field is required.", results[0].ErrorMessage);
        }
    }
}
