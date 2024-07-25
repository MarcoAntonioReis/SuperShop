

using System;
using System.ComponentModel.DataAnnotations;

namespace SuperShop.Data.Entities
{
    public class Product : IEntity
    {
        //if the primary key has a different name use this
        //[Key]
        public int Id { get; set; }

        //sets as mandatory
        [Required]
        [MaxLength(50, ErrorMessage = "The field {0} can contain {1} characters length.")]
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        //the ? sets this data types as optional
        [Display(Name = "last Purchase")]
        public DateTime? LastPurchase { get; set; }

        [Display(Name = "Last Sale")]
        public DateTime? LastSale { get; set; }

        [Display(Name = "Is Available")]
        public bool IsAvailable { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public double Stock { get; set; }

        //The user that created the product
        public User User { get; set; }


    }
}
