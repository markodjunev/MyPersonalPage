namespace MyPersonalPage.Web.ViewModels.Comments.OutputViewModels
{
    using System;

    using MyPersonalPage.Data.Models;
    using MyPersonalPage.Services.Mapping;

    public class CommentWithMyUsernameViewModel : IMapFrom<Comment>
    {
        public string Username { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
