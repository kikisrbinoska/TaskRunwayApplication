using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using TaskRunwayApplication.Models;

namespace TaskRunwayTest.Tests.Controllers
{
    
    [TestClass]
    public class ForgotPasswordTest
    {
        [TestMethod]
        public void Email_Property_GetterSetter_Should_Work()
        {
           
            var model = new ForgotPasswordViewModel();
            var expectedEmail = "test@example.com";

            model.Email = expectedEmail;
            var actualEmail = model.Email;

            
            Assert.AreEqual(expectedEmail, actualEmail);
        }

        [TestMethod]
        public void Email_Property_Should_Have_Required_Attribute()
        {
            
            var model = new ForgotPasswordViewModel();
            var validationContext = new ValidationContext(model);
            var results = new List<ValidationResult>();

            
            var isValid = Validator.TryValidateProperty(model.Email,
                new ValidationContext(model) { MemberName = nameof(model.Email) }, results);

            
            Assert.IsFalse(isValid);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("The Email field is required.", results[0].ErrorMessage);
        }

        [TestMethod]
        public void Email_Property_Should_Have_EmailAddress_Attribute()
        {
            
            var model = new ForgotPasswordViewModel();
            var property = typeof(ForgotPasswordViewModel).GetProperty(nameof(ForgotPasswordViewModel.Email));
            var emailAddressAttribute = (EmailAddressAttribute)property
                .GetCustomAttributes(typeof(EmailAddressAttribute), false)
                .FirstOrDefault();

            
            Assert.IsNotNull(emailAddressAttribute);
        }

        [TestMethod]
        public void Email_Property_Should_Have_Display_Attribute()
        {
            
            var model = new ForgotPasswordViewModel();
            var property = typeof(ForgotPasswordViewModel).GetProperty(nameof(ForgotPasswordViewModel.Email));
            var displayAttribute = (DisplayAttribute)property
                .GetCustomAttributes(typeof(DisplayAttribute), false)
                .FirstOrDefault();

            
            Assert.IsNotNull(displayAttribute);
            Assert.AreEqual("Email", displayAttribute.Name);
        }
    }
}
