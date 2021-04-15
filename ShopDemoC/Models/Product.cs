﻿namespace Shop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web.Mvc;

    public class Product
    {
        public Product()
        {
            //this.OrderDetails = new HashSet<OrderDetail>();
            //this.Prices = new HashSet<Price>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }    // implicit PK, Identity field

        [MaxLength(250)]
        [Display(Name = "Product name")]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [MaxLength(150)]
        public string Brand { get; set; }

        [Required]
        [Display(Name = "Product ID")]
        public long CategoryId { get; set; }

        [AllowHtml]
        [MaxLength(500, ErrorMessage = "Content is too length.")]
        public string Description { get; set; }

        [AllowHtml]
        [MaxLength(500, ErrorMessage = "Content is too length.")]
        public string Info { get; set; }

        [MaxLength(250)]
        [Display(Name = "Featured image")]
        public string FeatureImage { get; set; }

        [MaxLength(250)]
        public string ImgLink1 { get; set; }

        [MaxLength(250)]
        public string ImgLink2 { get; set; }

        [MaxLength(250)]
        public string ImgLink3 { get; set; }

        [MaxLength(250)]
        public string ImgLink4 { get; set; }

        //TODO: add product quantity

        public PublishStatus Status { get; set; }

        [Display(Name = "Publish on date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", NullDisplayText = "", ApplyFormatInEditMode = true)]
        public DateTime PublishDate { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Price> Prices { get; set; }
    }
}