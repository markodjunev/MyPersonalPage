namespace MyPersonalPage.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    using MyPersonalPage.Services.Data.Interfaces;
    using MyPersonalPage.Web.ViewModels;
    using MyPersonalPage.Web.ViewModels.Comments.OutputViewModels;

    public class HomeController : BaseController
    {
        private readonly ICommentsService commentsService;

        public HomeController(ICommentsService commentsService)
        {
            this.commentsService = commentsService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        public IActionResult About()
        {
            return this.View();
        }

        public IActionResult Photography()
        {
            var viewModel = new AllLatestCommentsViewModel
            {
                Comments = this.commentsService.GetLatestComments<LatestCommentViewModel>(),
            };

            return this.View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
