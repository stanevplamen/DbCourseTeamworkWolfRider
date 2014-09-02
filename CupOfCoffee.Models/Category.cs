﻿namespace CupOfCoffee.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        private ICollection<Product> products;

        public Category()
        {
            this.products = new HashSet<Product>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Product> Products
        {
            get { return products; }
            set { products = value; }
        }
    }
}