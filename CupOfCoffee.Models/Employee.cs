namespace CupOfCoffee.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Employee
    {
        private ICollection<CustomerFeedback> customerFeedbacks;
        private ICollection<MonthlySalary> monthlySalaries;
        private ICollection<Order> orders;
        
        public Employee()
        {
            customerFeedbacks = new HashSet<CustomerFeedback>();
            monthlySalaries = new HashSet<MonthlySalary>();
            orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int PositionId { get; set; }

        [Column(TypeName = "date")]
        public DateTime HireDate { get; set; }

        public virtual Position Position { get; set; }

        public ICollection<CustomerFeedback> CustomerFeedbacks
        {
            get { return customerFeedbacks; }
            set { customerFeedbacks = value; }
        }

        public ICollection<MonthlySalary> MonthlySalaries
        {
            get { return monthlySalaries; }
            set { monthlySalaries = value; }
        }

        public ICollection<Order> Orders
        {
            get { return orders; }
            set { orders = value; }
        }
    }
}
