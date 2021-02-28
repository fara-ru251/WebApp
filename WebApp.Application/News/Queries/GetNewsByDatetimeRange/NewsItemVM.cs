using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebApp.Application.Common.Mappings;
using WebApp.Domain.Entities;

namespace WebApp.Application.News.Queries.GetNewsByDatetimeRange
{
    public class NewsItemVM : IMapFrom<NewsItem>
    {
        public string Title { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Text { get; set; }

    }
}
