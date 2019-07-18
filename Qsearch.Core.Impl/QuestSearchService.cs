using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSearch.Core.Impl
{
    public class QuestSearchService : IQuestSearchService
    {
        private ICacheServiceAsync cachesrv;
        private IStackExchangeApiConsumer apiclient;

        public QuestSearchService(ICacheServiceAsync cachesrv, IStackExchangeApiConsumer apiclient)
        {
            this.cachesrv = cachesrv;
            this.apiclient = apiclient;
        }

        public async Task<List<SearchResult>> SearchAsync(SearchQuery query)
        {
            var result = await cachesrv.getFromCache(query);
            if (result != null && result.Count > 0)
            {
                return result;
            }

            var res = this.apiclient.Search(query);
            await cachesrv.addToCache(query, new List<SearchResult>(res)).ConfigureAwait(false);
            return new List<SearchResult>(res);
        }
    }
}
