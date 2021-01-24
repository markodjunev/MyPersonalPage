namespace MyPersonalPage.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyPersonalPage.Data.Models;
    using MyPersonalPage.Services.Data.Interfaces;
    using MyPersonalPage.Web.ViewModels.Comments.InputModels;
    using MyPersonalPage.Web.ViewModels.Comments.OutputViewModels;

    public class CommentsController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ICommentsService commentsService;

        public CommentsController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ICommentsService commentsService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.commentsService = commentsService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Create()
        {
            if (this.signInManager.IsSignedIn(this.User))
            {
                var user = await this.userManager.GetUserAsync(this.User);
                var input = new CreateCommentInputModel
                {
                    Username = user.UserName,
                };

                return this.View(input);
            }

            return this.View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCommentInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            if (this.signInManager.IsSignedIn(this.User))
            {
                var user = await this.userManager.GetUserAsync(this.User);

                if (input.Username != user.UserName)
                {
                    return this.RedirectToAction("Create");
                }

                input.CreatorId = user.Id;
            }
            else
            {
                input.CreatorId = null;
            }

            await this.commentsService.CreateAsync(input.Username, input.Content, input.CreatorId);

            return this.RedirectToAction("Photography", "Home");
        }

        [Authorize]
        public async Task<IActionResult> MyUsername()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var viewModel = new AllCommentsWithMyUsernameViewModel
            {
                Comments = this.commentsService.GetAllWithMyUsername<CommentWithMyUsernameViewModel>(user.UserName),
            };

            return this.View(viewModel);
        }
    }
}
