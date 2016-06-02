using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LargeCopies.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name ="Voornaam")]
        public string FirstName { get; set;}

        [Required]
        [Display(Name ="Achternaam")]
        public string LastName { get; set; }

        [Display(Name="Tussenvoegsel")]
        public string NameConnector { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Het wachtwoord bestaat uit minimaal {2} karakters.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Wachtwoord")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Bevestig wachtwoord")]
        [Compare("Password", ErrorMessage = "De wachtwoorden komen niet met elkaar overeen")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(10,ErrorMessage ="Een telefoonummer bestaat uit {2} cijfers",MinimumLength = 10)]
        [Display(Name ="Telefoonnummer")]
        public string Telephone { get; set; }

        [Required]
        [Display(Name ="Geslacht")]
        public string Sex { get; set; }
        [Required]
        [Display(Name ="Straatnaam")]
        public string Street { get; set; }

        [Required]
        [Display(Name = "Huisnummer")]
        public int Number { get; set; }

        [Display(Name ="Toevoeging")]
        public string Addition { get; set; }

        [Required]
        [Display(Name ="Postcode")]
        public string Zipcode { get; set; }

        [Required]
        [Display(Name ="Woonplaats")]
        public string City { get; set; }

        

    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
