using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApp.Domain.Entities;

namespace WebApp.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<NewsItem> News { get; set; }
        DbSet<FrequentWord> FrequentWords { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
