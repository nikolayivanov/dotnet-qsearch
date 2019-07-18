using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QSearch.Core;

namespace Qsearch.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class QSearchController : ControllerBase
    {
        private IQuestSearchService qsearchsrv;
        private ILogger<QSearchController> logger;

        public QSearchController(IQuestSearchService qsearchsrv, ILogger<QSearchController> logger)
        {
            this.qsearchsrv = qsearchsrv;
            this.logger = logger;
        }

        [HttpGet]
        [Route("search")]
        public async Task<ActionResult<IEnumerable<SearchResult>>> Search([FromQuery]string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                ModelState.AddModelError("empty.query", "Parameter <query> is empty string.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid request.");
            }

            try
            {
                this.logger.LogDebug("SearchAsync call with QueryText=[{0}]", query);
                return await this.qsearchsrv.SearchAsync(new SearchQuery() { QueryText = query });
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "An error has occurred during SearchAsync call. ex.message=[{0}]", ex.Message);
                return Ok(new List<SearchResult>());
            }
        }

        [HttpGet]
        [Route("search2")]
        public ActionResult<IEnumerable<SearchResult>> Search2([FromQuery]string query)
        {
            return Ok(new List<SearchResult>());
        }
    }
}
