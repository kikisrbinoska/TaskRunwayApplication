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
    public class Login
    {
        [TestMethod]
        public void Email_Property_GetterSetter_Should_Work()
        {
           
            var model = new LoginViewModel();
            var expectedEmail = "test@example.com";

            
            model.Email = expectedEmail;
            var actualEmail = model.Email;

            
            Assert.AreEqual(expectedEmail, actualEmail);
        }

        [TestMethod]
        public void Password_Property_GetterSetter_Should_Work()
        {
          
            var model = new LoginViewModel();
            var expectedPassword = "password123";

           
            model.Password = expectedPassword;
            var actualPassword = model.Password;

            
            Assert.AreEqual(expectedPassword, actualPassword);
        }

        [TestMethod]
        public void RememberMe_Property_GetterSetter_Should_Work()
        {
            
            var model = new LoginViewModel();
            var expectedRememberMe = true;

            
            model.RememberMe = expectedRememberMe;
            var actualRememberMe = model.RememberMe;

            
            Assert.AreEqual(expectedRememberMe, actualRememberMe);
        }

        [TestMethod]
        public void Email_Property_Should_Have_Required_Attribute()
        {
            
            var model = new LoginViewModel();
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
            
            var model = new LoginViewModel();
            var property = typeof(LoginViewModel).GetProperty(nameof(LoginViewModel.Email));
            var emailAddressAttribute = (EmailAddressAttribute)property
                .GetCustomAttributes(typeof(EmailAddressAttribute), false)
                .FirstOrDefault();

            
            Assert.IsNotNull(emailAddressAttribute);
        }

        [TestMethod]
        public void Password_Property_Should_Have_Required_Attribute()
        {
           
            var model = new LoginViewModel();
            var validationContext = new ValidationContext(model);
            var results = new List<ValidationResult>();

            
            var isValid = Validator.TryValidateProperty(model.Password,
                new ValidationContext(model) { MemberName = nameof(model.Password) }, results);

            
            Assert.IsFalse(isValid); 
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("The Password field is required.", results[0].ErrorMessage);
        }

        [TestMethod]
        public void Password_Property_Should_Have_DataType_Password_Attribute()
        {
           
            var model = new LoginViewModel();
            var property = typeof(LoginViewModel).GetProperty(nameof(LoginViewModel.Password));
            var dataTypeAttribute = (DataTypeAttribute)property
                .GetCustomAttributes(typeof(DataTypeAttribute), false)
                .FirstOrDefault();

            
            Assert.IsNotNull(dataTypeAttribute);
            Assert.AreEqual(DataType.Password, dataTypeAttribute.DataType);
        }

        [TestMethod]
        public void Email_Property_Should_Have_Display_Attribute()
        {
            
            var model = new LoginViewModel();
            var property = typeof(LoginViewModel).GetProperty(nameof(LoginViewModel.Email));
            var displayAttribute = (DisplayAttribute)property
                .GetCustomAttributes(typeof(DisplayAttribute), false)
                .FirstOrDefault();

            
            Assert.IsNotNull(displayAttribute);
            Assert.AreEqual("Email", displayAttribute.Name);
        }

        [TestMethod]
        public void Password_Property_Should_Have_Display_Attribute()
        {
            
            var model = new LoginViewModel();
            var property = typeof(LoginViewModel).GetProperty(nameof(LoginViewModel.Password));
            var displayAttribute = (DisplayAttribute)property
                .GetCustomAttributes(typeof(DisplayAttribute), false)
                .FirstOrDefault();

           
            Assert.IsNotNull(displayAttribute);
            Assert.AreEqual("Password", displayAttribute.Name);
        }

        [TestMethod]
        public void RememberMe_Property_Should_Have_Display_Attribute()
        {
            
            var model = new LoginViewModel();
            var property = typeof(LoginViewModel).GetProperty(nameof(LoginViewModel.RememberMe));
            var displayAttribute = (DisplayAttribute)property
                .GetCustomAttributes(typeof(DisplayAttribute), false)
                .FirstOrDefault();

           
            Assert.IsNotNull(displayAttribute);
            Assert.AreEqual("Remember me?", displayAttribute.Name);
        }
    }
}
