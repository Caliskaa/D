using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;
using Dem.Models;

namespace WebApplication3.Data
{
    public class WebApplication3Context : DbContext
    {
        public WebApplication3Context (DbContextOptions<WebApplication3Context> options)
            : base(options)
        {
        }

        public DbSet<WebApplication3.Models.RequestRemont> RequestRemont { get; set; } = default!;

        public DbSet<Dem.Models.RequestRegistary>? RequestRegistary { get; set; }

        public DbSet<Dem.Models.RequestProcessor>? RequestProcessor { get; set; }

        public DbSet<Dem.Models.RequestExecute>? RequestExecute { get; set; }

        public DbSet<Dem.Models.Report>? Report { get; set; }

        public DbSet<Dem.Models.Monitoring>? Monitoring { get; set; }

        public DbSet<Dem.Models.Client>? Client { get; set; }

        public DbSet<Dem.Models.Executor>? Executor { get; set; }
    }
}
