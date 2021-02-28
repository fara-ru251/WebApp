using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApp.Application.Common.Interfaces;

namespace WebApp.Application.News.Queries.GetNewsByDatetimeRange
{
    public class GetNewsByDatetimeRangeQuery : IRequest<IList<NewsItemVM>>
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public GetNewsByDatetimeRangeQuery(DateTime from, DateTime to)
        {
            From = from;
            To = to;
        }
    }
    public class GetNewsByDatetimeRangeQueryHandler : IRequestHandler<GetNewsByDatetimeRangeQuery, IList<NewsItemVM>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetNewsByDatetimeRangeQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IList<NewsItemVM>> Handle(GetNewsByDatetimeRangeQuery request, CancellationToken cancellationToken)
        {
            var news = await _context.News
                               .Where(w => w.CreatedOn >= request.From && w.CreatedOn <= request.To)
                               .AsNoTracking()
                               .ProjectTo<NewsItemVM>(_mapper.ConfigurationProvider)
                               .ToListAsync(cancellationToken);

            return news;
        }
    }
}
