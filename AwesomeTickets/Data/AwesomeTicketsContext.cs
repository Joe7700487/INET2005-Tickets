using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AwesomeTickets.Models;

namespace AwesomeTickets.Data
{
    public class AwesomeTicketsContext : DbContext
    {
        public AwesomeTicketsContext (DbContextOptions<AwesomeTicketsContext> options)
            : base(options)
        {
        }

        public DbSet<AwesomeTickets.Models.Listing> Listing { get; set; } = default!;
        public DbSet<AwesomeTickets.Models.Category> Category { get; set; } = default!;
    }
}
