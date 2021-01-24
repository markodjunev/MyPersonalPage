namespace MyPersonalPage.Web.ViewModels.Comments.OutputViewModels
{
    using System.Collections.Generic;

    public class AllCommentsWithMyUsernameViewModel
    {
        public IEnumerable<CommentWithMyUsernameViewModel> Comments { get; set; }
    }
}
