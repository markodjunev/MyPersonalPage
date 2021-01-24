namespace MyPersonalPage.Web.ViewModels.Comments.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class CreateCommentInputModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "The content must be at least 3 characters.")]
        public string Content { get; set; }

        public string CreatorId { get; set; }
    }
}
