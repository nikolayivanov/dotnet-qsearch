using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Qsearch.Web.Controllers;

namespace Qsearch.Web.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void Index_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var homeController = new HomeController();

            // Act
            ViewResult result = (ViewResult)homeController.Index();

            // Assert            
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
