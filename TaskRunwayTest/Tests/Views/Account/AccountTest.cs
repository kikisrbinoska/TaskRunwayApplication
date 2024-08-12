using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TaskRunwayApplication.Models;

namespace TaskRunwayTest.Tests.Controllers
{
    
    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        public void Email_Property_GetterSetter_Should_Work()
        {
           
            var model = new ExternalLoginConfirmationViewModel();
            var expectedEmail = "test@example.com";

            
            model.Email = expectedEmail;
            var actualEmail = model.Email;

            
            Assert.AreEqual(expectedEmail, actualEmail);
        }

        [TestMethod]
        public void Email_Property_Should_Have_Required_Attribute()
        {
            
            var model = new ExternalLoginConfirmationViewModel();
            var validationContext = new ValidationContext(model);
            var results = new List<ValidationResult>();

            
            var isValid = Validator.TryValidateObject(model, validationContext, results, validateAllProperties: true);

            
            Assert.IsFalse(isValid); 
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("The Email field is required.", results[0].ErrorMessage);
        }
        [TestMethod]
        public void ReturnUrl_Property_GetterSetter_Should_Work()
        {
            
            var model = new ExternalLoginListViewModel();
            var expectedReturnUrl = "/some/return/url";

           
            model.ReturnUrl = expectedReturnUrl;
            var actualReturnUrl = model.ReturnUrl;

            
            Assert.AreEqual(expectedReturnUrl, actualReturnUrl);
        }
    }
}
