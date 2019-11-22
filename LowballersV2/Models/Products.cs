﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LowballersV2.Models
{
    public partial class Products
    {
        public Products()
        {
            Carts = new HashSet<Carts>();
            OrderDetails = new HashSet<OrderDetails>();
        }

        [Key]
        public int ProductId { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(8000)]
        public string Description { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        [Range(0, 1000000, ErrorMessage = "Price must be between 0 and 1000000")]
        [DisplayFormat(DataFormatString = "")]
        public decimal Price { get; set; }
        [StringLength(255)]
        public string Photo { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("Products")]
        public virtual Categories Category { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<Carts> Carts { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
