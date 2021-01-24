namespace MyPersonalPage.Web.Areas.Administration.Controllers
{
    using MyPersonalPage.Common;
    using MyPersonalPage.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
