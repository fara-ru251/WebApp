using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Domain.Entities
{
    public class NewsItem
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Text { get; set; }

        public string Url { get; set; }
    }
}
