using System.ComponentModel.DataAnnotations;

namespace LargeCopies.Models
{
    public class ThemaModel
    {
        [Required]
        [Display(Name="Naam")]
        public string Name { get; set; }

        [Required]
        [Display(Name="Omschrijving")]
        public string Desc { get; set; }

        [Display(Name="Hoofdthema")]
        public string Theme { get; set; }

        public ThemaModel mainTheme { get; set; }
    }
}