namespace MyPersonalPage.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyPersonalPage.Data.Common.Repositories;
    using MyPersonalPage.Data.Models;
    using MyPersonalPage.Web.ViewModels.Contacts.InputModels;

    [AllowAnonymous]
    public class ContactsController : BaseController
    {
        private readonly IRepository<ContactFormEntry> contactsRepository;

        public ContactsController(IRepository<ContactFormEntry> contactsRepository)
        {
            this.contactsRepository = contactsRepository;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactFormInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var contactFormEntry = new ContactFormEntry
            {
                Name = input.Name,
                Email = input.Email,
                Subject = input.Subject,
                Content = input.Content,
            };

            await this.contactsRepository.AddAsync(contactFormEntry);
            await this.contactsRepository.SaveChangesAsync();

            return this.RedirectToAction("ThankYou");
        }

        public IActionResult ThankYou()
        {
            return this.View();
        }
    }
}
