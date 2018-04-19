using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EffortStaffing.Models
{
    public class EmailOptions
    {
        public EmailOptions()
        {
            APIkey = "";
        }
        public string APIkey { get; set; }
        public string ContactUsSubject { get; set; }

        public string ContactUsFromEmail { get; set; }

        public string ContactUsToEmail { get; set; }
    }
}
