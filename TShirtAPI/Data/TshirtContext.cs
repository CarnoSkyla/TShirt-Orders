using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TShirtAPI.Models;

namespace TShirtAPI.Data
{
    public class TshirtContext : DbContext
    {
        public TshirtContext(DbContextOptions<TshirtContext> options)
            : base(options)
        {
        }

        public DbSet<tshirt> TSHIRTS { get; set; }
    }
}
