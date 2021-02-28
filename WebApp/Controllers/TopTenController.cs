using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Application.FrequentWords.Queries;

namespace WebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopTenController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IList<FrequentWordVM>> Get()
        {
            return await Mediator.Send(new GetTopTenFrequentWordsQuery());
        }
    }
}
