namespace Shopping.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.IO;
    using System.Web;
    

    [Table("Product")]
    public partial class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Product id is required")]
        [StringLength(200)]
        public string ProductId { get; set; }
        [Required(ErrorMessage = "Product name is required")]
        [StringLength(200)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Product price is required")]
        public decimal? Price { get; set; }
        [Required(ErrorMessage = "Product image is required")]
        [DisplayName("Upload image")]
        [StringLength(200)]
        public string ImagePath { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        public int? Quantity { get; set; }
    }
}
