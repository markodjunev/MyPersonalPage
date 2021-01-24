namespace MyPersonalPage.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MyPersonalPage.Data.Common.Models;

    public class ContactFormEntry : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }
    }
}
