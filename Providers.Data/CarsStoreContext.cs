using CarsStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providers.Data
{
    /// <summary>
    /// MS SQL Server Provider
    /// </summary>
    public class CarsStoreContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Car> Cars { get; set; }

        public CarsStoreContext()
            : base("CarsStoreDb")
        {

        }

    }
}
