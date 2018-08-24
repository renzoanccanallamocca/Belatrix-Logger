using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logger.WebApp;
using Logger.WebApp.Controllers;
using Logger.Model;
using Logger.Util;

namespace Logger.WebApp.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void TestIndexFile()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            JobLoggerModel model = new JobLoggerModel {
                Configuration = (int)Configuration.File,
                Message = "Hello Peru",
                TypeMessage = (int)TypeMessage.Error
            };

            ViewResult result = controller.Index(model) as ViewResult;

            // Assert
            Assert.AreEqual(true, result.TempData["Success"]);
        }

        [TestMethod]
        public void TestIndexDataBase()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            JobLoggerModel model = new JobLoggerModel
            {
                Configuration = (int)Configuration.Database,
                Message = "Hello Peru",
                TypeMessage = (int)TypeMessage.Error
            };

            ViewResult result = controller.Index(model) as ViewResult;

            // Assert
            Assert.AreEqual(true, result.TempData["Success"]);
        }
    }
}
