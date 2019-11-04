using ITP.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITP.WebApp.Data
{
    public class ITContext: DbContext
    {
        public DbSet<Customer> Customer{ get; set; }
        public ITContext(DbContextOptions<ITContext> options)
            :base(options)
        {
            this.Database.EnsureCreated();
        }
    }
}
