namespace MyPersonalPage.Web.ViewModels.Comments.OutputViewModels
{
    using System;

    using MyPersonalPage.Data.Models;
    using MyPersonalPage.Services.Mapping;

    public class LatestCommentViewModel : IMapFrom<Comment>
    {
        public string Username { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
