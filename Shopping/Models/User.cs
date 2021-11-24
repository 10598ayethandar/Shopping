namespace Shopping.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "User name is required")]
        [StringLength(2000)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(200)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [StringLength(200)]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "User type is required")]
        [StringLength(200)]
        public string UserType { get; set; }
    }
}
