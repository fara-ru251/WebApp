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

namespace WebApp.Application.FrequentWords.Queries
{
    public class GetTopTenFrequentWordsQuery : IRequest<IList<FrequentWordVM>>
    {
    }
    public class GetTopTenFrequentWordsQueryHandler : IRequestHandler<GetTopTenFrequentWordsQuery, IList<FrequentWordVM>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTopTenFrequentWordsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IList<FrequentWordVM>> Handle(GetTopTenFrequentWordsQuery request, CancellationToken cancellationToken)
        {
            var words = await _context.FrequentWords
                    .OrderByDescending(t => t.Frequency)
                    .Take(10)
                    .AsNoTracking()
                    .ProjectTo<FrequentWordVM>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

            return words;
        }
    }
}
