namespace CupOfCoffee.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using MongoDB.Bson.Serialization.Attributes;

    public class Customer
    {
        private ICollection<CustomerFeedback> customerFeedbacks;
        private ICollection<Order> orders;

        public Customer()
        {
            customerFeedbacks = new HashSet<CustomerFeedback>();
            orders = new HashSet<Order>();
        }

        [BsonId]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int CustomerStatusId { get; set; }

        public virtual CustomerStatus CustomerStatus { get; set; }

        public virtual ICollection<CustomerFeedback> CustomerFeedbacks 
        { 
            get { return this.customerFeedbacks; }
            set { this.customerFeedbacks = value; }
        }

        public virtual ICollection<Order> Orders
        {
            get { return this.orders; }
            set { this.orders = value; }
        }
    }
}
