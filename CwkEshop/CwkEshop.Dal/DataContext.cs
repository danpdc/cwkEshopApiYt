using CwkEshop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwkEshop.Dal
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)    
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
