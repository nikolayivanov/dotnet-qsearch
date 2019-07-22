using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using QSearch.Core;
using QSearch.Core.Impl;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Qsearch.Api.Tests
{
    [TestClass]
    public class QuestSearchServiceTestsWithMocks
    {
        private MockRepository mockRepository;

        private Mock<ICacheServiceAsync> mockCacheServiceAsync;
        private Mock<IStackExchangeApiConsumer> mockStackExchangeApiConsumer;

        private SearchQuery query = new SearchQuery()
        {
            QueryText = "Java"
        };

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockCacheServiceAsync = this.mockRepository.Create<ICacheServiceAsync>();
            this.mockStackExchangeApiConsumer = this.mockRepository.Create<IStackExchangeApiConsumer>();            

            var searchresults = new List<SearchResult>() {
                new SearchResult() { link = "https://stackoverflow.com/questions/57123506/appengine-java11-migrate-migrating-from-the-app-engine-specific-apis-java-prob", title = "appengine java11 migrate &quot;Migrating from the App Engine-specific APIs&quot; JAVA problem" },
                new SearchResult() { link = "https://stackoverflow.com/questions/57123506/appengine-java11-migrate-migrating-from-the-app-engine-specific-apis-java-prob", title = "appengine java11 migrate &quot;Migrating from the App Engine-specific APIs&quot; JAVA problem" }
            };

            this.mockCacheServiceAsync.Setup(a => a.addToCache(query, searchresults)).Returns(Task.CompletedTask);
            this.mockCacheServiceAsync.Setup(a => a.getFromCache(query)).Returns(Task.FromResult(searchresults));

            this.mockStackExchangeApiConsumer.Setup(a => a.Search(query)).Returns(searchresults);
        }

        [TestCleanup]
        public void TestCleanup()
        {            
        }

        private QuestSearchService CreateService()
        {
            return new QuestSearchService(
                this.mockCacheServiceAsync.Object,
                this.mockStackExchangeApiConsumer.Object);
        }

        [TestMethod]
        public async Task SearchAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var service = this.CreateService();

            // Act
            var result = await service.SearchAsync(query);

            // Assert
            Assert.AreEqual(2, result.Count);
        }
    }
}
