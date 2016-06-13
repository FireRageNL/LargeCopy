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

        [Display(Name="Thema")]
        public List<ThemaModel> Themes { get; set; }
    }
}
