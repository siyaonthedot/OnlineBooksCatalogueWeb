using Microsoft.EntityFrameworkCore;
using OnlineBooksCatalogue.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using OnlineBooksCatalogue.Core.Models;

namespace OnlineBooksCatalogue.Infrastructure
{
    public class OBCDbContext : DbContext
    {

        public OBCDbContext(DbContextOptions<OBCDbContext> contextOptions) : base(contextOptions)
        {
        
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Catalogue> Catalogues { get; set; }


    }
}
