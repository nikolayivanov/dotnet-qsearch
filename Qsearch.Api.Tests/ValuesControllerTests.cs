using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Qsearch.Api.Controllers;
using System.Collections.Generic;

namespace Qsearch.Api.Tests
{
    [TestClass]
    public class ValuesControllerTests
    {
        private MockRepository mockRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        [TestCleanup]
        public void TestCleanup()
        {            
        }

        [TestMethod]
        public void GetTest()
        {
            // Arrange
            var controller = new ValuesController();

            // Act
            var result = controller.Get();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<ICollection<string>>));
            Assert.AreEqual(2, result.Value.Count);
        }
    }
}
