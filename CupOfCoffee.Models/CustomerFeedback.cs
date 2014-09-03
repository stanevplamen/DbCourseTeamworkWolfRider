namespace CupOfCoffee.Models
{
    using MongoDB.Bson.Serialization.Attributes;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class CustomerFeedback
    {
        [BsonId]
        public int Id { get; set; }

        public int? CustomerId { get; set; }

        public int EmployeeId { get; set; }

        public int OrderId { get; set; }

        public CustomerEvaluation Evaluation { get; set; }

        [Column(TypeName = "text")]
        public string Content { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Order Order { get; set; }
    }
}
