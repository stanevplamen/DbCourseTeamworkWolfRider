using RidersCoffees.Models;
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
    public class RidersCoffeesContext : DbContext
    {
        public DbSet<CoffeePlace> CoffeePlaces { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }

        public RidersCoffeesContext()
            : base("RidersCoffeePlacesDb")
        {

        }

    }
}
