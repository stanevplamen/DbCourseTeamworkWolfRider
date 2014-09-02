
namespace CupOfCoffee.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using CupOfCoffee.Models;

    public partial class CupOfCoffeeContext : DbContext
    {
        public CupOfCoffeeContext()
            : base("name=CupOfCoffeeDb")
        {
        }

        public virtual IDbSet<CustomerFeedback> CustomerFeedbacks { get; set; }
        public virtual IDbSet<Customer> Customers { get; set; }
        public virtual IDbSet<CustomerStatus> CustomerStatuses { get; set; }
        public virtual IDbSet<Employee> Employees { get; set; }
        public virtual IDbSet<MonthlySalary> MonthlySalaries { get; set; }
        public virtual IDbSet<OrderDetail> OrderDetails { get; set; }
        public virtual IDbSet<Order> Orders { get; set; }
        public virtual IDbSet<Position> Positions { get; set; }
        public virtual IDbSet<Product> Products { get; set; }
        public virtual IDbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerStatus>()
                .Property(e => e.Discount)
                .HasPrecision(3, 2);

            modelBuilder.Entity<CustomerStatus>()
                .HasMany(e => e.Customers)
                .WithRequired(e => e.CustomerStatus)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.CustomerFeedbacks)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.MonthlySalaries)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MonthlySalary>()
                .Property(e => e.Amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.CustomerFeedbacks)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Position>()
                .Property(e => e.BaseSalary)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Position>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Position)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.SellPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);
        }
    }
}
