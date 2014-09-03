namespace CupOfCoffee.Models
{
    using MongoDB.Bson.Serialization.Attributes;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class OrderDetail
    {
        [BsonId]
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public bool HappyHour { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
