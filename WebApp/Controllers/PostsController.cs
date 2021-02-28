using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Application.News.Queries.GetNewsByDatetimeRange;

namespace WebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IList<NewsItemVM>> Get(DateTime from, DateTime to)
        {
            return await Mediator.Send(new GetNewsByDatetimeRangeQuery(from, to));
        }
    }
}
