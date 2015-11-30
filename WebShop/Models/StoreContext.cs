using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebShop.Models
{
    public class StoreContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}