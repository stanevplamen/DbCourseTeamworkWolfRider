namespace CupOfCoffee.Models
{
    using MongoDB.Bson.Serialization.Attributes;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class MonthlySalary
    {
        [BsonId]
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
