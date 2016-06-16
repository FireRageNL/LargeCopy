using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LargeCopies.Models
{
    public class ProductModel
    {
        [Required]
        [Display(Name="Productnaam")]
        public string Productname { get; set; }

        [Display(Name ="Omschrijving")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Kleur")]
        public string Color { get; set; }

        [Required]
        [Display(Name="Prijs")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required]
        [Display(Name="Thema")]
        public string Themes { get; set; }

        [Display(Name="Thema 2")]
        public string Themes2 { get; set; }

        [Display(Name="Thema 3")]
        public string Themes3 { get; set; }

        public int ProductID { get; set; }
    }
}
