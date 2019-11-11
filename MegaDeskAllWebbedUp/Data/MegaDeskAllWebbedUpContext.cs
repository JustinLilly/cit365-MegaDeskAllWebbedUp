using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MegaDeskAllWebbedUp.Models
{
    public class MegaDeskAllWebbedUpContext : DbContext
    {
        public MegaDeskAllWebbedUpContext (DbContextOptions<MegaDeskAllWebbedUpContext> options)
            : base(options)
        {
        }

        public DbSet<MegaDeskAllWebbedUp.Models.Quote> Quote { get; set; }
    }
}
