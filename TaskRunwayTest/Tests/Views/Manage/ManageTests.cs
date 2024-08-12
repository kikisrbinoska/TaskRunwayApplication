using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TaskRunwayApplication.Models;

namespace TaskRunwayTest.Tests.Views.Manage
{
   
    [TestClass]
    public class ManageTests
    {
        [TestMethod]
        public void IndexViewModel_ShouldHaveDefaultValues()
        {
            var model = new IndexViewModel();

            Assert.IsFalse(model.HasPassword);
            //Assert.IsNotNull(model.Logins);
            //Assert.AreEqual(0, model.Logins.Count);
            Assert.IsNull(model.PhoneNumber);
            Assert.IsFalse(model.TwoFactor);
            Assert.IsFalse(model.BrowserRemembered);
        }

        [TestMethod]
        public void FactorViewModel_ShouldHaveDefaultValues()
        {
            var model = new FactorViewModel();

            Assert.IsNull(model.Purpose);
        }

        [TestMethod]
        public void SetPasswordViewModel_ShouldHaveValidationErrors_WhenPropertiesAreInvalid()
        {
            var model = new SetPasswordViewModel
            {
                NewPassword = "short",
                ConfirmPassword = "shoRt"
            };

            var context = new ValidationContext(model, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(model, context, results, true);

            Assert.IsFalse(isValid);
            Assert.AreEqual(2, results.Count);
        }

        [TestMethod]
        public void SetPasswordViewModel_ShouldBeValid_WhenPropertiesAreCorrect()
        {
            var model = new SetPasswordViewModel
            {
                NewPassword = "ValidPassword123",
                ConfirmPassword = "ValidPassword123"
            };

            var context = new ValidationContext(model, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(model, context, results, true);

            Assert.IsTrue(isValid);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void ChangePasswordViewModel_ShouldHaveValidationErrors_WhenPropertiesAreInvalid()
        {
            var model = new ChangePasswordViewModel
            {
                OldPassword = "",
                NewPassword = "short",
                ConfirmPassword = "different"
            };

            var context = new ValidationContext(model, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(model, context, results, true);

            Assert.IsFalse(isValid);
            Assert.AreEqual(3, results.Count);
        }

        [TestMethod]
        public void ChangePasswordViewModel_ShouldBeValid_WhenPropertiesAreCorrect()
        {
            var model = new ChangePasswordViewModel
            {
                OldPassword = "OldPassword123",
                NewPassword = "NewValidPassword123",
                ConfirmPassword = "NewValidPassword123"
            };

            var context = new ValidationContext(model, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(model, context, results, true);

            Assert.IsTrue(isValid);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void AddPhoneNumberViewModel_ShouldHaveValidationErrors_WhenNumberIsInvalid()
        {
            var model = new AddPhoneNumberViewModel
            {
                Number = "invalid"
            };

            var context = new ValidationContext(model, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(model, context, results, true);

            Assert.IsFalse(isValid);
            Assert.AreEqual(1, results.Count);
        }

        [TestMethod]
        public void AddPhoneNumberViewModel_ShouldBeValid_WhenNumberIsCorrect()
        {
            var model = new AddPhoneNumberViewModel
            {
                Number = "+1234567890"
            };

            var context = new ValidationContext(model, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(model, context, results, true);

            Assert.IsTrue(isValid);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void VerifyPhoneNumberViewModel_ShouldHaveValidationErrors_WhenPropertiesAreInvalid()
        {
            var model = new VerifyPhoneNumberViewModel
            {
                Code = "",
                PhoneNumber = "invalid"
            };

            var context = new ValidationContext(model, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(model, context, results, true);

            Assert.IsFalse(isValid);
            Assert.AreEqual(2, results.Count);
        }

        [TestMethod]
        public void VerifyPhoneNumberViewModel_ShouldBeValid_WhenPropertiesAreCorrect()
        {
            var model = new VerifyPhoneNumberViewModel
            {
                Code = "123456",
                PhoneNumber = "+1234567890"
            };

            var context = new ValidationContext(model, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(model, context, results, true);

            Assert.IsTrue(isValid);
            Assert.AreEqual(0, results.Count);
        }
    }
}
