namespace CupOfCoffee.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using MongoDB.Bson.Serialization.Attributes;

    public class Product
    {
        private ICollection<OrderDetail> orderDetails;
        
        public Product()
        {
            orderDetails = new HashSet<OrderDetail>();
        }

        [BsonId]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Column(TypeName = "money")]
        public decimal SellPrice { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails
        {
            get { return orderDetails; }
            set { orderDetails = value; }
        }
    }
}
