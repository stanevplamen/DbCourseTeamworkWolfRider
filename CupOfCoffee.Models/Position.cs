namespace CupOfCoffee.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    using MongoDB.Bson.Serialization.Attributes;

    public class Position
    {
        private ICollection<Employee> employees;

        public Position()
        {
            employees = new HashSet<Employee>();
        }

        [BsonId]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "money")]
        public decimal BaseSalary { get; set; }

        public virtual ICollection<Employee> Employees
        {
            get { return employees; }
            set { employees = value; }
        }
    }
}
