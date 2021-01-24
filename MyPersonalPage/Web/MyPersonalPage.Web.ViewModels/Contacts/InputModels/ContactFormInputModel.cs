namespace MyPersonalPage.Web.ViewModels.Contacts.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class ContactFormInputModel
    {
        [Required]
        [Display(Name = "Your name")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Your email")]
        public string Email { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "The Subject field must be at least 5 characters")]
        public string Subject { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "The Content field must be at least 10 characters")]
        [Display(Name = "Your message")]
        public string Content { get; set; }
    }
}
