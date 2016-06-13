using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LargeCopies.Models
{
    public class ProductModel
    {
        [Required]
        [Display(Name="Productnaam")]
        public string Productname { get; set; }

        [Display(Name="Maat")]
        public string Productsize { get; set; }

        [Required]
        [Display(Name="Prijs")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name="Thema")]
        public string Themes { get; set; }

        [Display(Name="Thema 2")]
        public string Themes2 { get; set; }

        [Display(Name="Thema 3")]
        public string Themes3 { get; set; }
    }
}
