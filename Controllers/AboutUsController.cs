using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EffortStaffing.Controllers
{
    public class AboutUsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult GeneralOverview()
        {
            return View();
        }
        public ActionResult CapabilityStatement()
        {
            return View();
        }
        public ActionResult Videos()
        {
            return View();
        }
        public ActionResult MeetOurLeadership()
        {
            return View();
        }
        public ActionResult Purpose()
        {
            return View();
        }
    }
}
