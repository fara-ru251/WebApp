using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Application.News.Queries.GetNewsByDatetimeRange;
using WebApp.Application.News.Queries.GetNewsBySearchingWords;

namespace WebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IList<NewsItemVM>> Get(string text)
        {
            return await Mediator.Send(new GetNewsBySearchingWordsQuery(text));
        }
    }
}
