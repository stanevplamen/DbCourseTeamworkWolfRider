namespace CupOfCoffee.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CustomerStatuses")]
    public class CustomerStatus
    {
        private ICollection<Customer> customers;

        public CustomerStatus()
        {
            customers = new HashSet<Customer>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public decimal Discount { get; set; }

        public virtual ICollection<Customer> Customers
        {
            get { return customers; }
            set { customers = value; }
        }
    }
}
