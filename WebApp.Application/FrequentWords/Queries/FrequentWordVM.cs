using System;
using System.Collections.Generic;
using System.Text;
using WebApp.Application.Common.Mappings;
using WebApp.Domain.Entities;

namespace WebApp.Application.FrequentWords.Queries
{
    public class FrequentWordVM : IMapFrom<FrequentWord>
    {
        public string Name { get; set; }
        public int Frequency { get; set; }
    }
}
