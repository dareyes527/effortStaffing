using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;
using EffortStaffing.Services;
using EffortStaffing.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EffortStaffing.Controllers
{
    public class ContactController : Controller
    {
        private readonly EmailOptions _emailOptions;

        public ContactController(IOptions<EmailOptions> subOptionsAccessor)

        {

            _emailOptions = subOptionsAccessor.Value;

        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Sales()
        {
            return View();
        }
        public ActionResult Recruiting()
        {
            return View();
        }
        public ActionResult Main()
        {
            return View();
        }
        //[HttpGet]
        public ActionResult ContactForm()
        {
            //    EffortStaffing.ViewModels.ContactFormViewModel model = new EffortPro.ViewModels.ContactFormViewModel();
            //    return View(model);
            //    //add email stuff
            return View();
        }

        [HttpPost]
        public ActionResult ContactForm(EffortStaffing.ViewModels.ContactFormViewModel model)
        {

            var emailService = new EffortStaffingMailService(_emailOptions);

            try
            {
                var response = emailService.Send(model);
                ViewBag.Success = true;
                ViewBag.Message = "Message Sent: Thank you for contacting EFFORT Staffing!";
                return View("Index");
            }
            catch (Exception)
            {
                ViewBag.Success = false;
                return View();
            }


        }


        public IActionResult Error()
        {
            return View();
        }
    }
}
