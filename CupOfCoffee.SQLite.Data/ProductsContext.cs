namespace CupOfCoffee.SQLite.Data
{
    using CupOfCoffee.SQLite.Data.Database;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ProductsContext : DbContext
    {

        public ProductsContext() 
        {
        }
        public IDbSet<VendorsProduct> VendorsProducts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions
                .Remove<PluralizingTableNameConvention>();
        }
    }
}
