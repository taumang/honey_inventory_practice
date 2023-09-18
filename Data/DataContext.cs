using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace honey_inventory_practice.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options){

        }
        public DbSet<HoneyInventory> HoneyInventories => Set<HoneyInventory>();
    }
}

