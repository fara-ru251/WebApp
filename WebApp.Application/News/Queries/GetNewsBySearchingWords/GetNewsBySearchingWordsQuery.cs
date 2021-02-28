using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using WebApp.Application.Common.Interfaces;
using WebApp.Application.News.Queries.GetNewsByDatetimeRange;

namespace WebApp.Application.News.Queries.GetNewsBySearchingWords
{
    public class GetNewsBySearchingWordsQuery : IRequest<IList<NewsItemVM>>
    {
        public string Phrase { get; private set; }

        public GetNewsBySearchingWordsQuery(string phrase)
        {
            this.Phrase = phrase;
        }
    }
    public class GetNewsBySearchingWordsQueryHandler : IRequestHandler<GetNewsBySearchingWordsQuery, IList<NewsItemVM>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetNewsBySearchingWordsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IList<NewsItemVM>> Handle(GetNewsBySearchingWordsQuery request, CancellationToken cancellationToken)
        {
            var all_news = await _context.News
                               .AsNoTracking()
                               .ProjectTo<NewsItemVM>(_mapper.ConfigurationProvider)
                               .ToArrayAsync(cancellationToken);

            var search_words = TextSplittingAndRemovingSymbols(request.Phrase);
            Dictionary<string, bool> pairs = new Dictionary<string, bool>(StringComparer.Create(CultureInfo.InvariantCulture,
                                            CompareOptions.IgnoreCase));

            for (int i = 0; i < search_words.Length; i++)
            {
                pairs.Add(search_words[i], false);
            }

            return all_news.Where((news_item) =>
            {
                var news_words = TextSplittingAndRemovingSymbols(news_item.Text);

                var isFound = FindMatching(pairs.Count, pairs, news_words);
                if (isFound)
                {
                    return true;
                }
                return false;

            }).ToList();

            //for (int i = 0; i < all_news.Length; i++)
            //{
            //    var news_item = all_news[i];
            //    var news_words = TextSplittingAndRemovingSymbols(news_item.Text);

            //    var isFound = FindMatching(pairs.Count, pairs, news_words);
            //    if (isFound)
            //    {
            //        yield return news_item;
            //    }
            //}
        }

        private bool FindMatching(int countOfSearchingWords, Dictionary<string, bool> dict, string[] words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                if (dict.ContainsKey(word))
                {
                    dict[word] = true;
                }
            }

            int countOfFindedWords = 0;
            var copy_keys = dict.Keys.ToArray();
            for (int i = 0; i < copy_keys.Length; i++)
            {
                var key = copy_keys[i];
                if (dict[key] == true)
                {
                    countOfFindedWords++;
                    dict[key] = false;
                }
            }

            return countOfFindedWords == countOfSearchingWords;
        }

        private string[] TextSplittingAndRemovingSymbols(string text)
        {
            // Strip Invalid Characters from a String, leave only 'whitespace', '@', '-'
            var stripped = Regex.Replace(text, @"[^\w @-]", "", RegexOptions.None);

            // Split stripped text
            var splitted = stripped.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            return splitted;
        }
    }
}
