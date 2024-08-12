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
    public class RegisterTest
    {
        [TestMethod]
        public void Email_Property_GetterSetter_Should_Work()
        {
            
            var model = new RegisterViewModel();
            var expectedEmail = "test@example.com";

            
            model.Email = expectedEmail;
            var actualEmail = model.Email;

           
            Assert.AreEqual(expectedEmail, actualEmail);
        }

        [TestMethod]
        public void Password_Property_GetterSetter_Should_Work()
        {
            
            var model = new RegisterViewModel();
            var expectedPassword = "password123";

           
            model.Password = expectedPassword;
            var actualPassword = model.Password;

            
            Assert.AreEqual(expectedPassword, actualPassword);
        }

        [TestMethod]
        public void ConfirmPassword_Property_GetterSetter_Should_Work()
        {
           
            var model = new RegisterViewModel();
            var expectedConfirmPassword = "password123";

            
            model.ConfirmPassword = expectedConfirmPassword;
            var actualConfirmPassword = model.ConfirmPassword;

            
            Assert.AreEqual(expectedConfirmPassword, actualConfirmPassword);
        }

        [TestMethod]
        public void Email_Property_Should_Have_Required_Attribute()
        {
           
            var model = new RegisterViewModel();
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
            
            var model = new RegisterViewModel();
            var property = typeof(RegisterViewModel).GetProperty(nameof(RegisterViewModel.Email));
            var emailAddressAttribute = (EmailAddressAttribute)property
                .GetCustomAttributes(typeof(EmailAddressAttribute), false)
                .FirstOrDefault();

           
            Assert.IsNotNull(emailAddressAttribute);
        }

        [TestMethod]
        public void Password_Property_Should_Have_Required_Attribute()
        {
           
            var model = new RegisterViewModel();
            var validationContext = new ValidationContext(model);
            var results = new List<ValidationResult>();

            
            var isValid = Validator.TryValidateProperty(model.Password,
                new ValidationContext(model) { MemberName = nameof(model.Password) }, results);

           
            Assert.IsFalse(isValid);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("The Password field is required.", results[0].ErrorMessage);
        }

        [TestMethod]
        public void Password_Property_Should_Have_StringLength_Attribute()
        {
           
            var model = new RegisterViewModel();
            var property = typeof(RegisterViewModel).GetProperty(nameof(RegisterViewModel.Password));
            var stringLengthAttribute = (StringLengthAttribute)property
                .GetCustomAttributes(typeof(StringLengthAttribute), false)
                .FirstOrDefault();

            
            Assert.IsNotNull(stringLengthAttribute);
            Assert.AreEqual(100, stringLengthAttribute.MaximumLength);
            Assert.AreEqual(6, stringLengthAttribute.MinimumLength);
        }

        [TestMethod]
        public void ConfirmPassword_Property_Should_Have_Compare_Attribute()
        {
            
            var model = new RegisterViewModel();
            var property = typeof(RegisterViewModel).GetProperty(nameof(RegisterViewModel.ConfirmPassword));
            var compareAttribute = (CompareAttribute)property
                .GetCustomAttributes(typeof(CompareAttribute), false)
                .FirstOrDefault();

          
            Assert.IsNotNull(compareAttribute);
            Assert.AreEqual("Password", compareAttribute.OtherProperty);
            Assert.AreEqual("The password and confirmation password do not match.", compareAttribute.ErrorMessage);
        }

        [TestMethod]
        public void ConfirmPassword_Property_Should_Have_Display_Attribute()
        {
           
            var model = new RegisterViewModel();
            var property = typeof(RegisterViewModel).GetProperty(nameof(RegisterViewModel.ConfirmPassword));
            var displayAttribute = (DisplayAttribute)property
                .GetCustomAttributes(typeof(DisplayAttribute), false)
                .FirstOrDefault();

            
            Assert.IsNotNull(displayAttribute);
            Assert.AreEqual("Confirm password", displayAttribute.Name);
        }
    }
}
