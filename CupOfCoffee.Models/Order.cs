namespace CupOfCoffee.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using MongoDB.Bson.Serialization.Attributes;

    public class Order
    {
        private ICollection<CustomerFeedback> customerFeedbacks;
        private ICollection<OrderDetail> orderDetails;

        public Order()
        {
            customerFeedbacks = new HashSet<CustomerFeedback>();
            orderDetails = new HashSet<OrderDetail>();
        }

        [BsonId]
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public DateTime OrderDate { get; set; }

        public int? CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual ICollection<CustomerFeedback> CustomerFeedbacks
        {
            get { return customerFeedbacks; }
            set { customerFeedbacks = value; }
        }

        public virtual ICollection<OrderDetail> OrderDetails
        {
            get { return orderDetails; }
            set { orderDetails = value; }
        }
    }
}
