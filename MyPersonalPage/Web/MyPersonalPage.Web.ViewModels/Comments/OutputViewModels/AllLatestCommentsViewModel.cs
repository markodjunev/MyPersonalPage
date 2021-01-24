namespace MyPersonalPage.Web.ViewModels.Comments.OutputViewModels
{
    using System.Collections.Generic;

    public class AllLatestCommentsViewModel
    {
        public IEnumerable<LatestCommentViewModel> Comments { get; set; }
    }
}
