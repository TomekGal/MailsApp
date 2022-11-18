using MailsApp.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MailsApp.Models.ViewModels
{
    public class MailContentViewModel
    {
        public Mail Mail { get; set; }

      public MailStatus MailStatus { get; set; }

        public string Heading { get; set; }
    }
}