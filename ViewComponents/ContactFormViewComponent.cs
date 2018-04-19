using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace EffortStaffing.ViewComponents
{
    [ViewComponent(Name = "ContactForm")]
    public class ContactFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var contactFormVM = new ViewModels.ContactFormViewModel();
            return View(contactFormVM);
        }
    }
}
