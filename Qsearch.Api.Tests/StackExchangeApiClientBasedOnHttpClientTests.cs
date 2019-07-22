using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using QSearch.Core;
using QSearch.Core.Impl;
using System;
using System.Collections.Generic;

namespace Qsearch.Api.Tests
{
    [TestClass]
    public class StackExchangeApiClientBasedOnHttpClientTests
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
            // // Fail if one of Setup was not called
            this.mockRepository.VerifyAll();
        }

        private StackExchangeApiClientBasedOnHttpClient CreateStackExchangeApiClientBasedOnHttpClient()
        {
            return new StackExchangeApiClientBasedOnHttpClient();
        }

        [TestMethod]
        public void Search_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var stackExchangeApiClientBasedOnHttpClient = this.CreateStackExchangeApiClientBasedOnHttpClient();
            SearchQuery query = new SearchQuery()
            {
                QueryText = "Java"
            };

            // Act
            var result = stackExchangeApiClientBasedOnHttpClient.Search(query);


            // Assert
            Assert.IsTrue((new List<SearchResult>(result)).Count > 0);
        }
    }
}
