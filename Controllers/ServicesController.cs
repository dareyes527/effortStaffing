using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EffortStaffing.Controllers
{
    public class ServicesController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult PublicServiceStaffing()
        {
            return View();
        }
        public ActionResult SourcingSolutions()
        {
            return View();
        }
        public ActionResult HRConsulting()
        {
            return View();
        }
        public ActionResult ResourceAssurance()
        {
            return View();
        }
    }
}
