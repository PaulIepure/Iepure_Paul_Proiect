using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AgentieTurism.Models;

namespace AgentieTurism.Data
{
    public class AgentieTurismContext : DbContext
    {
        public AgentieTurismContext (DbContextOptions<AgentieTurismContext> options)
            : base(options)
        {
        }

        public DbSet<AgentieTurism.Models.Client> Client { get; set; }

        public DbSet<AgentieTurism.Models.Offer> Offer { get; set; }

        public DbSet<AgentieTurism.Models.Reservation> Reservation { get; set; }
    }
}
